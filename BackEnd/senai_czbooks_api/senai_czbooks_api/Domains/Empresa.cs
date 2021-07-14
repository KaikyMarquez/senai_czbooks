using System;
using System.Collections.Generic;

#nullable disable

namespace senai_czbooks_api.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
