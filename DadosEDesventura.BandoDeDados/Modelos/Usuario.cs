using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DadosEDesventuras.BancoDeDados.Modelos
{
    public class Usuario
    {
        public int ID { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }
    }
}