namespace SchoolSystem.Models
{
    public class SchoolModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int? TeacherId { get; set; }

        public TeacherModel? Teacher { get; set; }
    }
}