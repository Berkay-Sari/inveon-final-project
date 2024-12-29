using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMarket.Application.DTOs.Course;

public record CourseDetailDto(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    string Category
);
