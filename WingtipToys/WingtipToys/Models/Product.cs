using System.ComponentModel.DataAnnotations;

namespace WingtipToys.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required, StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public struct SQLCommands
        {
            public static string GetOne { get
                {
                    string command = null;
                    command += string.Format("SELECT [ProductID] AS [{0}]", nameof(ProductID));
                    command += string.Format(",[ProductName] AS [{0}]", nameof(ProductName));
                    command += string.Format(",[Description] AS [{0}]", nameof(Description));
                    command += string.Format(",[ImagePath] AS [{0}]", nameof(ImagePath));
                    command += string.Format(",[UnitPrice] AS [{0}]", nameof(UnitPrice));
                    command += string.Format(",[CategoryID] AS [{0}]", nameof(CategoryID));
                    command += string.Format(",NULL AS [{0}] ", nameof(Category));
                    command += string.Format("FROM [Products] ");
                    command += string.Format("WHERE [ProductID] = @{0}", nameof(ProductID));

                    return command;
                }
            }
        }
    }
}