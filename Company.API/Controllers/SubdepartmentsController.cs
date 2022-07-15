using AutoMapper;
using Company.Core;
using Company.Core.DTOs;
using Company.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubdepartmentsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISubdepartmentService _services;

        public SubdepartmentsController(IGenericService<Subdepartments> service, IMapper mapper, ISubdepartmentService subdepartmentService)
        {
            _services = subdepartmentService;
            _mapper = mapper;


        }

   

        [HttpGet]
        public async Task<IActionResult> All()
        {
            
            var subdepartment = await _services.GetAllAsync();
            var subdepartmentsDtos = _mapper.Map<List<SubDepartmentsDto>>(subdepartment.ToList());

            return CreateActionResult(CustomResponseDto<List<SubDepartmentsDto>>.Success(200, subdepartmentsDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subdepartment = await _services.GetByIdAsync(id);
            var subdepartmentDto = _mapper.Map<SubDepartmentsDto>(subdepartment);
            return CreateActionResult(CustomResponseDto<SubDepartmentsDto>.Success(200, subdepartmentDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SubDepartmentsDto subdepartmentDto)
        {
            var subdepartment = await _services.AddAsync(_mapper.Map<Subdepartments>(subdepartmentDto));
            var subdepartmentsDto = _mapper.Map<SubDepartmentsDto>(subdepartment);
            return CreateActionResult(CustomResponseDto<SubDepartmentsDto>.Success(201, subdepartmentsDto));
        }



        [HttpPut]
        public async Task<IActionResult> Update(SubDepartmentsDto subdepartmentDto)
        {
            await _services.UpdateAsync(_mapper.Map<Subdepartments>(subdepartmentDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Remove(int id)
        {
            var subdepartment = await _services.GetByIdAsync(id);
            await _services.RemoveAsync(subdepartment);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
