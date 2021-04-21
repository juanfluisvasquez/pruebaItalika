using DemoData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DemoWebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var listEmisores = GetItemsApi();
            

            return View(listEmisores);
        }

        public ActionResult Create() 
        {
            ViewBag.tipos = GetTiposApi();
            return View();
        }

        
        public ActionResult Delete(int id)
        {
            PostDelete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                MotosItalika entity1 = new MotosItalika();


                entity1.SKU = this.Request.Form["SKU"];
                entity1.Fert = this.Request.Form["Fert"];
                entity1.Modelo = this.Request.Form["Modelo"];
                entity1.NumSerie = this.Request.Form["NumSerie"];




                var objFecha = this.Request.Form["Fecha"];
                var objTipo = this.Request.Form["IdTipo"];


                entity1.Fecha = objFecha == "0" || objFecha == "" ? new DateTime() : Convert.ToDateTime(objFecha);
                
                entity1.IdTipo = objTipo == "0" || objTipo == "" ? 1 :(Convert.ToInt32(objTipo));
                PostItem(JsonConvert.SerializeObject(entity1));

                return RedirectToAction("Index");

            }

            catch (Exception ex)

            {
                ViewBag.tipos = GetTiposApi();
                ViewBag.Errors = ex.Message;
                return View();

                throw;
            }      
        
        }

        public List<MotosItalika> GetItemsApi()
        {
            List<MotosItalika> result = new List<MotosItalika>();
            var url = "https://localhost:44394/MotosItalika";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse _response = request.GetResponse())
                {
                    using (Stream _strReader = _response.GetResponseStream()) 
                    {
                        if (_strReader == null) return result;
                        using (StreamReader objReader = new StreamReader(_strReader)) 
                        {
                            string responseBody = objReader.ReadToEnd();
                            result = JsonConvert.DeserializeObject<List<MotosItalika>>(responseBody);
                            Console.WriteLine(responseBody);
                        }
                    
                    }
                
                
                }


            }
            catch (Exception)
            {

                throw;
            }


            return result;
        
        
        }

        public List<Tipo> GetTiposApi()
        {
            List<Tipo> result = new List<Tipo>();
            var url = "https://localhost:44394/Tipo";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse _response = request.GetResponse())
                {
                    using (Stream _strReader = _response.GetResponseStream())
                    {
                        if (_strReader == null) return result;
                        using (StreamReader objReader = new StreamReader(_strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            result = JsonConvert.DeserializeObject<List<Tipo>>(responseBody);
                            Console.WriteLine(responseBody);
                        }

                    }


                }


            }
            catch (Exception)
            {

                throw;
            }


            return result;


        }

        private void PostItem(string data)
        {
            var url = $"https://localhost:44394/MotosItalika";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        private void PostDelete(int id)
        {
            var url = $"https://localhost:44394/MotosItalika/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Delete";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            
            try
            {
                using (WebResponse _response = request.GetResponse())
                {
                    using (Stream _strReader = _response.GetResponseStream())
                    {
                        if (_strReader == null) return ;
                        using (StreamReader objReader = new StreamReader(_strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            //result = JsonConvert.DeserializeObject<List<MotosItalika>>(responseBody);
                            //Console.WriteLine(responseBody);
                        }

                    }


                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

    }
}