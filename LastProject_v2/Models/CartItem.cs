using ModelWeb.EF1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastProject_v2.Models
{
    [Serializable]
    public class CartItem
    {
        public tProduct product { get; set; }
        public int Quantity { get; set; }
    }
}