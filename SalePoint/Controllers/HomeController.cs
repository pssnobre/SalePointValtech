using SalePoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalePoint.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string msg)
        {
            BuyingSessionModel model = BuyingSessionModel.GetBuyingSession();
            model.disponibleProductsList = ProductModel.List();
            ViewBag.PaymentMethodModel = new SelectList(PaymentMethodModel.List(), "paymentMethodId", "paymentMethodDescription");
            ViewBag.Script = msg;
            return View("Index", model);
        }

        public ActionResult AddProduct(int id)
        {
            BuyingSessionModel.AddProduct(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoveProduct(int id)
        {
            BuyingSessionModel.RemoveProduct(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CloseBuyingSession()
        {
            BuyingSessionModel.CloseBuyingSession();
            return Index("Session closed with success!");
            
        }
    }
}