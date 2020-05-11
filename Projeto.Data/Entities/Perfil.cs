using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Entities
{
    public class Perfil
    {
        public Guid IdPerfil { get; set; }
        public string Nome { get; set; }

        #region Relacionamentos

        public List<Usuario> Usuarios { get; set; }

        #endregion
    }
}
