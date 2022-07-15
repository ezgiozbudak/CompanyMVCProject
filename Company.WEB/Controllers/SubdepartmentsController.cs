using AutoMapper;
using Company.Core;
using Company.Core.DTOs;
using Company.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;

namespace Company.WEB.Controllers
{
    public class SubdepartmentsController : Controller
    {

        private readonly ISubdepartmentService _subdepartmentService;
        
        private readonly IMapper _mapper;
        public SubdepartmentsController(ISubdepartmentService subdepartmentService,  IMapper mapper)
        {
            _subdepartmentService = subdepartmentService;
            
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _subdepartmentService.GetWebAllSubdepartments());

        }
       
        public async Task<IActionResult> Save()
        {
            var subdepartment = await _subdepartmentService.GetAllAsync();
            var subdepartmentDto = _mapper.Map<List<SubDepartmentsDto>>(subdepartment.ToList());
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(SubDepartmentsDto subdepartmentDto)
        {
            if (ModelState.IsValid)
            {
                await _subdepartmentService.AddAsync(_mapper.Map<Subdepartments>(subdepartmentDto));
               
                return RedirectToAction(nameof(Index));
            }
            
            var sub = await _subdepartmentService.GetAllAsync();
            var subDto = _mapper.Map<List<SubDepartmentsDto>>(sub.ToList());
            return View();
        }
        public async Task<IActionResult> Update(int Id)
        {
            var subdepartment = await _subdepartmentService.GetByIdAsync(Id);
            return View(_mapper.Map<SubDepartmentsDto>(subdepartment));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubDepartmentsDto subdepartmentsDto)
        {
            if (ModelState.IsValid)
            {
                await _subdepartmentService.UpdateAsync(_mapper.Map<Subdepartments>(subdepartmentsDto));
                return RedirectToAction(nameof(Index));
            }
            var subdepartments = await _subdepartmentService.GetAllAsync();
            var subdepartmentDto = _mapper.Map<List<SubDepartmentsDto>>(subdepartments.ToList());
            return View(subdepartmentDto);
        }




        
        public async Task<IActionResult> Delete(int Id)
        {
            var sub = await _subdepartmentService.GetByIdAsync(Id);
            await _subdepartmentService.RemoveAsync(sub);
            return RedirectToAction(nameof(Index));

        }
        
    }
}