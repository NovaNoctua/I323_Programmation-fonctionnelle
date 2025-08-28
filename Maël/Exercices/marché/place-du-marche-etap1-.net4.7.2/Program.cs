using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;


namespace PlaceDuMarche
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            string strFileName = @"C:\Users\ps46bhd\Desktop\I323_Programmation-fonctionnelle\Maël\Exercices\marché\PlaceDuMarche\Resources\placeDuMarche.xlsx";
            object missing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook workBook = excel.Application.Workbooks.Open(strFileName, missing, true, missing, missing, missing,
            missing, missing, missing, true, missing, missing, missing, missing, missing);
            Worksheet worksheet = (Worksheet)workBook.Sheets[2];


            Range usedRange = worksheet.UsedRange;

            for (int i = 2; i <= usedRange.Rows.Count; i++)
            {
                int place = Convert.ToInt16(worksheet.Cells[i, 1].Value);
                string sellerName = worksheet.Cells[i, 2].Value;
                string productName = worksheet.Cells[i, 3].Value;
                int quantity = Convert.ToInt16(worksheet.Cells[i, 4].Value);
                string unit = worksheet.Cells[i, 5].Value;
                int price = Convert.ToInt16(worksheet.Cells[i, 6].Value);

                Product product = new Product(place, sellerName, productName, quantity, unit, price);

                products.Add(product);

            }

            numberOfSellers("pêches", products);
            mostProducts("pastèques", products);

            Console.ReadLine();

            void numberOfSellers(string productName, List<Product> productList)
            {
                int number = 0;

                foreach(Product product in products)
                {
                    if (product.ProductName.ToLower() == productName)
                    {
                        number++;
                    }
                }

                Console.WriteLine($"Il y a {number} vendeurs de {productName}");
            }

            void mostProducts(string productName, List<Product> productList)
            {
                Product mostProduct = null;

                foreach(Product product in products)
                {
                    if (mostProduct is null && product.ProductName.ToLower() == productName)
                    {
                        mostProduct = product;
                    }
                    else if (product.ProductName.ToLower() == productName && product.Quantity > mostProduct.Quantity)
                    {
                        mostProduct = product;
                    }
                }
                if (mostProduct is null)
                {
                    Console.WriteLine($"Personne ne vend de {productName}");
                } 
                else
                {
                    Console.WriteLine($"C'est {mostProduct.SellerName} qui a le plus de {productName} (stand {mostProduct.Place}, {mostProduct.Quantity} {mostProduct.Unit}s)");
                }
            }
        }
    }
}
