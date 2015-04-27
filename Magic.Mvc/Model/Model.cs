﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Magic.Mvc.Model
{
    /// <summary>
    /// 模型基类
    /// </summary>
    public class Model : IModel
    {
        public PropertyInfo[] getPrimaryKeys()
        {
            return ModelInfoProvider.getFiledsByAttribute(this.GetType(),typeof(KeyAttribute));
        }
        public PropertyInfo getIdentify()
        {
            var fs = ModelInfoProvider.getFiledsByAttribute(this.GetType(), typeof(IdentifyAttribute));
            return fs.FirstOrDefault(); 
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public object Property(string propertyName)
        {
            Check.IsNull(propertyName);
            return ModelInfoProvider.getPropertyValue(this, propertyName);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public void Property(string propertyName, object value)
        {
            Check.IsNull(propertyName);
            ModelInfoProvider.setPropertyValue(this, propertyName, value);
        }
    }
}
