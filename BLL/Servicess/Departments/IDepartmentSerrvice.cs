using System.Collections.Generic;

namespace BLL.Models_DTOS__CustomModel_.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmetGetAllDTO> GetAll();
        DepartmetDetailsDTO? GetById(int? id);
        int Create(DepartmetCreateDto department);
        bool Delete(int? id);
        int Update(DepartmentUpdateDto updateDto);
    }
}
