using Udemy.App.Dtos.İnterfaces;

namespace Udemy.App.Dtos
{
    public class AppUserLoginDto : IDto
    {
		public string Username { get; set; }
		public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
