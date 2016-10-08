using System.Web.Mvc;
namespace Models
{
    public class SupportFilter
    {
    }
    public class SupportFilterAttribute : ActionFilterAttribute
    {

        /// <summary>
        /// 当Action中标注了[SupportFilter]的时候会执行
        /// </summary>
        /// <param name="filterContext">请求上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (System.Web.HttpContext.Current.Request.Cookies == null)
            {
                filterContext.HttpContext.Response.Write(" <script type='text/javascript'> window.top.location='/'; </script>");
                filterContext.Result = new EmptyResult();
                return;
            }
            if (System.Web.HttpContext.Current.Request.Cookies != null && System.Web.HttpContext.Current.Request.Cookies["account"] == null)
            {
                filterContext.HttpContext.Response.Write(" <script type='text/javascript'> window.top.location='/'; </script>");
                filterContext.Result = new EmptyResult();
                return;
            }

        }

    }
}
