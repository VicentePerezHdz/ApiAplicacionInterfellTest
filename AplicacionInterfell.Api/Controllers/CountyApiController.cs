using AplicacionInterfell.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AplicacionInterfell.Bussiness;
using Microsoft.Extensions.Configuration;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AplicacionInterfell.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyApiController : ControllerBase
    {
        CountyBL BL = new CountyBL();
        private IConfiguration Configuration;


        public CountyApiController(IConfiguration _configuration)
        {
            Configuration = _configuration;
            BL.CadenaConexion = this.Configuration.GetConnectionString("MyConn");

        }

        [HttpGet]
        [Route("ListadoCounty")]
        public IActionResult ObtenerCounty()
        {
            try
            {
                //BL.Obtener();
                return Ok(BL.Obtener());
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        //CountyBL BL = new CountyBL();

        // GET: api/<CountyApiController>
        [HttpPost]
        public string InsertCounty(County county)
        {
            string mensaje = string.Empty;
            try
            {
                mensaje = "Ultimo Id Asignado" + BL.Insertar(county).ToString();
                return mensaje;
            }
            catch (Exception e)
            {
                mensaje = "Ocurrio lo siguiente" + e.Message;
                return mensaje;
            }
        }

        // GET api/<CountyApiController>/5
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            try
            {
                //BL.Obtener();
                return Ok(BL.Obtener().Where(x => x.county_fips == id).FirstOrDefault());
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }





        // DELETE api/<CountyApiController>/5
        [HttpPost]
        [Route("Eliminar")]

        public string Delete(int id)
        {
            string mensaje = string.Empty;
            try
            {
                mensaje = "Se elimino el siguiente registros" + BL.Eliminar(id) + id;
                return mensaje;
            }
            catch (Exception e)
            {
                mensaje = "Ocurrio lo siguiente" + e.Message;
                return mensaje;
            }


        }
    }
}
