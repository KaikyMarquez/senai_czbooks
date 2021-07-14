using senai_czbooks_api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czbooks_api.Interfaces
{
    interface IEmpresaRepository
    {

        List<Empresa> Listar();

        Empresa BuscarPorId(int id);

        void Cadastrar(Empresa novaEmpresa);

        void Atualizar(int id, Empresa empresaAtualizada);

        void Deletar(int id);
    }
}

