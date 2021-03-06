﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectSchool_Api.Data;

namespace ProjectSchool_Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("ProjectSchool_Api.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataNasc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNasc = "02/06/1995",
                            Nome = "Marcus",
                            ProfessorId = 1,
                            Sobrenome = "Fenix"
                        },
                        new
                        {
                            Id = 2,
                            DataNasc = "03/04/1989",
                            Nome = "Ted",
                            ProfessorId = 2,
                            Sobrenome = "Mosby"
                        },
                        new
                        {
                            Id = 3,
                            DataNasc = "01/05/1998",
                            Nome = "Lucas",
                            ProfessorId = 3,
                            Sobrenome = "Ribamar"
                        });
                });

            modelBuilder.Entity("ProjectSchool_Api.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Adam"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Lilly"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Vanderlei"
                        });
                });

            modelBuilder.Entity("ProjectSchool_Api.Models.Aluno", b =>
                {
                    b.HasOne("ProjectSchool_Api.Models.Professor", "Professor")
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("ProjectSchool_Api.Models.Professor", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
