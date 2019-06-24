using System.Web.Mvc;

namespace Wedding_management_project.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
             //   new { Controller = "Home"},
                new[] { "Wedding_management_project.Areas.Admin.Controllers" }
            );
        }
    }
}