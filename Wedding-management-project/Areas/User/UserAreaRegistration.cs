using System.Web.Mvc;

namespace Wedding_management_project.Areas.User
{
    public class UserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "User";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "User_default",
                "User/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
               // new { Controller = "Home" },
                new[] { "Wedding_management_project.Areas.User.Controllers" }
            );
        }
    }
}