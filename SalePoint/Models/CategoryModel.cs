using SalePoint.Class;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SalePoint.Models
{
    public class CategoryModel
    {
        public int categoryId { get; set; }
        public string categoryDescription { get; set; }
        public List<CategoryModel> categoryList { get; set; }


        public static CategoryModel GetCategoryModel(int id)
        {
            if (id > 0)
            {
                sale_pointEntities db = new sale_pointEntities();
                categoria categoryObj = db.categoria.FirstOrDefault(x => x.cat_id_categoria == id) ?? new categoria();
                return new CategoryModel { categoryId = categoryObj.cat_id_categoria, categoryDescription = categoryObj.cat_ds_categoria };
            }
            else
            {
                return new CategoryModel();
            }
        }

        public static List<CategoryModel> List()
        {
            List<CategoryModel> categoryList = new List<CategoryModel>();
            sale_pointEntities db = new sale_pointEntities();

            foreach (categoria item in db.categoria.ToList())
            {
                categoryList.Add(new CategoryModel { categoryId = item.cat_id_categoria, categoryDescription = item.cat_ds_categoria });
            }

            return categoryList;
        }

        public static bool Delete(int id)
        {
            sale_pointEntities db = new sale_pointEntities();
            db.categoria.Where(x => x.cat_id_categoria == id).ToList().ForEach(y => db.categoria.Remove(y));
            return db.SaveChanges() > 0;
        }

        public static bool Save(CategoryModel categoryObj)
        {
            sale_pointEntities db = new sale_pointEntities();
            categoria cat = new categoria();
            cat.cat_id_categoria = categoryObj.categoryId;
            cat.cat_ds_categoria = categoryObj.categoryDescription;

            if (cat.cat_id_categoria > 0)
            {
                db.categoria.Attach(cat);
                db.Entry(cat).State = EntityState.Modified;
            }
            else
            {
                db.categoria.Add(cat);
            }

            return db.SaveChanges() > 0;
        }


    }
}