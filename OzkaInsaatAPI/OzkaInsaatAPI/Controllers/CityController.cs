using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OzkaInsaat.Bll.Abstract;
using OzkaInsaat.Entity.Base;
using OzkaInsaat.Entity.DtoModels;
using OzkaInsaat.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzkaInsaatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService service;
        public CityController(ICityService service)
        {
            this.service = service;
        }
        [HttpGet]
        public Response<List<City>> Get()
        {
            Response<List<City>> response = new Response<List<City>>();
            response.Message = "İşlem Başarılı.";
            response.StatusCode = 1;
            response.Data = service.TGetList();
            if (response.Data == null || response.Data.Count <= 0)
            {
                response.Message = "Kayıtlı Veri Bulunamadı!";
                response.StatusCode = 0;
            }
            return response;
        }
        [HttpGet("{id}")]
        public Response<City> Get(int id)
        {
            Response<City> response = new Response<City>();
            response.Message = "İşlem Başarılı.";
            response.StatusCode = 1;
            response.Data = service.TgetItemByID(id);
            if (response.Data == null)
            {
                response.Message = "Kayıtlı Veri Bulunamadı!";
                response.StatusCode = 0;
            }
            return response;
        }
        [HttpPost]
        public Response<City> Post([FromBody] City city)
        {
            Response<City> response = new Response<City>();
            response.Message = "İşlem Başarılı.";
            response.StatusCode = 1;
            int newID = service.TAdd(city);
            if (newID != null && newID != 0)
            {
                response.Data = service.TgetItemByID(city.Id);
            }
            else
            {
                response.Message = "İşlem Başarısız!";
                response.StatusCode = 0;
            }
            return response;
        }
        [HttpPut]
        public Response<City> Put([FromBody] City city)
        {
            Response<City> response = new Response<City>();
            response.Message = "İşlem Başarılı.";
            response.StatusCode = 1;
            response.Data = service.TgetItemByID(city.Id);
            if (response.Data != null)
            {
                service.TUpdate(city);
                response.Data = service.TgetItemByID(city.Id);
            }
            else
            {
                response.Message = "Kayıtlı Veri Bulıunamadı!";
                response.StatusCode = 0;
            }
            return response;
        }
        [HttpDelete]
        public Response<City> Delete([FromBody] City city)
        {
            Response<City> response = new Response<City>();
            response.Message = "İşlem Başarılı.";
            response.StatusCode = 1;
            response.Data = service.TgetItemByID(city.Id);
            if (response.Data != null)
            {
                service.TDelete(city);
                response.Data = service.TgetItemByID(city.Id);
                if (response.Data != null)
                {
                    response.Message = "İşlem Başarısız!";
                    response.StatusCode = 0;
                }
            }
            else
            {
                response.Message = "Kayıtlı Veri Bulıunamadı!";
                response.StatusCode = 0;
            }
            return response;
        }
    }
}
