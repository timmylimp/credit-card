using System;
using System.Reflection;
using System.ComponentModel;

namespace CreditCard.RestAPI.Extensions
{
    public static class EnumExtensions
    {
        public static string ToFriendlyString(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();

        }
    }
}