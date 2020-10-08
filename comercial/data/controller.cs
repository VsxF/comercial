using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace comercial
{
    public class Controller
    {
        IList<Product> products = new List<Product>();

        public Controller()
        {
            string jj = File.ReadAllText("../../../data/data.json");
            IList<JToken> pdts = JObject.Parse(jj)["products"].Children().ToList();
            Product productss;
            foreach (JToken product in pdts)
            {
                productss = product.ToObject<Product>();
                products.Add(productss);
            }

        }

        public IList<Product> getProducts()
        {
            return products;
        }

        public Product getProduct(int id)
        {
            foreach (Product product in products)
            {
                if (id == product.id)
                {
                    return product;
                }

            }
            return null;
        }

        public bool setProduct(int id, string name, int quant, float price)
        {
            Product nw = new Product();
            nw.id = id;
            nw.name = name;
            nw.quant = quant;
            nw.price = price;

            foreach (Product product in products)
            {
                if (product.id == id)
                {
                    MessageBox.Show("El id ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (product.name.Equals(name))
                {
                    MessageBox.Show("El nombre ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            products.Add(nw);

            return write();
        }

        public bool updateProduct(int id, string name, int quant, float price)
        {
            foreach (Product product in products)
            {
                if (product.id == id)
                {
                    product.name = name;
                    product.quant = quant;
                    product.price = price;
                    return write();
                }
            }
            return false;
        }

        public bool deleteProduct(int id)
        {
            foreach (Product product in products)
            {
                if (product.id == id)
                {
                    products.Remove(product);
                    return write();
                }
            }
            return false;
        }

        public bool setQuant(int id, int quant)
        {
            foreach (Product product in products)
            {
                if (product.id == id)
                {
                    product.quant = quant;
                    return write();
                }
            }
            return false;
        }

        private bool write()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.Indented);
            json = "{ \"products\":" + json + "}";
            File.WriteAllText("../../../data/data.json", json);
            return true;
        }

    }

    //Cosas que llevara producto
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int quant { get; set; }
        public float price { get; set; }
    }

}
