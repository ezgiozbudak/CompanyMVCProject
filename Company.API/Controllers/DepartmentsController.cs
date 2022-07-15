using AutoMapper;
using Company.Core;
using Company.Core.DTOs;
using Company.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentService _services;

        public DepartmentsController(IGenericService<Departments> service, IMapper mapper, IDepartmentService departmentService)
        {
            _services = departmentService;
            _mapper = mapper;


        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetDepartments()
        {
            return CreateActionResult(await _services.GetApiAllDepartments());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
          
            var department = await _services.GetAllAsync();
            var departmentDtos = _mapper.Map<List<DepartmentsDto>>(department.ToList());

            return CreateActionResult(CustomResponseDto<List<DepartmentsDto>>.Success(200, departmentDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _services.GetByIdAsync(id);
            var departmentDto = _mapper.Map<DepartmentsDto>(department);
            return CreateActionResult(CustomResponseDto<DepartmentsDto>.Success(200, departmentDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(DepartmentsDto departmentDto)
        {
            var department = await _services.AddAsync(_mapper.Map<Departments>(departmentDto));
            var departmentsDto = _mapper.Map<DepartmentsDto>(department);
            return CreateActionResult(CustomResponseDto<DepartmentsDto>.Success(201, departmentsDto));
        }



        [HttpPut]
        public async Task<IActionResult> Update(DepartmentsDto departmentDto)
        {
            await _services.UpdateAsync(_mapper.Map<Departments>(departmentDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Remove(int id)
        {
            var department = await _services.GetByIdAsync(id);
            await _services.RemoveAsync(department);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
