using senai_czbooks_api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czbooks_api.Interfaces
{
    interface ICategoriaRepository
    {

        List<Categorium> Listar();

        Categorium BuscarPorId(int id);

        void Cadastrar(Categorium novaCategoria);

        void Atualizar(int id, Categorium categoriaAtualizada);

        void Deletar(int id);
    }
}

