using AutoMapper;
using Company.Core;
using Company.Core.DTOs;
using Company.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.WEB.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        public IMapper _mapper;
        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _companyService.GetWebAllCompanies());
        }

        public async Task<IActionResult> Save()
        {
            var company = await _companyService.GetAllAsync();
            var companyDto = _mapper.Map<List<CompaniesDto>>(company.ToList());
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(CompaniesDto companyDto)
        {
            if (ModelState.IsValid)
            {
                await _companyService.AddAsync(_mapper.Map<Companies>(companyDto));
                return RedirectToAction(nameof(Index));
            }
            var company = await _companyService.GetAllAsync();
            var companiesDto = _mapper.Map<List<CompaniesDto>>(company.ToList());
            return View();
        }

        public async Task<IActionResult> Update(int Id)
        {
            var companies = await _companyService.GetByIdAsync(Id);
            return View(_mapper.Map<CompaniesDto>(companies));
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(CompaniesDto companyDto)
        {
            if (ModelState.IsValid)
            {
                await _companyService.UpdateAsync(_mapper.Map<Companies>(companyDto));
                return RedirectToAction(nameof(Index));
            }
            var companies = await _companyService.GetAllAsync();
            var companiesDto = _mapper.Map<List<CompaniesDto>>(companies.ToList());
            return View(companiesDto);
        }

        

        public async Task<IActionResult> Delete(int Id)
        {
            var company = await _companyService.GetByIdAsync(Id);
            await _companyService.RemoveAsync(company);
            return RedirectToAction(nameof(Index));

        }

        
    }
}
