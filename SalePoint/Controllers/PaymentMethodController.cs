using SalePoint.Models;
using System.Web.Mvc;

namespace SalePoint.Controllers
{
    public class PaymentMethodController : Controller
    {
        public ActionResult Index()
        {
            PaymentMethodModel model = new PaymentMethodModel();
            model.paymentMethodList = PaymentMethodModel.List();
            return View("Index", model);
        }

        public ActionResult New()
        {
            PaymentMethodModel model = new PaymentMethodModel();
            return View("Detalhe", model);
        }

        public ActionResult Edit(int id)
        {
            PaymentMethodModel model = PaymentMethodModel.GetPaymentMethodModel(id);
            return View("Detalhe", model);
        }

        public ActionResult Delete(int id)
        {
            PaymentMethodModel.Delete(id);
            return Index();
        }

        public ActionResult Save(PaymentMethodModel paymentMethodObj)
        {
            if (PaymentMethodModel.Save(paymentMethodObj))
            {
                return Index();
            }
            else
            {
                return Edit(paymentMethodObj.paymentMethodId);
            }
        }
    }
}