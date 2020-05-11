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
            var query = "select * from Usuario";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>(query).ToList();
            }
        }

        public Usuario Consultar(string email)
        {
            var query = "select * from Usuario where Email = @Email";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>(query, new { Email = email }).FirstOrDefault();
            }
        }

        public Usuario Consultar(string email, string senha)
        {
            var query = "select * from Usuario where Email = @Email and Senha = @Senha";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>(query, new { Email = email, Senha = senha }).FirstOrDefault();
            }
        }

        public Usuario ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
