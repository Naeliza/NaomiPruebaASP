using CrudPersona.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CrudPersona.Controllers
{
    public class PersonaController : Controller
    {
        Uri baseAddress = new Uri("http://www.pruebanaomi.somee.com/api");
        HttpClient client;

        public PersonaController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public async Task<ActionResult> Index()
        {
            List<PersonaViewModel> modelList = new List<PersonaViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/personas").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<PersonaViewModel>>(data);
            }
            return View(modelList);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(PersonaViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/personas", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Borrar(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/personas/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
