using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Entities
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid IdPerfil { get; set; }

        #region Relacionamentos

        public Perfil Perfil { get; set; }

        #endregion
    }
}
