using AutoMapper;
using Company.Core;
using Company.Core.DTOs;
using Company.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.WEB.Controllers
{
    public class TopDepartmentsController : Controller
    {
        private readonly ITopDepartmentService _topdepartmentService;

        private readonly IMapper _mapper;
        public TopDepartmentsController(ITopDepartmentService topdepartmentService, IMapper mapper)
        {
            _topdepartmentService = topdepartmentService;

            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _topdepartmentService.GetWebAllTopDepartments());

        }

        public async Task<IActionResult> Save()
        {
            var topdepartment = await _topdepartmentService.GetAllAsync();
            var topdepartmentDto = _mapper.Map<List<TopDepartmentsDto>>(topdepartment.ToList());
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(TopDepartmentsDto topdepartmentDto)
        {
            if (ModelState.IsValid)
            {
                await _topdepartmentService.AddAsync(_mapper.Map<TopDepartments>(topdepartmentDto));

                return RedirectToAction(nameof(Index));
            }

            var top = await _topdepartmentService.GetAllAsync();
            var topDto = _mapper.Map<List<TopDepartmentsDto>>(top.ToList());
            return View();
        }
        public async Task<IActionResult> Update(int Id)
        {
            var topdepartment = await _topdepartmentService.GetByIdAsync(Id);
            return View(_mapper.Map<TopDepartmentsDto>(topdepartment));
        }

        [HttpPost]
        public async Task<IActionResult> Update(TopDepartmentsDto topdepartmentsDto)
        {
            if (ModelState.IsValid)
            {
                await _topdepartmentService.UpdateAsync(_mapper.Map<TopDepartments>(topdepartmentsDto));
                return RedirectToAction(nameof(Index));
            }
            var topdepartments = await _topdepartmentService.GetAllAsync();
            var topdepartmentDto = _mapper.Map<List<TopDepartmentsDto>>(topdepartments.ToList());
            return View(topdepartmentDto);
        }



        public async Task<IActionResult> Delete(int Id)
        {
            var topDepartments = await _topdepartmentService.GetByIdAsync(Id);
            await _topdepartmentService.RemoveAsync(topDepartments);
            
            return RedirectToAction(nameof(Index));

        }
        
    }
}
