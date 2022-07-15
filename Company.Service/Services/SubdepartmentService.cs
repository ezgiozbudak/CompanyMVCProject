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
    public class SubdepartmentService : GenericService<Subdepartments>, ISubdepartmentService
    {
        private readonly ISubdepartmentRepository _subdepartmentRepository;
        private readonly IMapper _mapper;
        public SubdepartmentService(IGenericRepository<Subdepartments> repository, IGenericUnitOfWork unitOfWork, ISubdepartmentRepository subdepartmentRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _subdepartmentRepository = subdepartmentRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<SubDepartmentsDto>>> GetApiAllSubdepartments()
        {
            var subdepartments = await _subdepartmentRepository.GetApiAllSubdepartmentsAsync();
            var subdepartmentDtos = _mapper.Map<List<SubDepartmentsDto>>(subdepartments);
            return CustomResponseDto<List<SubDepartmentsDto>>.Success(200, subdepartmentDtos);
        }

       

        public async Task<List<SubDepartmentsDto>> GetWebAllSubdepartments()
        {
            var subdepartment = await _subdepartmentRepository.GetApiAllSubdepartmentsAsync();
            var subdepartmentDtos = _mapper.Map<List<SubDepartmentsDto>>(subdepartment);
            return subdepartmentDtos;
        }
    }
}
