using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace Client
{
	public class SessionExpireFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.HttpContext.Session.GetString("") == null)
			{
				filterContext.Result = new RedirectResult("~//SessionExpired");
				return;
			}
			base.OnActionExecuting(filterContext);
		}
	}
	}

