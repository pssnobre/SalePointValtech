using SalePoint.Class;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SalePoint.Models
{
    public class PaymentMethodModel
    {
        public int paymentMethodId { get; set; }
        public string paymentMethodDescription { get; set; }
        public List<PaymentMethodModel> paymentMethodList { get; set; }

        public static PaymentMethodModel GetPaymentMethodModel(int id)
        {
            if (id > 0)
            {
                sale_pointEntities db = new sale_pointEntities();
                forma_pagamento paymentMethodObj = db.forma_pagamento.FirstOrDefault(x => x.pgt_id_forma_pagamento == id) ?? new forma_pagamento();
                return new PaymentMethodModel { paymentMethodId = paymentMethodObj.pgt_id_forma_pagamento, paymentMethodDescription = paymentMethodObj.pgt_ds_forma_pagamento };
            }
            else
            {
                return new PaymentMethodModel();
            }
        }

        public static List<PaymentMethodModel> List()
        {
            List<PaymentMethodModel> paymentMethodList = new List<PaymentMethodModel>();
            sale_pointEntities db = new sale_pointEntities();

            foreach (forma_pagamento item in db.forma_pagamento.ToList())
            {
                paymentMethodList.Add(new PaymentMethodModel { paymentMethodId = item.pgt_id_forma_pagamento, paymentMethodDescription = item.pgt_ds_forma_pagamento });
            }

            return paymentMethodList;
        }

        public static bool Delete(int id)
        {
            sale_pointEntities db = new sale_pointEntities();
            db.forma_pagamento.Where(x => x.pgt_id_forma_pagamento == id).ToList().ForEach(y => db.forma_pagamento.Remove(y));
            return db.SaveChanges() > 0;
        }

        public static bool Save(PaymentMethodModel paymentMethodObj)
        {
            sale_pointEntities db = new sale_pointEntities();
            forma_pagamento pgt = new forma_pagamento();
            pgt.pgt_id_forma_pagamento = paymentMethodObj.paymentMethodId;
            pgt.pgt_ds_forma_pagamento = paymentMethodObj.paymentMethodDescription;

            if (pgt.pgt_id_forma_pagamento > 0)
            {
                db.forma_pagamento.Attach(pgt);
                db.Entry(pgt).State = EntityState.Modified;
            }
            else
            {
                db.forma_pagamento.Add(pgt);
            }

            return db.SaveChanges() > 0;
        }

    }
}