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
    public class PerfilRepository : IPerfilRepository
    {
        //atributo
        private readonly string connectionString;

        //construtor para injeção de dependência (inicialização)
        public PerfilRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Perfil obj)
        {
            var query = "insert into Perfil(IdPerfil, Nome) values(@IdPerfil, @Nome)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Alterar(Perfil obj)
        {
            var query = "update Perfil set Nome = @Nome where IdPerfil = @IdPerfil";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Excluir(Perfil obj)
        {
            var query = "delete from Perfil where IdPerfil = @IdPerfil";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Perfil> Consultar()
        {
            var query = "select * from Perfil";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Perfil>(query).ToList();
            }
        }

        public Perfil Consultar(string nome)
        {
            var query = "select * from Perfil where Nome = @Nome";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Perfil>(query, new { Nome = nome }).FirstOrDefault();
            }
        }
        
        public Perfil ObterPorId(Guid id)
        {
            var query = "select * from Perfil where IdPerfil = @IdPerfil";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Perfil>(query, new { IdPerfil = id }).FirstOrDefault();
            }
        }
    }
}
