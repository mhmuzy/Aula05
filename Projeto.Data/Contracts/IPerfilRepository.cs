using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Entities;

namespace Projeto.Data.Contracts
{
    public interface IPerfilRepository : IBaseRepository<Perfil>
    {
        //método para consultar 1 Perfil pelo nome
        Perfil Consultar(string nome);
    }
}
