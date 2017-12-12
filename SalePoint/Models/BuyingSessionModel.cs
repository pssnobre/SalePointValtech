using SalePoint.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SalePoint.Models
{
    public class BuyingSessionModel
    {
        public int sessionId { get; set; }
        public List<ProductModel> disponibleProductsList { get; set; }
        public List<ProductModel> sessionProductsListlist { get; set; }
        public double totalValue { get; set; }
        public int paymentId { get; set; }


        public static BuyingSessionModel AddProduct(int produtcId)
        {
            BuyingSessionModel objBuyingSession = GetBuyingSession();
            sale_pointEntities db = new sale_pointEntities();
            ProductModel productObj = ProductModel.GetProductModel(produtcId);
            objBuyingSession.sessionProductsListlist.Add(productObj);
            objBuyingSession.totalValue += double.Parse(productObj.productPrice);
            objBuyingSession.totalValue = Math.Round(objBuyingSession.totalValue, 2);
            return RecordBuyingSession(objBuyingSession);
        }

        public static BuyingSessionModel RemoveProduct(int produtcId)
        {
            BuyingSessionModel objBuyingSession = GetBuyingSession();
            ProductModel productObj = objBuyingSession.sessionProductsListlist.FirstOrDefault(x => x.productId == produtcId);
            if (productObj != null)
            {
                objBuyingSession.sessionProductsListlist.Remove(productObj);
                objBuyingSession.totalValue -= double.Parse(productObj.productPrice);
                objBuyingSession.totalValue = Math.Round(objBuyingSession.totalValue, 2);
            }
            return RecordBuyingSession(objBuyingSession);
        }
        public static bool CloseBuyingSession()
        {
            if (GetBuyingSession().sessionProductsListlist.Count == 0)
            {
                return false;
            }
            NewBuyingSession();
            return true;
        }

        public static BuyingSessionModel RecordBuyingSession(BuyingSessionModel objBuyingSession)
        {
            HttpContext.Current.Session["BuyingSession"] = objBuyingSession;
            return GetBuyingSession();
        }

        public static BuyingSessionModel NewBuyingSession()
        {
            BuyingSessionModel objBuyingSession = new BuyingSessionModel();
            objBuyingSession.sessionProductsListlist = new List<ProductModel>();
            HttpContext.Current.Session.Add("BuyingSession", objBuyingSession);
            return GetBuyingSession();
        }

        public static BuyingSessionModel GetBuyingSession()
        {
            return (BuyingSessionModel)HttpContext.Current.Session["BuyingSession"] ?? NewBuyingSession();
        }
    }
}