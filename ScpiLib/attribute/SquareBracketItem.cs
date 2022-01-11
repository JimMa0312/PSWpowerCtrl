using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace ScpiLib.attribute
{
    [System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class SquareBracketItemAttribute : Attribute
    {
        readonly bool squareBreacketItem;

        public SquareBracketItemAttribute()
            :this(true)
        {

        }

        public SquareBracketItemAttribute(bool isSquareBreacketItem)
        {
            this.squareBreacketItem = isSquareBreacketItem;
        }

        public bool SquareBreacketItem
        {
            get { return squareBreacketItem; }
        }
    }

    public static class EnumExtensions
    {
        /// <summary>
        /// 获取枚举字段是否标记为方括号字段
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static bool IsSquareBracketItem(this Enum enumValue)
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var attrs =
                fieldInfo.GetCustomAttributes(typeof(SquareBracketItemAttribute), false) as SquareBracketItemAttribute[];

            return attrs.Length > 0 ? attrs[0].SquareBreacketItem : false;
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var attrs =
                fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
            return attrs.Length > 0 ? attrs[0].Name : enumValue.ToString();
        }
    }
}
