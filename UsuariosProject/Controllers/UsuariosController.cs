using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosProject.Context;
using UsuariosProject.Models;

namespace UsuariosProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuariosController
    {

        private CadastrosContext _cadastrosContext;
        public UsuariosController(CadastrosContext cadastrosContext)
        {
            _cadastrosContext = cadastrosContext;
        }
        
        [HttpGet("getUsuarioById")]
        public async Task<IActionResult> GetUsuarioById([FromQuery] int id)
        {
            try
            {
                var usuario = _cadastrosContext.Usuario.Find(id);

                if (usuario == null)
                    return new BadRequestObjectResult("Usuário não encontrado!");
                else
                  return new ObjectResult(JsonConvert.SerializeObject(usuario));

            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] bool ativo)
        {
            try
            {
                var usuarios = _cadastrosContext.Usuario.Where(x => x.Ativo == ativo).OrderBy(x => x.Nome).ToList();
                

                return new ObjectResult(JsonConvert.SerializeObject(usuarios));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }

        }

        [HttpGet("getComDescricao")]
        public async Task<IActionResult> GetComDescricao([FromQuery] string nome, [FromQuery] bool ativo)
        {
            try
            {

                var usuarios = _cadastrosContext.Usuario.Where(x => x.Nome.Contains(nome) && x.Ativo == ativo).
                                                         OrderBy( x => x.Nome).ToList();

                return new ObjectResult(JsonConvert.SerializeObject(usuarios));

            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveUsuario([FromBody] Usuario usuario)
        {
            try
            {
                usuario.Ativo = true;
                _cadastrosContext.Usuario.Add(usuario);
                _cadastrosContext.SaveChanges();

                return new OkResult();

            } 
            catch (Exception e )
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var _usuario = _cadastrosContext.Usuario.Find(usuario.UsuarioId);
                if (_usuario != null)
                {
                    _usuario.Nome = usuario.Nome;
                    _usuario.Email = usuario.Email;
                    _usuario.Ativo = usuario.Ativo;
                    _usuario.Senha = usuario.Senha;
                    _usuario.SexoId = usuario.SexoId;
                    _usuario.DataNascimento = usuario.DataNascimento;
                    _cadastrosContext.Entry(_usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _cadastrosContext.SaveChanges();
                }
                else
                    new BadRequestObjectResult("Usuario não encontrado para edição!");

                return new OkResult();

            }
            catch (Exception)
            {
                return new NoContentResult();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario([FromQuery] int id)
        {
            try
            {
                var _usuario = _cadastrosContext.Usuario.Find(id);
                if (_usuario != null)
                {
                    _cadastrosContext.Usuario.Remove(_usuario);
                    _cadastrosContext.SaveChanges();

                }
                else
                {
                    new BadRequestObjectResult("Usuario não encontrado ou já deletado!");
                }

                return new OkResult();

            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
