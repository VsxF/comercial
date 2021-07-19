using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace comercial
{
    public class Controller
    {

        IList<Product> products; //vector donde estaran todos los productos
        IList<Product> cobros; // vector donde se guardaran parcialmente los productos de la venta
        public int state; // estado del sync: <0> Denied; <1> success; <2> loading
        api apio;
        private bool stayOffline;

        public Controller()
        {
            products = new List<Product>();
            cobros = new List<Product>();
            state = 2;
            stayOffline = false;
        }

        //Trae la clase apio (clase en ejecucion)
        public void setApio(api apio)
        {
            this.apio = apio;
        }

        //Leer archivo y vectorizar datos
        //Sincronizar con api
        public void setData(string auxApiProds)
        {
            if (File.Exists("./data.json"))
            {
                string jj = File.ReadAllText("./data.json");
                IList<JToken> pdts = JObject.Parse(jj)["products"].Children().ToList();
                bool setOfflineData = false;

                //comparar inventarios offline y online 

                //string msm = "El inventario local, es distinto al de la nube.\nDesea que se actualicen los datos de la nube?\n" +
                //    "> Al presionar \"NO\" se actualizaran los datos locales\n> Al presionar \"CANCEL\", nada se modificara y se mostraran los datos locales";

                //if (auxApiProds != null && !Regex.Replace(jj, @"\s+", "").Equals(Regex.Replace(auxApiProds, @"\s+", "")))
                //{
                //    IList<JToken> apiProds = JObject.Parse(auxApiProds)["products"].Children().ToList();
                //    DialogResult response = MessageBox.Show(msm, "Data Base", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                //    if (response == DialogResult.Yes)
                //    {
                //        write();
                //        stayOffline = false;
                //        state = 1;
                //    }
                //    else if (response == DialogResult.No)
                //    {
                //        pdts = apiProds;
                //        setOfflineData = true;
                //        stayOffline = false;
                //        state = 1;
                //    }
                //    else
                //    {
                //        stayOffline = true;
                //        state = 0;
                //        MessageBox.Show("Puede consultar todos los datos en la pestaña \"Datos\"", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }

                //}
                Product productss;
                products.Clear();

                foreach (JToken product in pdts)
                {
                    productss = product.ToObject<Product>();
                    products.Add(productss);
                }
                if (setOfflineData)
                {
                    write();
                }
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
                    pds.Add(new string[] { item.id, item.name, item.desc, item.brand, item.quant.ToString(), item.price.ToString(), item.caja.ToString() });
                }

            }
            return pds;
        }

        //Agrega un producto
        public bool setProduct(string id, string name, string desc, string brand, int quant, decimal price, int caja)
        {
            Product nw = new Product(id, name, desc, brand, quant, price, caja);
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
        public bool updateProduct(string id, string name, string desc, string brand, int quant, decimal price, int caja)
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
                    product.caja = caja;
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
        public bool write()
        {
            //convierte el vector a json
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            //Le da el formato usado al json
            json = "{ \"products\":" + json + "}";
            //Elimina el ".0" que agrega el decimal al final de los enteros
            json = Regex.Replace(json, @"\.0,", ",");
            //Guarda el vector en el Archivo json
            File.WriteAllText("./data.json", json);
            //Cheka si se esta usando solo la informacion offline
            //if (!stayOffline)
            //{
            //    //Guarda el vector en la nube
            //    apio.setProducts(json);
            //}
            return true;
        }

        //agregar producto al vector cobros
        public void setCobros(string id, string name, string desc, string brand, string quant, string price)
        {
            int ex = exist(id);
            if (ex == 0)
            {
                cobros.Add(new Product(id, name, desc, brand, int.Parse(quant), decimal.Parse(price), 0));
            }
            else
            {
                cobros[ex - 1].quant = int.Parse(quant);
                cobros[ex - 1].price = decimal.Parse(price);
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
        public decimal getTotal()
        {
            decimal total = 0;

            for (int i = 0; i < cobros.Count; i++)
            {
                if (cobros.Count != 0)
                {
                    total += cobros[i].price;
                }
            }

            return total;
        }

        //Setea la cantidad nueva y la devuelve
        public int changeQuant(string id, int quant)
        {
            foreach (Product product in products)
            {
                if (product.id.Equals(id))
                {
                    return product.quant -= quant;
                }
            }
            return 0;
        }

        //Borra los productos que fueron vendidos
        public bool endBuy()
        {
            state = 2;
            cobros = new List<Product>();
            return write();
        }

        //Cancela la compra
        public void cancelBuy()
        {
            foreach (Product sold in cobros)
            {
                foreach (Product exist in products)
                {
                    if (sold.id == exist.id)
                    {
                        exist.quant = exist.quant + sold.quant;
                    }
                }
            }
            cobros = new List<Product>();
        }

        //Quitar producto de los cobros
        public void cancelProduct(string id, int quant)
        {
                foreach (Product exist in products)
                {
                    if (id.Equals(exist.id))
                    {
                        exist.quant = exist.quant + quant;
                        break;
                    }
                }
            
            for (int i = 0; i < cobros.Count; i++)
            {
                if (cobros[i].id.Equals(id))
                {
                    cobros.RemoveAt(i);
                    break;
                }
            }
        }

        //Devuelve un vector con todos los productos, cada uno en un vector string
        public IList<string[]> getRows(bool cajas)
        {
            IList<string[]> rows = new List<string[]>();

            if (cajas)
            {
                foreach (Product item in products)
                {
                    int q = item.quant / item.caja;
                    decimal p = item.price * item.caja;
                    rows.Add(new string[] { item.id, item.name, item.desc, item.brand, q.ToString(), p.ToString(), item.caja.ToString() });
                }
            }
            else
            {
                foreach (Product item in products)
                {
                    rows.Add(new string[] { item.id, item.name, item.desc, item.brand, item.quant.ToString(), item.price.ToString(), item.caja.ToString() });
                }
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

        //Escribe un nuevo vector, en el vector productos
        public void setProducts(IList<Product> newProdcuts)
        {
            this.products = newProdcuts;
        }

        //Obtener informacion SOLO de la nube, no se guarda en los datos locas
        public async Task<IList<Product>> getCloudProducts()
        {
            Product productss;
            IList<Product> pds = new List<Product>();
            
            foreach (JToken product in await apio.getCloudProducts())
            {
                productss = product.ToObject<Product>();
                pds.Add(productss);
            }

            return pds;
        }

        public void tryNetword()
        {
            apio.getProducts();
        }

    }

    //Cosas que llevara producto
    public class Product
    {
        //Se agrego caja, como la cantidad de items por caja. Para vender por mayor
        public Product(string id, string name, string desc, string brand, int quant, decimal price, int caja)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.brand = brand;
            this.quant = quant;
            this.price = price;
            this.caja = caja;
        }


        public string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string brand { get; set; }
        public int quant { get; set; }
        public decimal price { get; set; }
        public int caja { get; set; }
    }

}
