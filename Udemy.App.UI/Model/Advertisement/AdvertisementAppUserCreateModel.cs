using Microsoft.AspNetCore.Http;
using System;
using Udemy.App.Common.Enums;

namespace Udemy.App.UI.Model
{
    public class AdvertisementAppUserCreateModel
    {
        public int AddvertisementId { get; set; }      
        public int AppUserId { get; set; }
        public int AdvertisementAppUserStatusId { get; set; } = (int)AdvertisementAppUserStatusType.Basvurdu;   
        public int MilitaryStatusId { get; set; }      
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public IFormFile CvFile { get; set; }
    }
}
