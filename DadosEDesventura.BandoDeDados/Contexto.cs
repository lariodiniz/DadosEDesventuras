using DadosEDesventura.BancoDeDados.Map;
using DadosEDesventuras.BancoDeDados.Modelos;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DadosEDesventura.BancoDeDados
{
    public class Contexto : DbContext
    {
        //Define tabelas.      
        public virtual DbSet<Usuario> Usuarios { get; set; }

      
        public Contexto(string strincConexao) : base(strincConexao)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Contexto, Configuration>());
        }

        public Contexto() : base()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Contexto, Configuration>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove a pluralização padrão do Etity Framework que é em ingles.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*Desabilita o delete em cascata em relacionamentos 1:N evitando
                 ter registros filhos     sem registros pai*/
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Mesma configuração, porém em relacionamenos N:N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            /*Toda propriedade do tipo string na entidade POCO
             seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            /*Toda propriedade do tipo string na entidade POCO seja configurado como VARCHAR (150) no banco de dados */
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(150));

            /*Define que toda propriedade que contenha "_ID" como "SIS_ID" por exemplo, seja dada como
                chave primária, caso não tenha sido especificado*/
            modelBuilder.Properties()
               .Where(p => p.Name.Substring(p.Name.Length - 2, 2) == "ID")
               .Configure(p => p.IsKey());

            //Constroi Tabelas
            //Controles
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
