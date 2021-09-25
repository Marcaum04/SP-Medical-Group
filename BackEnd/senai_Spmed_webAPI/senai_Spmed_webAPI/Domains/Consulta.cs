﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_Spmed_webAPI.Domains
{
    /// <summary>
    /// Classe que representa entidade (tabela) de Consultas
    /// </summary>
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public byte? IdSituacao { get; set; }
        public DateTime DataeHora { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
