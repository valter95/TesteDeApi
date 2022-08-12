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
        // Criado a lista para realização de teste pelo postman, para ver a chegada e retorno das requisições
        private static List<Usuario> usuarios = new List<Usuario>();

        [HttpPost]
        public void CadastraUsuario([FromBody] Usuario usuario) 
        {
            //Criando um teste para ver se esta chegando ao metodo
            usuarios.Add(usuario);
            Console.WriteLine(usuario.Nome);
            Console.WriteLine(usuario.DataNascimento);
        }

        [HttpGet("{id}")]
        public Usuario RecuperaUsuario(int id)
        {
            //Testes Realizados para ver a devolução da requisição/dado
            foreach (Usuario u in usuarios)
            {
                if(u.IdUsuario == id)
                return u;
            }

            return null;
        }
    }
}
