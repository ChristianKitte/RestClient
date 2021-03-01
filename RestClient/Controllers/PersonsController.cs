using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RestClient.Models;

namespace RestClient.Controllers
{
    public class PersonsController : Controller
    {
        // GET: PersonsController
        public ActionResult Index()
        {
            List<Person> persons = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://127.0.0.1:8080/api/v1/");
                persons = client.GetFromJsonAsync<List<Person>>("persons/").Result;
            }

            return View(persons);
        }

        // GET: PersonsController/Details/5
        public ActionResult Details(int id)
        {
            Person person = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://127.0.0.1:8080/api/v1/");
                person = client.GetFromJsonAsync<Person>("persons/" + id.ToString() + "/").Result;
            }

            return View(person);
        }

        // GET: PersonsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://127.0.0.1:8080/api/v1/");
                    var x = "persons/" + collection["Vorname"] + "/" + collection["Nachname"] + "/";
                    var person =
                        client.PostAsync("persons/" + collection["Vorname"] + "/" + collection["Nachname"] + "/", null);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}