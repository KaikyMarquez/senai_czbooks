using Microsoft.EntityFrameworkCore;
using senai_czbooks_api.Contexts;
using senai_czbooks_api.Domains;
using senai_czbooks_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czbooks_api.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        CzBooksContext ctx = new CzBooksContext();
        public void Atualizar(int id, Livro livroAtualizado)
        {

            Livro livroBuscado = ctx.Livros.Find(id);

            if (livroAtualizado.Titulo != null)
            {
                livroBuscado.Titulo = livroAtualizado.Titulo;
            }

            if (livroAtualizado.Sinopse != null)
            {
                livroBuscado.Sinopse = livroAtualizado.Sinopse;
            }

            if (livroAtualizado.DataPublicacao <= DateTime.Today)
            {
                livroBuscado.DataPublicacao = livroAtualizado.DataPublicacao;
            }

            if (livroAtualizado.Preco != null)
            {
                livroBuscado.Preco = livroAtualizado.Preco;
            }

            ctx.Livros.Update(livroBuscado);

            ctx.SaveChanges();
        }

        public Livro BuscarPorId(int id)
        {
            return ctx.Livros.FirstOrDefault(i => i.IdLivro == id);
        }

        public void Cadastrar(Livro novoLivro)
        {
            ctx.Livros.Add(novoLivro);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Livros.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Livro> Listar()
        {
            return ctx.Livros.Include(d => d.IdCategoriaNavigation).Include(d => d.IdUsuarioNavigation).ToList();
        }
    }
}
