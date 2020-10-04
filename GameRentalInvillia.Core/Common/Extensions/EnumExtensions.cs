using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GameRentalInvillia.Core.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this System.Enum enumValue)
        {
            var value = enumValue.GetType().GetMember(enumValue.ToString())[0].GetCustomAttribute<DisplayAttribute>();

            return value != null ? value.Name : string.Empty;
        }
    }
}