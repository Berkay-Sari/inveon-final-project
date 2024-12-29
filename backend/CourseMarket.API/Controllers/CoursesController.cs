
using CourseMarket.Application.DTOs;
using CourseMarket.Application.DTOs.Course;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace CourseMarket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(ICourseService courseService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> Read([FromQuery] Pagination pagination)
    {
        return CreateActionResult(await courseService.GetAllAsync(pagination));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Read(Guid id)
    {
        return CreateActionResult(await courseService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCourseRequest request)
    {
        return CreateActionResult(await courseService.CreateAsync(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCourseRequest request)
    {
        return CreateActionResult(await courseService.UpdateAsync(id, request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return CreateActionResult(await courseService.DeleteAsync(id));
    }
}


