using Microsoft.AspNetCore.Mvc;
using OzkaInsaat.EndPoints;
using OzkaInsaat.Entity.Base;
using OzkaInsaat.Entity.DtoModels;
using OzkaInsaat.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzkaInsaatWeb.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            Response<List<City>> model = EndPoints.GetAllCities();
            return View(model.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddCity model = new AddCity();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AddCity city)
        {
            Response<City> model = EndPoints.AddCity(city);
            if (model.StatusCode == 1)
                return RedirectToAction("Index");
            else
                return View(model.Data);
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            Response<City> model = EndPoints.GetCity(Id);
            return View(model.Data);
        }
        [HttpPost]
        public IActionResult Update(City city)
        {
            Response<City> model = EndPoints.UpdateCity(city);
            if (model.StatusCode == 1)
                return RedirectToAction("Index");
            else
                return View(model.Data);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            EndPoints.DeleteCity(EndPoints.GetCity(Id).Data);
            return RedirectToAction("Index");
        }
    }
}
