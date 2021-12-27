using Microsoft.AspNetCore.Mvc;
using System;
using XtraMileTask2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XtraMileTask2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrcController : ControllerBase
    {
        CRCRepo repo = new CRCRepo();
        // GET: api/<CRCController>
        [HttpGet]
        public IActionResult GetCountry()
        {
            try
            {
                var result = repo.GetAllCountry();
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("region/{id:int}")]
        public IActionResult GetRegion(int id)
        {
            try
            {
                var result = repo.GetAllRegion(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("city/{id:int}")]
        public IActionResult GetCity(int id)
        {
            try
            {
                var result = repo.GetAllCity(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("ftc/{id:double}")]
        public IActionResult GetCelcius(double id)
        {
            try
            {
                Service service = new Service();
                var result = service.ToCelcius(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("dew/{temp:double}/{humi:int}")]
        public IActionResult GetDew(double temp, int humi)
        {
            try
            {
                Service service = new Service();
                var result = service.DewPoint(temp, humi);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
