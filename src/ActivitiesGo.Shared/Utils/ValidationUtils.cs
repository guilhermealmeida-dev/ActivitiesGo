using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ActivitiesGo.Shared.Utils;

public static class ValidationUtils
{
    public static IDictionary<string, string[]> GetModelErrors(ModelStateDictionary modelState)
    {
        return modelState
            .Where(x => x.Value != null && x.Value.Errors.Any())
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
            );
    }
}
