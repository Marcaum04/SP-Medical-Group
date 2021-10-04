using Microsoft.EntityFrameworkCore;
using senai_Spmed_webAPI.Context;
using senai_Spmed_webAPI.Domains;
using senai_Spmed_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Spmed_webAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpmedContext ctx = new SpmedContext();
        public void AdicionarDescricao(int idConsulta, string descricao)
        {
            throw new NotImplementedException();
        }

        public void AlterarStatus(int idConsulta, int idSituacao)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = BuscarPorId(consultaAtualizada.IdConsulta);

            if (consultaAtualizada.IdMedico != 0)
            {
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
            }

            if (consultaAtualizada.IdPaciente != 0)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
            }

            if (consultaAtualizada.IdSituacao != 0)
            {
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
            }

            consultaBuscada.DataeHora = consultaAtualizada.DataeHora;

            if (consultaAtualizada.Descricao != null)
            {
                consultaBuscada.Descricao = consultaAtualizada.Descricao;
            }
        }

        public Consulta BuscarPorId(int idConsulta)
        {
            return ctx.Consulta
                .Select(c => new Consulta()
                {
                    IdConsulta = c.IdConsulta,
                    IdMedico = c.IdMedico,
                    IdMedicoNavigation = new Medico()
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        IdUsuarioNavigation = new Usuario()
                        {
                            IdUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario,
                            NomeUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                            Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email,
                            Senha = c.IdMedicoNavigation.IdUsuarioNavigation.Senha
                        },
                        IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                        IdEspecialidadeNavigation = new Especialidade()
                        {
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                            Descricao = c.IdMedicoNavigation.IdEspecialidadeNavigation.Descricao
                        },
                        Crmv = c.IdMedicoNavigation.Crmv
                    },
                    IdPaciente = c.IdPaciente,
                    IdPacienteNavigation = new Paciente()
                    {
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        IdUsuario = c.IdPacienteNavigation.IdUsuario,
                        IdUsuarioNavigation = new Usuario()
                        {
                            IdUsuario = c.IdPacienteNavigation.IdUsuarioNavigation.IdUsuario,
                            NomeUsuario = c.IdPacienteNavigation.IdUsuarioNavigation.NomeUsuario,
                            Email = c.IdPacienteNavigation.IdUsuarioNavigation.Email,
                            Senha = c.IdPacienteNavigation.IdUsuarioNavigation.Senha
                        },
                        Telefone = c.IdPacienteNavigation.Telefone,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                        Endereco = c.IdPacienteNavigation.Endereco,
                        Rg = c.IdPacienteNavigation.Rg,
                        Cpf = c.IdPacienteNavigation.Cpf
                    },
                    IdSituacao = c.IdSituacao,
                    IdSituacaoNavigation = new Situacao()
                    {
                        IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                        Descricao = c.IdSituacaoNavigation.Descricao
                    }
                }).FirstOrDefault(c => c.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
           ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            Consulta consultaBuscada = BuscarPorId(idConsulta);

            ctx.Consulta.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consulta
                .Select(c => new Consulta() { 
                    IdConsulta = c.IdConsulta,
                    IdMedico = c.IdMedico,
                    IdMedicoNavigation = new Medico()
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        IdUsuarioNavigation = new Usuario()
                        {
                            IdUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario,
                            NomeUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                            Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email,
                            Senha = c.IdMedicoNavigation.IdUsuarioNavigation.Senha
                        },
                        IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                        IdEspecialidadeNavigation = new Especialidade()
                        {
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                            Descricao = c.IdMedicoNavigation.IdEspecialidadeNavigation.Descricao
                        },
                        Crmv = c.IdMedicoNavigation.Crmv
                    },
                    IdPaciente = c.IdPaciente,
                    IdPacienteNavigation = new Paciente()
                    {
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        IdUsuario = c.IdPacienteNavigation.IdUsuario,
                        IdUsuarioNavigation = new Usuario()
                        {
                            IdUsuario = c.IdPacienteNavigation.IdUsuarioNavigation.IdUsuario,
                            NomeUsuario = c.IdPacienteNavigation.IdUsuarioNavigation.NomeUsuario,
                            Email = c.IdPacienteNavigation.IdUsuarioNavigation.Email,
                            Senha = c.IdPacienteNavigation.IdUsuarioNavigation.Senha
                        },
                        Telefone = c.IdPacienteNavigation.Telefone,
                        DataNascimento = c.IdPacienteNavigation.DataNascimento,
                        Endereco = c.IdPacienteNavigation.Endereco,
                        Rg = c.IdPacienteNavigation.Rg,
                        Cpf = c.IdPacienteNavigation.Cpf
                    },
                    IdSituacao = c.IdSituacao,
                    IdSituacaoNavigation = new Situacao()
                    {
                        IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                        Descricao = c.IdSituacaoNavigation.Descricao
                    }
                })
                .ToList();
        }

        public List<Consulta> ListarMinhas(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
