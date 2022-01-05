using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProjectUI.ResponseModel
{
    public class ProductList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedDate { get; set; } 
        public string İmagePath { get; set; }
        public int CategoryId { get; set; }
    }
}
