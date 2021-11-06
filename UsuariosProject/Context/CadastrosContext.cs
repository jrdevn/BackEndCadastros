using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosProject.Models;

namespace UsuariosProject.Context
{
    public class CadastrosContext : DbContext
    {
        public CadastrosContext(DbContextOptions<CadastrosContext> options) : base (options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
    }
}
