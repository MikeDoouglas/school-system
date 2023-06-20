using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Repositories.Interfaces;

namespace SchoolSystem.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolSystemDbContext _dbContext;

        public TeacherRepository(SchoolSystemDbContext schoolSystemDbContext)
        {
            _dbContext = schoolSystemDbContext;
        }

        public async Task<TeacherModel> FindOne(int id)
        {
            return await _dbContext.Teacher.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TeacherModel>> List()
        {
            return await _dbContext.Teacher.ToListAsync();
        }

        public async Task<TeacherModel> Create(TeacherModel teacher)
        {
            _dbContext.Teacher.Add(teacher);
            _dbContext.SaveChanges();

            return teacher;
        }

        public async Task<TeacherModel> Update(TeacherModel teacher, int id)
        {
            TeacherModel teacherToUpdate = await FindOne(id);
            if (teacherToUpdate == null)
            {
                throw new Exception($"Usuário do ID {id} não foi encontrado para ser atualizado.");
            }

            teacherToUpdate.Cpf = teacher.Cpf;
            teacherToUpdate.Name = teacher.Name;

            _dbContext.Teacher.Update(teacherToUpdate);
            _dbContext.SaveChanges();

            return teacherToUpdate;
        }

        public async Task<bool> Delete(int id)
        {
            TeacherModel teacher = await FindOne(id);

            if (teacher == null)
            {
                throw new Exception($"Usuário do ID {id} não foi encontrado para ser removido");
            }

            _dbContext.Teacher.Remove(teacher);
            _dbContext.SaveChanges();

            return true;
        }
    }
}