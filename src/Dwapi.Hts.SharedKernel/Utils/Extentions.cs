using System;

namespace Dwapi.Hts.SharedKernel.Utils
{
   public static class Extentions
    {
        /// <summary>
        /// Determines if a nullable Guid (Guid?) is null or Guid.Empty
        /// </summary>
        public static bool IsNullOrEmpty(this Guid? guid)
        {
            return !guid.HasValue || guid.Value == Guid.Empty;
        }

        /// <summary>
        /// Determines if Guid is Guid.Empty
        /// </summary>
        public static bool IsNullOrEmpty(this Guid guid)
        {
            return guid == Guid.Empty;
        }

        public static string HasToEndWith(this string value, string end)
        {
            return value.EndsWith(end) ? value : $"{value}{end}";
        }
        public static bool IsSameAs(this string value, string end)
        {
            if((null!=value)&&(null!=end))
                return value.ToLower().Trim() == end.ToLower().Trim();
            return false;
        }
    }
}
