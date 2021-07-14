using senai_czbooks_api.Contexts;
using senai_czbooks_api.Domains;
using senai_czbooks_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czbooks_api.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        CzBooksContext ctx = new CzBooksContext();
        public void Atualizar(int id, Empresa empresaAtualizada)
        {
            Empresa empresaBuscada = ctx.Empresas.Find(id);

            if (empresaAtualizada.NomeFantasia != null)
            {
                empresaBuscada.NomeFantasia = empresaAtualizada.NomeFantasia;
            }

            if (empresaAtualizada.Endereco != null)
            {
                empresaBuscada.Endereco = empresaAtualizada.Endereco;
            }

            ctx.Empresas.Update(empresaBuscada);

            ctx.SaveChanges();
        }

        public Empresa BuscarPorId(int id)
        {

            return ctx.Empresas.FirstOrDefault(i => i.IdEmpresa == id);
        }

        public void Cadastrar(Empresa novaEmpresa)
        {
            ctx.Empresas.Add(novaEmpresa);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Empresas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Empresa> Listar()
        {
            return ctx.Empresas.ToList();
        }
    }
}
