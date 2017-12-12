using SalePoint.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SalePoint.Models
{
    public class ProductModel
    {
        public int productId { get; set; }
        public string productDescription { get; set; }
        public List<ProductModel> productList { get; set; }
        public string productPrice { get; set; }
        public int categoryId { get; set; }
        public string categoryDescription { get; set; }

        public static ProductModel GetProductModel(int id)
        {
            if (id > 0)
            {
                sale_pointEntities db = new sale_pointEntities();
                produto productObj = db.produto.FirstOrDefault(x => x.pro_id_produto == id) ?? new produto();
                return new ProductModel
                {
                    productId = productObj.pro_id_produto,
                    productDescription = productObj.pro_ds_produto,
                    productPrice = Math.Round(productObj.pro_ds_preco, 2).ToString(),
                    categoryId = productObj.pro_id_categoria,
                    categoryDescription = CategoryModel.GetCategoryModel(productObj.pro_id_categoria).categoryDescription
                };
            }
            else
            {
                return new ProductModel();
            }
        }

        public static List<ProductModel> List()
        {
            List<ProductModel> productsList = new List<ProductModel>();
            sale_pointEntities db = new sale_pointEntities();

            foreach (produto item in db.produto.ToList())
            {
                productsList.Add(new ProductModel
                {
                    productId = item.pro_id_produto,
                    productDescription = item.pro_ds_produto,
                    productPrice = Math.Round(item.pro_ds_preco, 2).ToString(),
                    categoryId = item.pro_id_categoria,
                    categoryDescription = item.categoria.cat_ds_categoria
                });
            }

            return productsList;
        }

        public static bool Delete(int id)
        {
            sale_pointEntities db = new sale_pointEntities();
            db.produto.Where(x => x.pro_id_produto == id).ToList().ForEach(y => db.produto.Remove(y));
            if (BuyingSessionModel.GetBuyingSession().sessionProductsListlist.Any(x => x.productId == id))
            {
                return false;
            }
            return db.SaveChanges() > 0;

        }

        public static bool Save(ProductModel productObj)
        {
            sale_pointEntities db = new sale_pointEntities();
            produto pro = new produto();
            pro.pro_id_produto = productObj.productId;
            pro.pro_ds_produto = productObj.productDescription;

            pro.pro_ds_preco = double.Parse(productObj.productPrice.Replace(".", ","));
            pro.pro_id_categoria = productObj.categoryId;

            if (pro.pro_id_produto > 0)
            {
                db.produto.Attach(pro);
                db.Entry(pro).State = EntityState.Modified;
            }
            else
            {
                db.produto.Add(pro);
            }

            return db.SaveChanges() > 0;
        }



    }

}