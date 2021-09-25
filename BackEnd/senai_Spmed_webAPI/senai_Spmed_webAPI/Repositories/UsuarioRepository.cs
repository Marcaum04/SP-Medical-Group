using senai_Spmed_webAPI.Context;
using senai_Spmed_webAPI.Domains;
using senai_Spmed_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Spmed_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpmedContext ctx = new SpmedContext();

        public void Atualizar(Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(usuarioAtualizado.IdUsuario);

            if (usuarioAtualizado.NomeUsuario != null)
            {
                usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            }

            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            if (usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
