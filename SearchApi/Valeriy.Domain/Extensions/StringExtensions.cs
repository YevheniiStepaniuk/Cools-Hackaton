using System;
using Microsoft.Extensions.Configuration;

namespace Valeriy.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static int ToInt(this bool value) => value ? 1 : 0;

        public static bool EqualsIgnoreCase(this string s1, string s2)
        {
            return string.Equals(s1, s2, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ContainsBothIgnoreCase(this string s1, string s2)
        {
            if (s1.IsNullOrWhiteSpace() || s2.IsNullOrWhiteSpace())
            {
                return true;
            }
            return s1.ToLower().Contains(s2.ToLower()) || s2.ToLower().Contains(s1.ToLower());
        }

        public static string GetCallMethodFullName(int n = 2)
        {
            return Environment.StackTrace.Split('\n')[n].Trim().Split(' ')[1];
        }

        public static string GetCurrenConnectionString(this IConfiguration configuration)
        {
            return configuration[$"ConnectionStrings:{configuration["Database:ConnectionString"]}"];
        }

    }
}