﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DotPlatform.Utils
{
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// 解析对象。以字典形式呈现对象的属性（public）及其对应类型。
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="isOnlyPrimitive">是否只显示基元类型</param>
        /// <returns></returns>
        private static Dictionary<string, Type> Resolve(Type type, bool isOnlyPrimitive = false)
        {
            return (from property in TypeDescriptor.GetProperties(type).Cast<PropertyDescriptor>()
                    where isOnlyPrimitive ? (property.PropertyType.IsPrimitive == isOnlyPrimitive) : true
                    select new { property.Name, property.PropertyType }
                  ).ToDictionary(k => k.Name, v => v.PropertyType);
        }

        /// <summary>
        /// 设置对象的属性值
        /// </summary>
        /// <param name="obj">对象实例</param>
        /// <param name="propertyName">对象的属性名称</param>
        /// <param name="value">对象要设置的属性的值</param>
        public static void SetValue(object obj, string propertyName, object value)
        {
            var property = TypeDescriptor.GetProperties(obj).Cast<PropertyDescriptor>()
                .FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

            if (property != null)
            {
                var propType = property.PropertyType;
                var valType = value.GetType();

                if (!propType.IsPrimitive && !valType.IsAssignableFrom(propType))
                {
                    throw new InvalidOperationException($"The property {propType} can not assignable from {valType}");
                }

                property.SetValue(obj, value);  // 类型不符，系统抛出异常
            }
        }
    }
}
