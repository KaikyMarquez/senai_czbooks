using System;
using System.Collections.Generic;

#nullable disable

namespace senai_czbooks_api.Domains
{
    public partial class Categorium
    {
        public Categorium()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
