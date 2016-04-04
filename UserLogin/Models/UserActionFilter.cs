using System;
using System.Collections.Generic; 
 using System.Linq; 
 using System.Web; 
 using System.Web.Http.Controllers; 
 using System.Web.Mvc; 
 using Authentication.Data; 
 
 
 namespace MvcApplication14.Models 
 { 
     public class UserActionFilterAttribute : ActionFilterAttribute 
     { 
         public override void OnActionExecuting(ActionExecutingContext filterContext) 
        { 
             base.OnActionExecuting(filterContext); 
             if (!filterContext.HttpContext.User.Identity.IsAuthenticated) 
             { 
                 return; 
             } 
 
 
             var mgr = new UserManager(Properties.Settings.Default.ConStr); 
 
 
             filterContext.Controller.ViewBag.User = 
                 mgr.GetUserByUserName(filterContext.HttpContext.User.Identity.Name); 
         } 
     } 
 } 

