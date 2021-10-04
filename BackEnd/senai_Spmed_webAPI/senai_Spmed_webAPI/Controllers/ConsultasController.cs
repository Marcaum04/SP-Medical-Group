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
    }
}
