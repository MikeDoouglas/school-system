using SchoolSystem.Models;

namespace SchoolSystem.Repositories.Interfaces
{
    public interface ISchoolRepository
    {
        Task<List<SchoolModel>> List();

        Task<SchoolModel> FindOne(int id);

        Task<SchoolModel> Create(SchoolModel school);

        Task<SchoolModel> Update(SchoolModel school, int id);

        Task<bool> Delete(int id);
    }
}