using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using banxemaymvc.Models;
using Newtonsoft.Json;

namespace banxemaymvc.Controllers
{
    public class hangxeController : Controller
    {
        // GET: hangxe
        
        public ActionResult Index()
        {
            List<hangxe> Products = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:65004/api/hangxe/");
                var getTask = client.GetAsync("Get");
                getTask.Wait();

                var result = getTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;

                    Products = JsonConvert.DeserializeObject<List<hangxe>>(data);
                }
            }
            return View(Products);
        }
        public ActionResult Create(hangxe s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:65004/api/hangxe/");
                string data = JsonConvert.SerializeObject(s);

                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var postTask = client.PostAsync("Post", content);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
        public ActionResult Details(string id)
        {

            hangxe s = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:65004/api/hangxe/");
                //$"api/products/{id}"
                var getTask = client.GetAsync("Get/" + id);
                getTask.Wait();

                var result = getTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    s = JsonConvert.DeserializeObject<hangxe>(data);
                }
            }
            return View(s);
        }
        public ActionResult Edit(string id)
        {
            hangxe s = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:65004/api/hangxe/");
                var getTask = client.GetAsync("Get/" + id);
                getTask.Wait();

                var result = getTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;

                    s = JsonConvert.DeserializeObject<hangxe>(data);
                }
            }
            return View("Edit", s);
        }
        [HttpPost]
        public ActionResult Edit(hangxe s)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:65004/api/hangxe/");
                string data = JsonConvert.SerializeObject(s);

                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                var PutTask = client.PutAsync("Put/" + s.mahang, content);
                PutTask.Wait();

                var result = PutTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "Server Error. Please contact administrator!");
            return View();
        }
        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:65004/api/hangxe/");
                var deleteTask = client.DeleteAsync("Delete/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }


            }
            return RedirectToAction("Index");
        }
    }
}