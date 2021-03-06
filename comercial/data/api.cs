﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comercial
{
    public class api
    {

        static HttpClient apio = new HttpClient();
        private static string collectionid;
        private static string coll_inventory;
        private static string coll_last;
        private static string coll_history;
        private static int mistakes;
        Controller controller;

        //Se contaran los errores, porque la api solo permite 10000 requests
        public api(Controller controller)
        {
            this.controller = controller;
            mistakes = 0;
            collectionid = @"/b/60f00ec30cd33f7437c8d964";
            coll_last = @"/b/60eeb027a917050205c7136e";
            coll_history = @"/b/60eeb01d0cd33f7437c80bbc";
            //collectionid = @"/b/5fdb1ab72fd0b8081255a19c";
        }

        //Api headers settings
        public async Task appio()
        {
            //apio.BaseAddress = new Uri(@"https://api.jsonbin.io/v3");
            apio.BaseAddress = new Uri(@"https://api.jsonbin.io/v3");
            apio.DefaultRequestHeaders.Accept.Clear();
            //apio.DefaultRequestHeaders.Add("secret-key", "$2b$10$0ADVjnMoaJSimdeZ86nMPeEF1dy3IXJy0SLyOg9Jb1g1J9UBtn.UO");
            apio.DefaultRequestHeaders.Add("secret-key", "$2b$10$xh56gg2.I3By5jwkhRtD8e2EYNUOsl3gJHktI2ShGZPHzx0Cv08MC");
            //apio.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        //Obtener toda la informacion de la api
        public async Task<IList<JToken>> getProducts()
        {
            IList<JToken> products = null;

            controller.state = 2;
            HttpResponseMessage res = await apio.GetAsync(collectionid + @"/latest");
            string result = res.Content.ReadAsStringAsync().Result;
            
            products = JObject.Parse(result)["products"].Children().ToList(); 
            controller.setData(result);
            return products;
        }

        //Obtener toda la informacion de la api, especificamente (no se guardan los datos localmente)
        public async Task<IList<JToken>> getCloudProducts()
        {
            IList<JToken> products = null;

            HttpResponseMessage res = await apio.GetAsync(collectionid + @"/latest");
            

            string result = res.Content.ReadAsStringAsync().Result;
            products = JObject.Parse(result)["products"].Children().ToList();
            return products;
        }

        //Actualizar toda la informacion de la api
        public async Task<bool> setProducts(string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage res = await apio.PutAsync(collectionid, content);
            controller.state = 1;
            return true;
        }

        //Obtiene la cantidad de cambios
        public async Task<int> getBinVersion()
        {
            //HttpResponseMessage res = await apio.GetAsync(collectionid + @"/versions/count ");
            HttpClient appi = new HttpClient();
            appi.DefaultRequestHeaders.Accept.Clear();
            appi.DefaultRequestHeaders.Add("secret-key", "$2b$10$xh56gg2.I3By5jwkhRtD8e2EYNUOsl3gJHktI2ShGZPHzx0Cv08MC");
            HttpResponseMessage res = await apio.GetAsync(@"https://api.jsonbin.io/v3/b/60f00ec30cd33f7437c8d964/versions/count");
            string aux = res.Content.ReadAsStringAsync().Result;

            return 0;
        }

        //Comprueba, si hay mas de 10 errores en una sesion
        //Si hay, comprueba si es error de la api, o humano
        async private void mistakesTest()
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

        //Comprueba si hay internet

    }
}



