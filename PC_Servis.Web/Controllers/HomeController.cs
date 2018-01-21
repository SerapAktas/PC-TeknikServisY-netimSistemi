using Microsoft.AspNet.Identity;
using PC_Servis.Web.Services;
using PC_Servis.BLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PC_Servis.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [MyAuth(Kamil = "Büyük kamil")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Admin,User")]
        public ActionResult Mesajlar()
        {
            var model = new MessageRepo().Queryable().Where(x => x.SendBy == HttpContext.User.Identity.GetUserId()).ToList();
            return View(model);
        }
    

    #region Partials

    public PartialViewResult HeaderResult()
        {
            var model = "Merhaba Partial";
            return PartialView("_PartialHeader", model);
        }
        public PartialViewResult BeginSaleProductResult()
        {
            return PartialView("_PartialBeginSaleProduct");
        }
        public PartialViewResult BrandsResult()
        {
            return PartialView("_PartialBrands");
        }
        public PartialViewResult FastViewProductResult()
        {
            return PartialView("_PartialFastViewProduct");
        }
        public PartialViewResult SliderResult()
        {
            return PartialView("_PartialSlider");
        }
        public PartialViewResult SidebarResult()
        {
            return PartialView("_PartialSidebar");
        }
        public PartialViewResult StepsResult()
        {
            return PartialView("_PartialSteps");
        }
        public PartialViewResult PromoResult()
        {
            return PartialView("_PartialPromo");
        }
        public PartialViewResult StyleCustomizerResult()
        {
            return PartialView("_PartialStyleCustomizer");
        }
        public PartialViewResult TopBarResult()
        {
            return PartialView("_PartialTopBar");
        }
        public PartialViewResult PreFooterResult()
        {
            return PartialView("_PartialPreFooter");
        }
        public PartialViewResult FooterResult()
        {
            return PartialView("_PartialFooter");
        }
        #endregion
    }
}