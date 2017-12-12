using SalePoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalePoint.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(string msg)
        {
            CategoryModel model = new CategoryModel();
            model.categoryList = CategoryModel.List();
            ViewBag.Script = msg;
            return View("Index", model);
        }

        public ActionResult New()
        {
            CategoryModel model = new CategoryModel();
            return View("Detalhe", model);
        }

        public ActionResult Edit(int id)
        {
            CategoryModel model = CategoryModel.GetCategoryModel(id);
            return View("Detalhe", model);
        }

        public ActionResult Delete(int id)
        {
            if (!CategoryModel.Delete(id))
            {
                return Index("You can not delete. Category associated with a product.");
            }            
            return Index("");
        }

        public ActionResult Save(CategoryModel categoryObj)
        {
            if (CategoryModel.Save(categoryObj))
            {
                return Index("");
            }
            else
            {
                return Edit(categoryObj.categoryId);
            }
        }

    }
}