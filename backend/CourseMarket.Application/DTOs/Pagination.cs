using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMarket.Application.DTOs;

public record Pagination(
    int Page = 0,
    int Size = 5
);
