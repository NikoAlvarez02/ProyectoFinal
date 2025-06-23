using LoginMVCClase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LoginMVCClase.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ForExecution(string nombre, string apellido, string profesion)
        {
            List<PersonaModel> list = new List<PersonaModel>();
            if(nombre =="error")
            { ViewBag.Error = "ERROR"; }
            else { 
                for (int i = 0; i < 3; i++)
                {
                    list.Add(new PersonaModel
                    {
                        nombre = nombre,
                        apellido = apellido,
                        profesion = profesion
                    });
                }

                ViewBag.Persona = list;
            }

            
            return View("Index");
        }
    }
}
