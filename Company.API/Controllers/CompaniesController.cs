using AutoMapper;
using Company.Core;
using Company.Core.DTOs;
using Company.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _services;
        
        public CompaniesController(IGenericService<Companies> service, IMapper mapper, ICompanyService companyService)
        {
            _services = companyService;
            _mapper = mapper;

            
        }


        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCompanies()
        {
            return CreateActionResult(await _services.GetApiAllCompanies());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            
            var company = await _services.GetAllAsync();
            var companyDtos = _mapper.Map<List<CompaniesDto>>(company.ToList());

            return CreateActionResult(CustomResponseDto<List<CompaniesDto>>.Success(200, companyDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _services.GetByIdAsync(id);
            var companyDto = _mapper.Map<CompaniesDto>(company);
            return CreateActionResult(CustomResponseDto<CompaniesDto>.Success(200, companyDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CompaniesDto companyDto)
        {
            var company = await _services.AddAsync(_mapper.Map<Companies>(companyDto));
            var companiesDto = _mapper.Map<CompaniesDto>(company);
            return CreateActionResult(CustomResponseDto<CompaniesDto>.Success(201, companiesDto));
        }



        [HttpPut]
        public async Task<IActionResult> Update(CompaniesDto companyDto)
        {
            await _services.UpdateAsync(_mapper.Map<Companies>(companyDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

       
        [HttpDelete("{id}")]

        public async Task<IActionResult> Remove(int id)
        {
            var company = await _services.GetByIdAsync(id);
            await _services.RemoveAsync(company);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
