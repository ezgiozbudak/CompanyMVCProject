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
    public class TopDepartmentService : GenericService<TopDepartments>, ITopDepartmentService
    {
        private readonly ITopDepartmentRepository _topdepartmentRepository;
        private readonly IMapper _mapper;
        public TopDepartmentService(IGenericRepository<TopDepartments> repository, IGenericUnitOfWork unitOfWork, ITopDepartmentRepository topDepartmentRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _topdepartmentRepository = topDepartmentRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<TopDepartmentsDto>>> GetApiAllTopDepartments()
        {
            var topdepartments = await _topdepartmentRepository.GetApiAllTopDepartmentsAsync();
            var topdepartmentsDtos = _mapper.Map<List<TopDepartmentsDto>>(topdepartments);
            return CustomResponseDto<List<TopDepartmentsDto>>.Success(200, topdepartmentsDtos);
        }

        public async Task<List<TopDepartmentsDto>> GetWebAllTopDepartments()
        {
            var topdepartments = await _topdepartmentRepository.GetApiAllTopDepartmentsAsync();
            var topdepartmentDtos = _mapper.Map<List<TopDepartmentsDto>>(topdepartments);
            return topdepartmentDtos;
        }
    }
}
