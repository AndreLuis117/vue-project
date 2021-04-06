using ProjectSchool_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool_Api.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();



        //Aluno

        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
        Task<Aluno[]> GetAlunosAsyncByProfessorId(int professorId, bool includeProfessor);
        Task<Aluno>GetAlunosAsyncById(int alunoId, bool includeProfessor);


        //Professor
        Task<Professor[]> GetAllProfessoressAsync(bool includeAluno);
        Task<Professor> GetProfessorAsyncById(int professorId, bool includeAluno);

    }
}
