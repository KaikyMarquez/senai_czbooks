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
    public class CategoriaController : ControllerBase
    {

        private ICategoriaRepository _categoriaRepository { get; set; }

        public CategoriaController()
        {
            _categoriaRepository = new CategoriaRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_categoriaRepository.Listar());
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
                return Ok(_categoriaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Categorium novaCategoria)
        {
            try
            {
                // Faz a chamada para o método
                _categoriaRepository.Cadastrar(novaCategoria);

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
        public IActionResult Put(int id, Categorium categoriaAtualizada)
        {
            try
            {
                // Faz a chamada para o método
                _categoriaRepository.Atualizar(id, categoriaAtualizada);

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
                _categoriaRepository.Deletar(id);

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
