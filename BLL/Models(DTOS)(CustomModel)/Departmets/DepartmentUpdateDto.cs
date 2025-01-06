namespace BLL.Models_DTOS__CustomModel_.Departments
{
    public class DepartmentUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }
    }
}
