using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UsuariosProject.Context;

namespace UsuariosProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SexosController 
    {
        private CadastrosContext _cadastrosContext;
        public SexosController(CadastrosContext cadastrosContext)
        {
            _cadastrosContext = cadastrosContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var generos = _cadastrosContext.Sexo.ToList();

                return new ObjectResult(JsonConvert.SerializeObject(generos));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }

        }
    }
}
