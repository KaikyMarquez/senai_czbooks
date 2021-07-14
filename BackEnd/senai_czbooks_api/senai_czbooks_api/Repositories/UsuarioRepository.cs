using senai_czbooks_api.Contexts;
using senai_czbooks_api.Domains;
using senai_czbooks_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czbooks_api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        CzBooksContext ctx = new CzBooksContext();
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

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

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(i => i.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string Usuario, string Senha)
        {
            return ctx.Usuarios.FirstOrDefault(login => login.Email == Usuario && login.Senha == Senha);
        }
    }
}
