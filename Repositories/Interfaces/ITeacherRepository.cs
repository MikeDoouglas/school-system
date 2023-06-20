using SchoolSystem.Models;

namespace SchoolSystem.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<TeacherModel>> List();

        Task<TeacherModel> FindOne(int id);

        Task<TeacherModel> Create(TeacherModel teacher);

        Task<TeacherModel> Update(TeacherModel teacher, int id);

        Task<bool> Delete(int id);
    }
}