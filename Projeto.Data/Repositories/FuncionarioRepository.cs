using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace Projeto.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        //atributo
        private readonly string connectionString;

        //construtor para receber o valor da connectionString
        public FuncionarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Funcionario obj)
        {
            var query = "insert into Funcionario(IdFuncionario, Nome, Email, DataAdmissao, Salario, Ativo, DataCriacao, DataUltimaAlteracao) "
                        + "values(@IdFuncionario, @Nome, @Email, @DataAdmissao, @Salario, @Ativo, @DataCriacao, @DataUltimaAlteracao)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Alterar(Funcionario obj)
        {
            var query = "update Funcionario set "
                            + "Nome = @Nome, "
                            + "Email = @Email, "
                            + "DataAdmisao = @DataAdmissao, "
                            + "DataUltimaAlteracao = GetDate() "
                      + "where IdFuncionario = @IdFuncionario";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Excluir(Funcionario obj)
        {
            var query = "update Funcionario set Ativo = 0 where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Funcionario> Consultar(string nome, bool ativo)
        {
            var query = "select * from Funcionario where Nome like @Nome and Ativo = @Ativo";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query, new { Nome = $"{nome}", Ativo = ativo }).ToList();
            }
        }

        public Funcionario ObterPorId(Guid id)
        {
            var query = "select * from Funcionario where Ativo = 1 and IdFuncionario = @IdFuncionario";

            using (var connection =  new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query, new { IdFuncionario = id }).FirstOrDefault();
            }
        }

        public List<Funcionario> Consultar()
        {
            var query = "select * from Funcionario where Ativo = 1";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }

    }
}
