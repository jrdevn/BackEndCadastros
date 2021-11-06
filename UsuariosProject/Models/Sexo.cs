using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosProject.Models
{
    public class Sexo
    {
        public virtual int SexoId { get; private set; }
        public virtual string Descricao { get; set; }
    }
}
