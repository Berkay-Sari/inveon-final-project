
using CourseMarket.Application.DTOs;
using CourseMarket.Application.DTOs.Course;
using CourseMarket.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles="Instructor")]
    public async Task<IActionResult> Create([FromForm] CreateCourseRequest request)
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

    [HttpGet("filter")]
    public async Task<IActionResult> FilterByName([FromQuery] string name, [FromQuery] Pagination pagination)
    {
        return CreateActionResult(await courseService.GetByNameAsync(name, pagination));
    }

}


