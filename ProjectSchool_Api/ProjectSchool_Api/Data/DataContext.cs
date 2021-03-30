using Microsoft.EntityFrameworkCore;
using ProjectSchool_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool_Api.Data
{
    public class DataContext : DbContext
    {

        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
             
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
                    .HasData(
                        new Professor()
                        {
                            Id = 1,
                            Nome = "Adam"
                        },
                        new Professor()
                        {
                            Id = 2,
                            Nome = "Lilly"
                        },
                        new Professor()
                        {
                            Id = 3,
                            Nome = "Vanderlei"
                        }
                        
                        );

            builder.Entity<Aluno>()
                   .HasData(
                       new Aluno()
                       {
                           Id = 1,
                           Nome = "Marcus",
                           Sobrenome = "Fenix",
                           DataNasc = "02/06/1995",
                           ProfessorId = 1

                       },
                       new Aluno()
                       {
                           Id = 2,
                           Nome = "Ted",
                           Sobrenome = "Mosby",
                           DataNasc = "03/04/1989",
                           ProfessorId = 2
                       },
                       new Aluno()
                       {
                           Id = 3,
                           Nome = "Lucas",
                           Sobrenome = "Ribamar",
                           DataNasc = "01/05/1998",
                           ProfessorId = 3
                       }

                       );

        }

    }
}
