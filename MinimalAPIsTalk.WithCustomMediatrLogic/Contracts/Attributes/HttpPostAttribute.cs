using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Contracts.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class HttpPostAttribute : HttpMethodAttribute
{
    private static readonly IEnumerable<string> _supportedMethods = new[] { "POST" };

    public HttpPostAttribute([StringSyntax("Route")] string template) : base(_supportedMethods, template)
    {
    }
}