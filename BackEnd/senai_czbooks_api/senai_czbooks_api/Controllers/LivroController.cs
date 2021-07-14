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
    public class LivroController : ControllerBase
    {

        private ILivroRepository _livroRepository { get; set; }

        public LivroController()
        {
            _livroRepository = new LivroRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_livroRepository.Listar());
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
                return Ok(_livroRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Livro novoLivro)
        {
            try
            {
                // Faz a chamada para o método
                _livroRepository.Cadastrar(novoLivro);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Livro livroAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _livroRepository.Atualizar(id, livroAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _livroRepository.Deletar(id);

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
