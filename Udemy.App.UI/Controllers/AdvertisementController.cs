using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Udemy.App.Business.İnterfaces;
using Udemy.App.Common.Enums;
using Udemy.App.Dtos;
using Udemy.App.UI.Extensions;
using Udemy.App.UI.Model;

namespace Udemy.App.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IAdvertisementAppUserService _advertisementAppUserService;
        private readonly IMapper _mapper;

        public AdvertisementController(IAppUserService appUserService, IAdvertisementAppUserService advertisementAppUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _advertisementAppUserService = advertisementAppUserService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var userResponse = await _appUserService.GetByIdAsnycBl<AppUserListDto>(userId);

            ViewBag.GenderId = userResponse.Data.GenderId;

            var items = Enum.GetValues(typeof(MilitaryStatusType));
            var list = new List<MilitaryStatusListDto>();
            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item),
                });
            }
            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

            return View(new AdvertisementAppUserCreateModel
            {
                AddvertisementId = advertisementId,
                AppUserId = userId,

            });
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
        {
            var createDto = _mapper.Map<AdvertisementAppUserCreateDto>(model);

            if (model.CvFile != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(model.CvFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvFiles", fileName + extName);
                var stream = new FileStream(path, FileMode.Create);
                await model.CvFile.CopyToAsync(stream);
                createDto.CvPath = path;
            }

            //dto.AdvertisementAppUserStatusId = model.AdvertisementAppUserStatusId;
            //dto.AddvertisementId = model.AddvertisementId;
            //dto.AppUserId = model.AppUserId;
            //dto.EndDate = model.EndDate;
            //dto.MilitaryStatusId = model.MilitaryStatusId;
            //dto.WorkExperience = model.WorkExperience;



            var response = await _advertisementAppUserService.CreateAsyncBl(createDto);

            if (response.ResponseType == Common.ResponseType.ValidationError)
            {
                foreach (var errors in response.ValidationError)
                {
                    ModelState.AddModelError(errors.PropertyName, errors.ErrorMessage);
                }

                var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var userResponse = await _appUserService.GetByIdAsnycBl<AppUserListDto>(userId);

                ViewBag.GenderId = userResponse.Data.GenderId;

                var items = Enum.GetValues(typeof(MilitaryStatusType));
                var list = new List<MilitaryStatusListDto>();
                foreach (int item in items)
                {
                    list.Add(new MilitaryStatusListDto
                    {
                        Id = item,
                        Definition = Enum.GetName(typeof(MilitaryStatusType), item),
                    });
                }
                ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

                return View(model);
            }
            else
            {
                return RedirectToAction("HumanResourse", "Home");
            }



        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Basvurdu);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult SetStatus(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            return RedirectToAction("List");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApprovedList()
        {

            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Mulakat);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectedList()
        {

            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Olumsuz);
            return View(list);
        }


    }
}
