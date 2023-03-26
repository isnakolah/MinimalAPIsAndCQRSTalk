using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Contracts.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class HttpGetAttribute : HttpMethodAttribute
{
    private static readonly IEnumerable<string> _supportedMethods = new[] { "GET" };

    public HttpGetAttribute([StringSyntax("Route")] string template) : base(_supportedMethods, template)
    {
    }
}