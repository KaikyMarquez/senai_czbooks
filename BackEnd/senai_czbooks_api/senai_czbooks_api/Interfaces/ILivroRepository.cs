using senai_czbooks_api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czbooks_api.Interfaces
{
    interface ILivroRepository
    {

        List<Livro> Listar();

        Livro BuscarPorId(int id);

        void Cadastrar(Livro novoLivro);

        void Atualizar(int id, Livro livroAtualizado);

        void Deletar(int id);
    }
}
