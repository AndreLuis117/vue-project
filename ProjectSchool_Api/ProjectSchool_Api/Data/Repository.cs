using Microsoft.EntityFrameworkCore;
using ProjectSchool_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool_Api.Data
{
    public class Repository : IRepository
    {

        public Repository(DataContext context)
        {
            _context = context;
        }

        public DataContext _context { get; }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }       

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        //Alunos
        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
                query = query.Include(x => x.Professor);

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunosAsyncById(int alunoId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
                query = query.Include(x => x.Professor);

            query = query.AsNoTracking().OrderBy(x => x.Id).Where(x => x.Id == alunoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetAlunosAsyncByProfessorId(int professorId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
                query = query.Include(x => x.Professor);

            query = query.AsNoTracking().OrderBy(x => x.Id).Where(x => x.ProfessorId == professorId);

            return await query.ToArrayAsync();
        }

        //Professor

        public async Task<Professor> GetProfessorAsyncById(int professorId, bool includeAluno)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
                query = query.Include(x => x.Alunos);

            query = query.AsNoTracking().OrderBy(x => x.Id).Where(x => x.Id == professorId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Professor[]> GetAllProfessoressAsync(bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
                query = query.Include(x => x.Alunos);

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }
    }
}
