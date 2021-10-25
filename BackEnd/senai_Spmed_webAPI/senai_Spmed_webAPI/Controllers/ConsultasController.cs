using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_Spmed_webAPI.Domains;
using senai_Spmed_webAPI.Interfaces;
using senai_Spmed_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Spmed_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface
        /// </summary>
        private IConsultaRepository _consultaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações feitas no repositório
        /// </summary>
        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas as Consultas existentes
        /// </summary>
        /// <returns>Uma lista de consultas com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_consultaRepository.Listar());
        }

        /// <summary>
        /// Busca uma consulta pelo seu id
        /// </summary>
        /// <param name="idConsulta">id da consulta a ser buscada</param>
        /// <returns>Uma consulta encontrada com o status code 200 - Ok</returns>
        [HttpGet("{idConsulta}")]
        public IActionResult BuscarPorId(int idConsulta)
        {
            Consulta ConsultaBuscada = _consultaRepository.BuscarPorId(idConsulta);

            if (ConsultaBuscada == null)
            {
                return NotFound("A Consulta informada não existe!");
            }
            return Ok(ConsultaBuscada);
        }

        /// <summary>
        /// Cadastra uma Consulta
        /// </summary>
        /// <param name="novaConsulta">Consulta a ser cadastrada</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Consulta novaConsulta)
        {
            _consultaRepository.Cadastrar(novaConsulta);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="consultaAtualizada">Objeto com as novas informações da Consulta e o id da consulta a ser atualizada</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpPut]
        public IActionResult Atualizar(Consulta consultaAtualizada)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarPorId(consultaAtualizada.IdConsulta);
                if (consultaBuscada != null)
                {
                    _consultaRepository.Atualizar(consultaAtualizada);
                    return StatusCode(204);
                }
                else
                {
                    return BadRequest(new { mensagem = "A Consulta informada não existe" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="idConsulta">id da Consulta a ser deletada</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("{idConsulta}")]
        public IActionResult Deletar(int idConsulta)
        {
            _consultaRepository.Deletar(idConsulta);

            return StatusCode(204);
        }
    }
}
