using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Repositories.Interfaces;

namespace SchoolSystem.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolSystemDbContext _dbContext;

        public SchoolRepository(SchoolSystemDbContext schoolSystemDbContext)
        {
            _dbContext = schoolSystemDbContext;
        }

        public async Task<SchoolModel> FindOne(int id)
        {
            return await _dbContext.School.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<SchoolModel>> List()
        {
            return await _dbContext.School.ToListAsync();
        }

        public async Task<SchoolModel> Create(SchoolModel teacher)
        {
            _dbContext.School.Add(teacher);
            _dbContext.SaveChanges();

            return teacher;
        }

        public async Task<SchoolModel> Update(SchoolModel teacher, int id)
        {
            SchoolModel teacherToUpdate = await FindOne(id);
            if (teacherToUpdate == null)
            {
                throw new Exception($"Usuário do ID {id} não foi encontrado para ser atualizado.");
            }

            teacherToUpdate.Name = teacher.Name;
            teacherToUpdate.Address = teacher.Address;
            teacherToUpdate.TeacherId = teacher.TeacherId;

            _dbContext.School.Update(teacherToUpdate);
            _dbContext.SaveChanges();

            return teacherToUpdate;
        }

        public async Task<bool> Delete(int id)
        {
            SchoolModel teacher = await FindOne(id);

            if (teacher == null)
            {
                throw new Exception($"Usuário do ID {id} não foi encontrado para ser removido");
            }

            _dbContext.School.Remove(teacher);
            _dbContext.SaveChanges();

            return true;
        }
    }
}