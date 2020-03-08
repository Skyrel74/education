using System;

namespace Cenema.Extensions
{
    public static class IntExtensions
    {
        public static string ToDuration(this int value)
        {
            var hours = Math.Truncate(value / 60f);
            var minutes = value % 60;
            return $"{hours}h {minutes}m";
        }
    }
}