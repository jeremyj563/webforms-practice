using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using WingtipToys.Properties;
using DataRepositories;

namespace WingtipToys
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Product GetProduct([QueryString("productID")] int? productID)
        {
            var repo = new MSSQLRepository(Settings.Default.ConnectionString);

            Product product = null;
            if (productID.HasValue && productID > 0)
            {
                (string, object)[] id = { (nameof(Product.ProductID), productID) };
                product = repo.Get<Product>(Product.SQLCommands.GetOne, id).SingleOrDefault();
            }

            return product;
        }
    }
}