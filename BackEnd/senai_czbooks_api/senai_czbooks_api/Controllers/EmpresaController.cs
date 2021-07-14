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
    public class EmpresaController : ControllerBase
    {

        private IEmpresaRepository _empresaRepository { get; set; }

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_empresaRepository.Listar());
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
                return Ok(_empresaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [HttpPost]
        public IActionResult Post(Empresa novaEmpresa)
        {
            try
            {
                // Faz a chamada para o método
                _empresaRepository.Cadastrar(novaEmpresa);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Empresa empresaAtualizada)
        {
            try
            {
                // Faz a chamada para o método
                _empresaRepository.Atualizar(id, empresaAtualizada);

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
                _empresaRepository.Deletar(id);

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
