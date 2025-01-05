using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMarket.Application.DTOs.User;

public record ChangePasswordRequest(string CurrentPassword, string NewPassword);