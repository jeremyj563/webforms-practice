using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;

namespace WingtipToys
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Product GetProduct([QueryString("productID")] int? productID)
        {
            var _db = new ProductContext();

            Product product = null;
            if (productID.HasValue && productID > 0)
            {
                product = _db.Products.SingleOrDefault(p => p.ProductID == productID);
            }

            return product;
        }
    }
}