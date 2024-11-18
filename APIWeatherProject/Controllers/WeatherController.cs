using APIWeatherProject.Context;
using APIWeatherProject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWeatherProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        WeatherContext context = new WeatherContext();

        [HttpGet]
        public IActionResult WeatherCityList()
        {
            var values = context.Cities.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateWeatherCity(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return Ok("Şehir Bilgileri Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            context.Cities.Remove(value);
            context.SaveChanges();
            return Ok("Şehir Bilgileri Silindi");
        }

        [HttpPut]
        public IActionResult UpdateWeatherCity(City city)
        {
            var value = context.Cities.Find(city.CityID);
            value.CityName= city.CityName;
            value.Detail= city.Detail;
            value.Temp= city.Temp;
            value.Country = city.Country;
            context.SaveChanges();
            return Ok("Şehir Bilgileri Güncellendi");


        }

        [HttpGet("{id}")]
        public IActionResult GetByIdWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            return Ok(value);
        }

        [HttpGet("TotalCityCount")]
        public IActionResult TotalCityCount()
        {
            var value =context.Cities.Count();
            return Ok(value);
        }

        [HttpGet("MaxTempCityName")]
        public IActionResult MaxTempCityName()
        {
            var value = context.Cities.OrderByDescending(x => x.Temp).Select(x => x.CityName).FirstOrDefault();
            return Ok(value);
        }
        [HttpGet("MinTempCityName")]
        public IActionResult MinTempCityName()
        {
            var value = context.Cities.OrderBy(x => x.Temp).Select(x => x.CityName).FirstOrDefault();
            return Ok(value);
        }
    }
}
