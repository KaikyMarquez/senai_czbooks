using senai_czbooks_api.Contexts;
using senai_czbooks_api.Domains;
using senai_czbooks_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czbooks_api.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        CzBooksContext ctx = new CzBooksContext();
        public void Atualizar(int id, Categorium categoriaAtualizada)
        {
            Categorium categoriaBuscada = ctx.Categoria.Find(id);

            if (categoriaAtualizada.NomeCategoria != null)
            {
                categoriaBuscada.NomeCategoria = categoriaAtualizada.NomeCategoria;
            }
        }

        public Categorium BuscarPorId(int id)
        {
            return ctx.Categoria.FirstOrDefault(i => i.IdCategoria == id);
        }

        public void Cadastrar(Categorium novaCategoria)
        {
            ctx.Categoria.Add(novaCategoria);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Categoria.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Categorium> Listar()
        {
            return ctx.Categoria.ToList();
        }
    }
}
