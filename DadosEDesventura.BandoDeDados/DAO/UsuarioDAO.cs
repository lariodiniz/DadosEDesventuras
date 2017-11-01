using DadosEDesventura.BancoDeDados;
using DadosEDesventuras.BancoDeDados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DadosEDesventuras.BancoDeDados.DAO
{
    public class UsuariosDAO
    {
        public void Adiciona(Usuario usuario)
        {
            using (var context = new Contexto())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public IList<Usuario> Lista()
        {
            using (var contexto = new Contexto())
            {
                return contexto.Usuarios.ToList();
            }
        }

        public Usuario BuscaPorId(int id)
        {
            using (var contexto = new Contexto())
            {
                return contexto.Usuarios.Find(id);
            }
        }

        public void Atualiza(Usuario usuario)
        {
            using (var contexto = new Contexto())
            {
                contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Usuario Busca(string login, string senha)
        {
            using (var contexto = new Contexto())
            {
                return contexto.Usuarios.FirstOrDefault(u => u.Login == login && u.Senha == senha);
            }
        }
    }
}