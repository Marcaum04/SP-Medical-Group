using System;
using System.Collections.Generic;

#nullable disable

namespace senai_Spmed_webAPI.Domains
{
    /// <summary>
    /// Classe que representa entidade (tabela) de TiposUsuario
    /// </summary>
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoUsuario { get; set; }
        public string TituloTipoUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
