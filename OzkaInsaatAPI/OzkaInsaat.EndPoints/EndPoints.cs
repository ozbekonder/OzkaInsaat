using Newtonsoft.Json;
using OzkaInsaat.Common.APIConnection;
using OzkaInsaat.Entity.Base;
using OzkaInsaat.Entity.DtoModels;
using OzkaInsaat.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzkaInsaat.EndPoints
{
    public class EndPoints
    {
        static string URL = "https://localhost:44366/api/City";
        public static Response<List<City>> GetAllCities()
        {
            Response<List<City>> response = new Response<List<City>>();
            string responseString = APIConnectionFunctions.Connection(URL, "", ConnectionType.GET);
            response = JsonConvert.DeserializeObject<Response<List<City>>>(responseString);
            return response;
        }
        public static Response<City> GetCity(int Id)
        {
            string url = URL + "/" + Id;
            Response<City> response = new Response<City>();
            string responseString = APIConnectionFunctions.Connection(url, "", ConnectionType.GET);
            response = JsonConvert.DeserializeObject<Response<City>>(responseString);
            return response;
        }
        public static Response<City> AddCity(AddCity city)
        {
            Response<City> response = new Response<City>();
            string requestString = JsonConvert.SerializeObject(city);
            string responseString = APIConnectionFunctions.Connection(URL, requestString, ConnectionType.POST);
            response = JsonConvert.DeserializeObject<Response<City>>(responseString);
            return response;
        }
        public static Response<City> UpdateCity(City city)
        {
            Response<City> response = new Response<City>();
            string requestString = JsonConvert.SerializeObject(city);
            string responseString = APIConnectionFunctions.Connection(URL, requestString, ConnectionType.PUT);
            response = JsonConvert.DeserializeObject<Response<City>>(responseString);
            return response;
        }
        public static Response<City> DeleteCity(City city)
        {
            Response<City> response = new Response<City>();
            string requestString = JsonConvert.SerializeObject(city);
            string responseString = APIConnectionFunctions.Connection(URL, requestString, ConnectionType.DELETE);
            response = JsonConvert.DeserializeObject<Response<City>>(responseString);
            return response;
        }
    }
}
