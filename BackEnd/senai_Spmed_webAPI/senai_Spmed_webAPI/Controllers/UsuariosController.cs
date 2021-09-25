﻿using Microsoft.AspNetCore.Http;
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
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações feitas no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Usuário existentes
        /// </summary>
        /// <returns>Uma lista de usuários com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um usuário pelo seu id
        /// </summary>
        /// <param name="idUsuario">id do usuário a ser buscado</param>
        /// <returns>Um usuário encontrado com o status code 200 - Ok</returns>
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            return Ok(_usuarioRepository.BuscarPorId(idUsuario));
        }
        
        /// <summary>
        /// Cadastra um Usuário
        /// </summary>
        /// <param name="novoUsuario">Usuario a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="usuarioAtualizado">Objeto com as novas informações do Usuário e o id do usuário a ser atualizado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpPut]
        public IActionResult Atualizar(Usuario usuarioAtualizado)
        {
            _usuarioRepository.Atualizar(usuarioAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="idUsuario">id do Usuário a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _usuarioRepository.Deletar(idUsuario);

            return StatusCode(204);
        }
    }

}
