// ReSharper disable CheckNamespace

namespace Microsoft.AspNetCore.Mvc.Rendering;

public static class HtmlHelpersExtensions
{
    public static string IsActive(this IHtmlHelper html, string? page, string activeClass = "active")
    {
        if (string.IsNullOrEmpty(page))
        {
            return string.Empty;
        }

        var actualPage = html.ViewContext.RouteData.Values.GetValueOrDefault("page")?.ToString();
        if (string.IsNullOrEmpty(actualPage))
        {
            return string.Empty;
        }

        return actualPage.StartsWith(page, StringComparison.OrdinalIgnoreCase) ? activeClass : string.Empty;
    }
}
