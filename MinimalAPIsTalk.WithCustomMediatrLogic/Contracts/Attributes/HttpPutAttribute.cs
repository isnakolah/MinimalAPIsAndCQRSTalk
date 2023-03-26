using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Contracts.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class HttpPutAttribute: HttpMethodAttribute
{
    private static readonly IEnumerable<string> _supportedMethods = new[] { "PUT" };

    public HttpPutAttribute([StringSyntax("Route")] string template) : base(_supportedMethods, template)
    {
    }
}