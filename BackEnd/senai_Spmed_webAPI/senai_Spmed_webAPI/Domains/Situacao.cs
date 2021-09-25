using System;
using System.Collections.Generic;

#nullable disable

namespace senai_Spmed_webAPI.Domains
{
    /// <summary>
    /// Classe que representa entidade (tabela) de Situacoes
    /// </summary>
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public byte IdSituacao { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
