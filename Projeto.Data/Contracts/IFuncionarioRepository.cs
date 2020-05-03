using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Entities;

namespace Projeto.Data.Contracts
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        List<Funcionario> Consultar(string nome, bool ativo);
        void Reativar(Guid idFuncionario);
    }
}
