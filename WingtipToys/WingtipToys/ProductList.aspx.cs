using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;

namespace WingtipToys
{
    public partial class ProductList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<Product> GetProducts([QueryString("id")]int? categoryID)
        {
            var _db = new ProductContext();
            var products = _db.Products.AsQueryable();
            if (categoryID.HasValue && categoryID > 0)
            {
                products = products.Where(p => p.CategoryID == categoryID);
            }

            return products;
        }
    }
}