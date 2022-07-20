using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Udemy.App.Business.İnterfaces;
using Udemy.App.UI.Extensions;


namespace Udemy.App.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;
        private readonly IAdvertisementService _advertisementService;
        public HomeController(IProvidedServiceService providedServiceService, IAdvertisementService advertisementService = null)
        {
            _providedServiceService = providedServiceService;
            _advertisementService = advertisementService;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _providedServiceService.GetAllAsyncBl();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> HumanResourse() 
        {
            var response = await _advertisementService.GetActivesAsyncBl();
            return this.ResponseView(response); 
        }
    }
}
