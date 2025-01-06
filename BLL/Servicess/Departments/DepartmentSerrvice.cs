using BLL.Models_DTOS__CustomModel_.Departments;
using DAL.Entities;
using DAL.Presistance.Repo.Departments;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmetGetAllDTO> GetAll()
        {
            var departments = departmentRepository.GetAll().ToList();

            return departments.Select(d => new DepartmetGetAllDTO
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Code = d.Code,
                CreationDate = d.CreationDate
            }).ToList();
        }

        public DepartmetDetailsDTO? GetById(int? id)
        {
            if (id == null) return null;

            var department = departmentRepository.Get(id);
            if (department == null) return null;

            return new DepartmetDetailsDTO()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreationDate = department.CreationDate,
                CreatedBy = department.CreatBy,
                CreatedOn = department.CreatedOn,
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = department.LastModifiedOn
            };
        }

        public int Create(DepartmetCreateDto departmentDto)
        {
            var department = new Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreationDate = departmentDto.CreationDate,
                CreatBy = 1,  // Hardcoded, this should be fetched from the current user
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow
            };

            return departmentRepository.Add(department);
        }

        public bool Delete(int? id)
        {
            if (id == null) return false;

            var department = departmentRepository.Get(id);
            if (department == null) return false;

            return departmentRepository.Delete(department) > 0;
        }

        public int Update(DepartmentUpdateDto updateDto)
        {
            var department = departmentRepository.Get(updateDto.Id);
            if (department == null) return 0; // Handle case where department doesn't exist

            department.Name = updateDto.Name;
            department.Code = updateDto.Code;
            department.Description = updateDto.Description;
            department.LastModifiedBy = 1;  // Ideally, this should be dynamically fetched
            department.LastModifiedOn = DateTime.UtcNow;

            return departmentRepository.Update(department);
        }
    }
}
