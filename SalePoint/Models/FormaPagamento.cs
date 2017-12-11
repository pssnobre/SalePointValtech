using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalePoint.Models
{
    public class FormaPagamento
    {
        public int idFormaPagamento { get; set; }
        public string descricaoFormaPagamento { get; set; }
        public List<FormaPagamento> listaFormaPagamento { get; set; }




    }
}