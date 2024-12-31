using System.Text.RegularExpressions;

namespace CourseMarket.Infrastructure.Operations;

public static partial class RegexPatterns
{
    [GeneratedRegex(@"[^\w\s-]")]
    public static partial Regex SpecialCharactersRegex();

    [GeneratedRegex(@"\s+")]
    public static partial Regex SpacesRegex();
}
