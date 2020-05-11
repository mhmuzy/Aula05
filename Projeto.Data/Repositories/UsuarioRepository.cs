using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System.Data.SqlClient;
using System.Linq;

namespace Projeto.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //atributo
        private readonly string connectionString;

        //construtor para receber o valor da connectionstring
        public UsuarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Usuario obj)
        {
            var query = "insert into Usuario(Nome, Email, Senha, Foto, DataCriacao, IdPerfil) "
                        + "values(@Nome, @Email, @Senha, @Foto, @DataCriacao, @IdPerfil)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Alterar(Usuario obj)
        {
            var query = "update Usuario set Nome = @Nome, Email = @Email, Foto = @Foto, IdPerfil = @IdPerfil "
                      + "where IdUsuario = @IdUsuario";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Excluir(Usuario obj)
        {
            var query = "delete from Usuario where IdUsuario = @IdUsuario";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Usuario> Consultar()
        {
            var query = "select * from Usuario u inner join Perfil p "
                        + "on p.IdPerfil = u.IdPerfil";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query(query,
                    (Usuario u, Perfil p) =>
                    {
                        u.Perfil = p;
                        return u;
                    },
                    splitOn: "IdPerfil")
                    .ToList();
            }
        }

        public Usuario Consultar(string email)
        {
            var query = "select * from Usuario u inner join Perfil p "
                      + "on p.IdPerfil = u.IdPerfil "
                      + "where Email = @Email";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query(query,
                    (Usuario u, Perfil p) =>
                    {
                        u.Perfil = p;
                        return u;
                    },
                    new { Email = email },
                    splitOn: "IdPerfil")
                    .FirstOrDefault();
            }
        }

        public Usuario Consultar(string email, string senha)
        {
            var query = "select * from Usuario u inner join Perfil p "
                       + "on p.IdPerfil = u.IdPerfil "
                       + "where Email = @Email and Senha = @Senha";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query(query,
                    (Usuario u, Perfil p) =>
                    {
                        u.Perfil = p;
                        return u;
                    },
                    new { Email = email, Senha = senha },
                    splitOn: "IdPerfil")
                    .FirstOrDefault();
            }
        }

        public Usuario ObterPorId(Guid id)
        {
            var query = "select * from Usuario u inner join Perfil p "
                      + "on p.IdPerfil = u.IdPerfil "
                      + "where IdUsuario = @IdUsuario";

            using (var connection =  new SqlConnection(connectionString))
            {
                return connection.Query(query,
                    (Usuario u, Perfil p) =>
                    {
                        u.Perfil = p;
                        return u;
                    },
                    new { IdUsuario = id },
                    splitOn: "IdPerfil")
                    .FirstOrDefault();
            }
        }
    }
}
