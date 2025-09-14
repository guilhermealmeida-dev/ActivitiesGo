using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ActivitiesGo.API.Utils;

public static class ValidationUtils
{
    public static IDictionary<string, string[]> GetModelErrors(ModelStateDictionary modelState)
    {
        return modelState
            .Where(x => x.Value != null && x.Value.Errors.Any())
            .ToDictionary(
                kvp => char.ToLowerInvariant(kvp.Key[0]) + kvp.Key.Substring(1),
                kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
            );
    }
}
