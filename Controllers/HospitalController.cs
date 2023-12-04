using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Examen.Models;

namespace Proyecto_Examen.Controllers
{
    public class HospitalController : Controller
    {

        ClaseConexion conexion = new ClaseConexion();

        public IActionResult Index()
        {
            IEnumerable<Hospital> lista = conexion.getPacientes();
            return View(lista);
           
        }

        public IActionResult Create()
        {
            return View();
        }

        //POST /Alumnos/Create
        [HttpPost]
        public IActionResult Create(Hospital pac)
        {
            int filasAfectadas = conexion.addPaciente(pac);
            if (filasAfectadas > 0)
                Console.WriteLine("Se agregó a la bd");
            else
                Console.WriteLine("Hubo un error");

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Hospital pac = conexion.getPaciente(id);
            return View(pac);
        }
    }
}
