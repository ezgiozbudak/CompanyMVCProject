using AutoMapper;
using Company.Core;
using Company.Core.DTOs;
using Company.Core.Repositories;
using Company.Core.Services;
using Company.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DepartmentService : GenericService<Departments>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IGenericRepository<Departments> repository, IGenericUnitOfWork unitOfWork, IDepartmentRepository departmentRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<DepartmentsDto>>> GetApiAllDepartments()
        {
            var departments = await _departmentRepository.GetApiAllDepartmentsAsync();
            var departmentsDtos = _mapper.Map<List<DepartmentsDto>>(departments);
            return CustomResponseDto<List<DepartmentsDto>>.Success(200, departmentsDtos);
        }

        public async Task<List<DepartmentsDto>> GetWebAllDepartments()
        {
            var departments = await _departmentRepository.GetApiAllDepartmentsAsync();
            var departmentsDtos = _mapper.Map<List<DepartmentsDto>>(departments);
            return departmentsDtos;
        }
    }
}
