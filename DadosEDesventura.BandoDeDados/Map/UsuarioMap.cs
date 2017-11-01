using DadosEDesventuras.BancoDeDados.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosEDesventura.BancoDeDados.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            /*O método ToTable define qual o nome que será
           dado a tabela no banco de dados*/
           ToTable("Usuarios");
           //Define qual campo é a chave primaria da tabela
           HasKey(tabela => new { tabela.ID });                        

           Property(tabela => tabela.Login).HasMaxLength(12).IsRequired();
           Property(tabela => tabela.Senha).HasMaxLength(20).IsRequired();
        }
    }
}
