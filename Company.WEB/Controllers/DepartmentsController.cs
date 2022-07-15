using AutoMapper;
using Company.Core;
using Company.Core.DTOs;
using Company.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.WEB.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public IMapper _mapper;
        public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _departmentService.GetWebAllDepartments());
        }

        public async Task<IActionResult> Save()
        {
            var department = await _departmentService.GetAllAsync();
            var departmentsDto = _mapper.Map<List<DepartmentsDto>>(department.ToList());
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(DepartmentsDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.AddAsync(_mapper.Map<Departments>(departmentDto));
                return RedirectToAction(nameof(Index));
            }
            var department = await _departmentService.GetAllAsync();
            var departmentsDto = _mapper.Map<List<DepartmentsDto>>(department.ToList());
            return View();
        }

        public async Task<IActionResult> Update(int Id)
        {
            var department = await _departmentService.GetByIdAsync(Id);
            return View(_mapper.Map<DepartmentsDto>(department));
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentsDto departmentsDto)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.UpdateAsync(_mapper.Map<Departments>(departmentsDto));
                return RedirectToAction(nameof(Index));
            }
            var departments = await _departmentService.GetAllAsync();
            var departmentDto = _mapper.Map<List<DepartmentsDto>>(departments.ToList());
            return View(departmentDto);
        }


        
        public async Task<IActionResult> Delete(int Id)
        {
            var department= await _departmentService.GetByIdAsync(Id);
            await _departmentService.RemoveAsync(department);
            
            return RedirectToAction(nameof(Index));

        }

        
    }
}
