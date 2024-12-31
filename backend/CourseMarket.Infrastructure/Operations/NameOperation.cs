namespace CourseMarket.Infrastructure.Operations;

public static class NameOperation
{
    public static string SanitizeName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return string.Empty;

        var normalized = name
            .ToLowerInvariant()
            .Replace("ı", "i")
            .Replace("ğ", "g")
            .Replace("ü", "u")
            .Replace("ş", "s")
            .Replace("ö", "o")
            .Replace("ç", "c");

        var sanitized = RemoveSpecialCharacters(normalized);
        return ReplaceSpacesWithHyphens(sanitized).Trim('-');
    }

    private static string RemoveSpecialCharacters(string name)
    {
        return RegexPatterns.SpecialCharactersRegex().Replace(name, "");
    }

    private static string ReplaceSpacesWithHyphens(string name)
    {
        return RegexPatterns.SpacesRegex().Replace(name, "-");
    }
}