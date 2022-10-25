using ChallengeAPI.Data;
using ChallengeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private AppDbContext context;

        //inicializanodo o nosso context 
        public UsuarioController(AppDbContext context)
        {
            this.context = context;
        }

        // Criado a lista para realização de teste pelo postman, para ver a chegada e retorno das requisições
        private static List<Usuario> usuarios = new List<Usuario>();

        [HttpPost]
        public IActionResult CadastraUsuario([FromBody] Usuario usuario) 
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            
            return CreatedAtAction(nameof(RecuperaUsuario), new { Id = usuario.IdUsuario }, usuario);
        }

        [HttpGet]
        public IActionResult RecuperarUsuario()
        {
            //utilizado o context para resgatar e salvar as informações no banco;
            return Ok(context.Usuarios);
        }

        [HttpGet("{id}")]
        public  IActionResult RecuperaUsuario(int id)
        {
            Usuario usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario != null)
                return Ok(usuario);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaUsuario(int id, [FromBody] Usuario usuario)
        {
            Usuario user = context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            user.Nome = usuario.Nome;
            user.DataNascimento = usuario.DataNascimento;
            context.Update(user);
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
           Usuario user = context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

            context.Remove(user);
            context.SaveChanges();
            return Ok();
        }
    }
}
