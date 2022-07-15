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
    public class CompanyService : GenericService<Companies>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyService(IGenericRepository<Companies> repository, IGenericUnitOfWork unitOfWork, ICompanyRepository companyRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<CompaniesDto>>> GetApiAllCompanies()
        {
            var companies = await _companyRepository.GetApiAllCompaniesAsync();
            var companiesDtos = _mapper.Map<List<CompaniesDto>>(companies);
            return CustomResponseDto<List<CompaniesDto>>.Success(200, companiesDtos);
        }

        public async Task<List<CompaniesDto>> GetWebAllCompanies()
        {
            var company = await _companyRepository.GetApiAllCompaniesAsync();
            var companiesDtos = _mapper.Map<List<CompaniesDto>>(company);
            return companiesDtos;
        }
    }
}
