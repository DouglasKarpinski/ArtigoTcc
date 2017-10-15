using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Login
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int IdGrupoEconomico { get; set; }
    }
}
