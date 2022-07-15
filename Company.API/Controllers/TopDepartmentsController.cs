using AutoMapper;
using Company.Core;
using Company.Core.DTOs;
using Company.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TopDepartmentsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ITopDepartmentService _services;

        public TopDepartmentsController(IGenericService<TopDepartments> service, IMapper mapper, ITopDepartmentService topdepartmentService)
        {
            _services = topdepartmentService;
            _mapper = mapper;


        }

 
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTopdepartments()
        {
            return CreateActionResult(await _services.GetApiAllTopDepartments());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            
            var topdepartment = await _services.GetAllAsync();
            var topdepartmentsDtos = _mapper.Map<List<TopDepartmentsDto>>(topdepartment.ToList());

            return CreateActionResult(CustomResponseDto<List<TopDepartmentsDto>>.Success(200, topdepartmentsDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var topdepartment = await _services.GetByIdAsync(id);
            var topdepartmentDto = _mapper.Map<TopDepartmentsDto>(topdepartment);
            return CreateActionResult(CustomResponseDto<TopDepartmentsDto>.Success(200, topdepartmentDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TopDepartmentsDto topdepartmentDto)
        {
            var topdepartment = await _services.AddAsync(_mapper.Map<TopDepartments>(topdepartmentDto));
            var topdepartmentsDto = _mapper.Map<TopDepartmentsDto>(topdepartment);
            return CreateActionResult(CustomResponseDto<TopDepartmentsDto>.Success(201, topdepartmentsDto));
        }



        [HttpPut]
        public async Task<IActionResult> Update(TopDepartmentsDto topdepartmentDto)
        {
            await _services.UpdateAsync(_mapper.Map<TopDepartments>(topdepartmentDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Remove(int id)
        {
            var topdepartment = await _services.GetByIdAsync(id);
            await _services.RemoveAsync(topdepartment);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
