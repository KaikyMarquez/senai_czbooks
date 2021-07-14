using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_czbooks_api.Domains;
using senai_czbooks_api.Interfaces;
using senai_czbooks_api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czbooks_api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "1")]
    public class TipoUsuarioController : ControllerBase
    {

        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipousuario)
        {
            try
            {
                // Faz a chamada para o método
                _tipoUsuarioRepository.Cadastrar(novoTipousuario);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _tipoUsuarioRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
