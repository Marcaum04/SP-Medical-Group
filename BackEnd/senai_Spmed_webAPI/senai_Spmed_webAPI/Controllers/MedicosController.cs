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
    public class MedicosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface
        /// </summary>
        private IMedicoRepository _medicoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações feitas no repositório
        /// </summary>
        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista todos os Médicos existentes
        /// </summary>
        /// <returns>Uma lista de médicos com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_medicoRepository.Listar());
        }

        /// <summary>
        /// Busca um médico pelo seu id
        /// </summary>
        /// <param name="idMedico">id do médico a ser buscado</param>
        /// <returns>Um médico encontrado com o status code 200 - Ok</returns>
        [HttpGet("{idMedico}")]
        public IActionResult BuscarPorId(int idMedico)
        {
            Medico medicoBuscado = _medicoRepository.BuscarPorId(idMedico);

            if (medicoBuscado == null)
            {
                return NotFound("O Medico informado não existe!");
            }
            return Ok(medicoBuscado);
        }

        /// <summary>
        /// Cadastra um Médico
        /// </summary>
        /// <param name="novoMedico">Médico a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            _medicoRepository.Cadastrar(novoMedico);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um médico existente
        /// </summary>
        /// <param name="medicoAtualizado">Objeto com as novas informações do Médico e o id do médico a ser atualizado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpPut]
        public IActionResult Atualizar(Medico medicoAtualizado)
        {
            try
            {
                Medico medicoBuscado = _medicoRepository.BuscarPorId(medicoAtualizado.IdMedico);
                if (medicoBuscado != null)
                {
                    if (medicoAtualizado != null)
                        _medicoRepository.Atualizar(medicoAtualizado);
                }
                else
                {
                    return BadRequest(new { mensagem = "O Médico informado não existe" });
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um médico
        /// </summary>
        /// <param name="idMedico">id do Médico a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("{idMedico}")]
        public IActionResult Deletar(int idMedico)
        {
            _medicoRepository.Deletar(idMedico);

            return StatusCode(204);
        }
    }
}
