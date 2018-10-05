using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task1.Models
{
    public class SaleInfo
    {
        
        public int Id { get; set; }

        public string Cust_Name { get; set; }
        public string Product_Name { get; set; }
        public string Store_Name { get; set; }
        public System.DateTime Date_Sold { get; set; }
        public System.Web.Mvc.SelectList Customer { get; set; }


    }
}