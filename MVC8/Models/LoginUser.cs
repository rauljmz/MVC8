using System.ComponentModel.DataAnnotations;
namespace MVC8.Models
{
    public class LoginUser : Sitecore.Mvc.Presentation.RenderingModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}