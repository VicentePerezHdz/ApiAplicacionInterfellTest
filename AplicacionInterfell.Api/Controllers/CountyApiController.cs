using AplicacionInterfell.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AplicacionInterfell.Bussiness;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AplicacionInterfell.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyApiController : ControllerBase
    {


        CountyBL BL = new CountyBL();

        // GET: api/<CountyApiController>
        [HttpPost]
        public string InsertCounty(County county)
        {
            string mensaje = string.Empty;
            try
            {
                mensaje = BL.Insertar(county).ToString();
                return mensaje;
            }
            catch (Exception e)
            {
                return mensaje;
            }
        }

        // GET api/<CountyApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        

        

        // DELETE api/<CountyApiController>/5
        [HttpDelete("{id}")]
        public string  Delete(int id)
        {
            string mensaje = string.Empty;
            try
            {
                mensaje = BL.Eliminar(id);
                return mensaje;
            }
            catch (Exception e) 
            {
                return mensaje;        
            }


        }
    }
}
