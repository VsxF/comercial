using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
        
        IList<Product> products = new List<Product>(); //vector donde estaran todos los productos
        IList<Product> cobros = new List<Product>(); // vector donde se guardaran parcialmente los productos de la venta

        //Leer archivo y vectorizar datos
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

        //Obtener una lista de todos los productos
        public IList<Product> getProducts()
        {
            return products;
        }

        //Obtener producto
        public Product getProduct(string id)
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

        //Devuelve una lista de la busqueda en base al nombre
        public IList<string[]> getSearch(string id)
        {
            IList<string[]> pds = new List<string[]>();
            foreach (Product item in products)
            {
                if (item.name.ToLower().Contains(id.ToLower()))
                {
                    pds.Add(new string[] { item.id, item.name, item.desc, item.brand, item.quant.ToString(), item.price.ToString() });
                }

            }
            return pds;
        }

        //Agrega un producto
        public bool setProduct(string id, string name, string desc, string brand, int quant, float price)
        {
            Product nw = new Product(id, name, desc, brand, quant, price);
            foreach (Product product in products)
            {
                if (product.id == id)
                {
                    //MessageBox.Show("El id ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (product.name.Equals(name))
                {
                    //MessageBox.Show("El nombre ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return false;
                }
            }

            products.Add(nw);

            return write();
        }

        //Actualiza un producto
        public bool updateProduct(string id, string name, string desc, string brand, int quant, float price)
        {
            foreach (Product product in products)
            {
                if (product.id == id)
                {
                    product.name = name;
                    product.desc = desc;
                    product.brand = brand;
                    product.quant = quant;
                    product.price = price;
                    return write();
                }
            }
            return false;
        }

        //Borra un producto
        public bool deleteProduct(string id)
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

        //Establece la cantidad de un producto en base al id
        public bool setQuant(string id, int quant)
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

        //Escribe en el archivo json el contenido del vector "products"
        private bool write()
        {
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            json = "{ \"products\":" + json + "}";
            File.WriteAllText("../../../data/data.json", json);
            return true;
        }

        //agregar producto al vector cobros
        public void setCobros(string id, string name, string desc, string brand, string quant, string price)
        {
            int ex = exist(id);
            if (ex == 0 )
            {
                cobros.Add(new Product(id, name, desc, brand, int.Parse(quant), float.Parse(price)));
            }
            else
            {
                cobros[ex].quant = int.Parse(quant);
                cobros[ex].price = float.Parse(price);
            }
            
        }

        //Obtener el vector de cobros
        public IList<Product> getCobros()
        {
            return cobros;
        }

        //Comprueba si un producto ya existe en el vector cobros
        public int exist(string id)
        {
            int aux = 0;
            foreach (Product p in cobros)
            {
                aux++;
                if (p.id.Equals(id))
                {
                    return aux;
                }
            }
            return 0;
        }

        //Devuelve el precio total de los cobros
        public float getTotal()
        {
            float total = 0;
            
            for (int i=0; i < cobros.Count; i++)
            {
                if(cobros.Count != 0)
                {
                    total += cobros[i].price;
                }
            }

            return total;
        }

        //Borra los productos que fueron vendidos: vectores: -> (products - cobros)
        public void endBuy()
        {
            foreach(Product sold in cobros)
            {
                foreach(Product exist in products)
                {
                    if (sold.id == exist.id)
                    {
                        exist.quant = exist.quant - sold.quant;
                    }
                }
            } 
        }
         
        //Devuelve un vector con todos los productos, cada uno en un vector string
        public IList<string[]> getRows()
        {
            IList<string[]> rows = new List<string[]>();

            foreach (Product item in products)
            {
                rows.Add(new string[] { item.id, item.name, item.desc, item.brand, item.quant.ToString(), item.price.ToString() });
            }
            return rows;
        }

        //Verifica que la  tabla tenga mas de 5 filas (estetica)
        public int RowCheck(int items)
        {
            if (items < 5)
            {
                return 5;
            }
            else
            {
                return items;
            }
        }

    }
 
    //Cosas que llevara producto
    public class Product
    {
        public Product(string id, string name, string desc, string brand, int quant, float price)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.brand = brand;
            this.quant = quant;
            this.price = price;
        }


        public string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
         public string brand { get; set; }
        public int quant { get; set; }
        public float price { get; set; }
    }

}
