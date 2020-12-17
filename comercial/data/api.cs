﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comercial
{
    public class api
    {

        static HttpClient apio = new HttpClient();
        private static string collectionid;
        private static int mistakes;

        //Se contaran los errores, porque la api solo permite 10000 requests
        public api ()
        {
            mistakes = 0;
            collectionid = @"/b/5fdb1ab72fd0b8081255a19c";
        }

        //Api headers settings
        public static async Task appio()
        {
            apio.BaseAddress = new Uri(@"https://api.jsonbin.io");
            apio.DefaultRequestHeaders.Accept.Clear();
            apio.DefaultRequestHeaders.Add("secret-key", "$2b$10$0ADVjnMoaJSimdeZ86nMPeEF1dy3IXJy0SLyOg9Jb1g1J9UBtn.UO");
            //apio.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        //Obtener toda la informacion de la api
        public static async Task<IList<JToken>> getProducts()
        {
            IList<JToken> products = null;

            HttpResponseMessage res = await apio.GetAsync(collectionid);
            if (res.IsSuccessStatusCode)
            {
               string result = res.Content.ReadAsStringAsync().Result;
               products = JObject.Parse(result)["products"].Children().ToList();
            }
            else
            {
                MessageBox.Show("Error #301\nContacte con el programador mas cercano", "API Mistake", MessageBoxButtons.OK);
            }
            return products;
        }

        //Actualizar toda la informacion de la api
        public static async Task<HttpStatusCode> setProducts(IList<Product> productss)
        {
            string json = JsonConvert.SerializeObject(productss, Formatting.Indented);
            json = "{ \"products\":" + json + "}";

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage res = await apio.PutAsync(collectionid, content);
            return HttpStatusCode.OK;
        }

        //Comprueba, si hay mas de 10 errores en una sesion
        //Si hay, comprueba si es error de la api, o humano
        async static private void mistakesTest()
        {
            if (mistakes > 5)
            {
                int aux = mistakes;
                await getProducts();

                if (mistakes != aux)
                {
                    MessageBox.Show("Error #301\nContacte con el programador mas cercano", "API Mistake", MessageBoxButtons.OK);
                }
                else
                {
                    mistakes = 0;
                }

            }
        }
    }
}

    