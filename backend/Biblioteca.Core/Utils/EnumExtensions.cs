using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static class EnumExtensions
{
    public static string ObterDisplayName(this Enum enumValue)
    {
        var displayName = enumValue.GetType().GetField(enumValue.ToString())?.GetCustomAttribute<DisplayAttribute>()?.GetName();

        if (String.IsNullOrEmpty(displayName))
        {
            displayName = enumValue.ToString();
        }

        return displayName;
    }
}