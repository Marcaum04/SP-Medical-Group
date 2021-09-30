﻿using senai_Spmed_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Spmed_webAPI.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Busca por um usuário pelo seu ID
        /// </summary>
        /// <param name="idMedico">ID do usuário a ser buscado</param>
        /// <returns>Usuário encontrado</returns>
        Medico BuscarPorId(int idMedico);

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoMedico">Recebe os dados de um usuário cadastrado</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns> Uma lista de usuários</returns>
        List<Medico> Listar();

        /// <summary>
        /// Atualiza os dados de um usuário
        /// </summary>
        /// <param name="MedicoAtualizado">Recebe os novos dados do usuário</param>
        void Atualizar(Medico MedicoAtualizado);

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="idMedico"> ID do usuário a ser deletado</param>
        void Deletar(int idMedico);
    }
}
