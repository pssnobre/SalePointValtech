using SalePoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalePoint.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            ProductModel model = new ProductModel();
            model.productList = ProductModel.List();
            return View("Index", model);
        }

        public ActionResult New()
        {
            ViewBag.ProductCategories = new SelectList(CategoryModel.List(), "categoryId", "categoryDescription");
            ProductModel model = new ProductModel();
            return View("Detalhe", model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ProductCategories = new SelectList(CategoryModel.List(), "categoryId", "categoryDescription"); 
            ProductModel model = ProductModel.GetProductModel(id);
            return View("Detalhe", model);
        }

        public ActionResult Delete(int id)
        {
            ProductModel.Delete(id);
            return Index();
        }

        public ActionResult Save(ProductModel productObj)
        {
            if (ProductModel.Save(productObj))
            {
                return Index();
            }
            else
            {
                return Edit(productObj.productId);
            }
        }
    }
}