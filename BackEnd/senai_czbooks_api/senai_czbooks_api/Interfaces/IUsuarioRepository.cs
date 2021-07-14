using senai_czbooks_api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czbooks_api.Interfaces
{
    interface IUsuarioRepository
    {

        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int id, Usuario usuarioAtualizado);

        void Deletar(int id);

        Usuario Login(string Usuario, string Senha);
    }
}
