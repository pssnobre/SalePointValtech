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
        public ActionResult Index()
        {
            CategoryModel model = new CategoryModel();
            model.categoryList = CategoryModel.List();
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
            CategoryModel.Delete(id);
            return Index();
        }

        public ActionResult Save(CategoryModel categoryObj)
        {
            if (CategoryModel.Save(categoryObj))
            {
                return Index();
            }
            else
            {
                return Edit(categoryObj.categoryId);
            }
        }

    }
}