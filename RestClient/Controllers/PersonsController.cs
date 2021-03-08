using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace RestClient.Controllers
{
    public class PersonsController : Controller
    {
        private IHttpClientFactory _clientFactory = null;
        private Uri _baseAddress = null;

        public PersonsController(IHttpClientFactory clientFactory, Uri baseAddress)
        {
            _clientFactory = clientFactory;
            _baseAddress = baseAddress;
        }

        #region get

        // GET: PersonsController
        public ActionResult Personenliste()
        {
            try
            {
                List<Person> persons = null;

                using (var client = _clientFactory.CreateClient())
                {
                    client.BaseAddress = _baseAddress;
                    try
                    {
                        persons = client.GetFromJsonAsync<List<Person>>("persons/").Result; //.Result nicht vergessen!
                    }
                    catch
                    {
                        persons = null;
                    }
                }

                if (persons != null && persons.Count > 0)
                {
                    return View(persons);
                }
                else
                {
                    return RedirectToAction(nameof(LeereListe));
                }
            }
            catch (Exception fehler)
            {
                return View();
            }
        }

        // GET: PersonsController/Create
        public ActionResult LeereListe()
        {
            return View();
        }

        // GET: PersonsController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Person person = null;

                using (var client = _clientFactory.CreateClient())
                {
                    client.BaseAddress = _baseAddress;
                    person = client.GetFromJsonAsync<Person>("persons/" + id.ToString())
                        .Result; //.Result nicht vergessen!
                }

                return View(person);
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                using (var client = _clientFactory.CreateClient())
                {
                    client.BaseAddress = _baseAddress;
                    ///.Result.... muss angegeben werden !
                    var person =
                        client.PostAsync("persons/" + collection["Vorname"] + "/" + collection["Nachname"], null).Result
                            .Content.ReadFromJsonAsync(typeof(Person)); //.Result nicht vergessen!
                }

                return RedirectToAction(nameof(Personenliste));
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region edit

        public ActionResult Edit(int id)
        {
            Person person = null;

            using (var client = _clientFactory.CreateClient())
            {
                client.BaseAddress = _baseAddress;
                person = client.GetFromJsonAsync<Person>("persons/" + id.ToString()).Result; //.Result nicht vergessen!
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                using (var client = _clientFactory.CreateClient())
                {
                    client.BaseAddress = _baseAddress;
                    var person = client.PutAsync(
                        "persons/" + id.ToString() + "/" + collection["Vorname"] + "/" +
                        collection["Nachname"], null).Result; //.Result nicht vergessen!
                }

                return RedirectToAction(nameof(Personenliste));
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region delete

        public ActionResult Delete(int id)
        {
            try
            {
                Person person = null;

                using (var client = _clientFactory.CreateClient())
                {
                    client.BaseAddress = _baseAddress;
                    person = client.GetFromJsonAsync<Person>("persons/" + id.ToString())
                        .Result; //.Result nicht vergessen!
                }

                return View(person);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Person person)
        {
            try
            {
                using (var client = _clientFactory.CreateClient())
                {
                    client.BaseAddress = _baseAddress;
                    var responseTask = client.DeleteAsync("persons/" + id.ToString()).Result; //.Result nicht vergessen!
                }

                return RedirectToAction(nameof(Personenliste));
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}