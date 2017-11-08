#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
using System;
using System.Collections;
using System.Reflection;
using MSRegex = System.Text.RegularExpressions;

namespace WitsWay.Utilities.Regexs
{

    /// <summary>
    /// 要解析的属性
    /// 特性标示
    /// <remarks>
    /// 每个RegexClassInfo中存储了ParseClassAttribute和ParsePropertyAttribute字典
    /// 该类负责属性的赋值，故一个RegexClassInfo实例化时会多次实例化本类
    /// </remarks>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ParsePropertyAttribute : Attribute
    {

        #region [Field]
        ///// <summary>
        /////日志
        ///// </summary>
        /// <summary>
        /// 默认转换函数类，默认为DataConverHelper
        /// </summary>
        private readonly Type _converHelperClass = typeof(DefaultDataConverHelper);

        // 转换函数名
        private readonly string _converFun;
        // 组名
        /// <summary>
        /// 匹配组名
        /// </summary>
        public string RegexGroupName { get; }

        /// <summary>
        /// 属性信息
        /// </summary>
        public PropertyInfo PropertyInfo { get; set; }

        private MethodInfo _converMethod;

        /// <summary>
        /// 转换辅助类 
        /// </summary>
        public Type CreateType { get; private set; }

        #endregion

        #region [Construction]

        /// <summary>
        /// 属性匹配设置
        /// </summary>
        /// <param name="groupName">正则表达式中的GroupName</param>
        public ParsePropertyAttribute(string groupName)
        {
            RegexGroupName = groupName;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="groupName">匹配组名</param>
        /// <param name="converFun">转换函数名</param>
        public ParsePropertyAttribute(string groupName, string converFun)
        {
            RegexGroupName = groupName;
            _converFun = converFun;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="groupName">匹配组名</param>
        /// <param name="converClass">用于转换的类</param>
        /// <param name="converFun">转换函数</param>
        public ParsePropertyAttribute(string groupName, Type converClass, string converFun)
        {
            RegexGroupName = groupName;
            _converFun = converFun;
            _converHelperClass = converClass;
        }


        #endregion

        #region [SetPropertyValue]

        /// <summary>
        /// 设置属性的值
        /// </summary>
        /// <param name="matchObject"></param>
        /// <param name="group"></param>
        /// <returns>设置成功返回true</returns>
        internal bool SetPropertyValue(object matchObject, MSRegex.Group group)
        {
            try
            {
                var proType = PropertyInfo.PropertyType;
                //泛形支持
                if (proType.IsGenericType)
                {
                    if (proType.IsArray == false)
                    {
                        if (PropertyInfo.CanWrite)
                        {
                            //如果能直接创建
                            if (PropertyInfo.PropertyType.IsAssignableFrom(proType))
                            {
                                try
                                {
                                    IList list;
                                    list = Activator.CreateInstance(proType) as IList;
                                    //获取泛形内部成员
                                    var parameters = proType.GetGenericArguments();

                                    if (parameters.Length != 1)
                                    {
                                        throw new Exception("无法创建多个成员泛形！");
                                    }
                                    var valueType = parameters[0];
                                    //首先判断该类型是不是可以继续匹配的类型如果是的话就继续匹配
                                    if (IsRegexMatchClass(parameters[0]))
                                    {
                                        //
                                        foreach (MSRegex.Capture c in @group.Captures)
                                        {
                                            var str = c.Value;
                                            var retObj = Activator.CreateInstance(valueType);
                                            if (RegexHelper.Match(retObj, ref str, false))
                                            {

                                                list.Add(retObj);
                                            }
                                        }
                                        PropertyInfo.SetValue(matchObject, list, null);
                                        return true;
                                    }

                                    object retObj2 = null;
                                    //普通类型
                                    foreach (MSRegex.Capture c in @group.Captures)
                                    {
                                        if (ChangeType(matchObject, c.Value, ref retObj2))
                                        {
                                            var obj2 = retObj2 as IList;
                                            if (obj2 != null)
                                            {
                                                list = obj2;
                                                break;
                                            }
                                            list.Add(retObj2);
                                        }

                                    }
                                    PropertyInfo.SetValue(matchObject, list, null);
                                    return true;
                                }
                                catch (Exception ee)
                                {
                                    throw new Exception("无法创建实体类", ee);
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("该成员只读！");
                        }
                    }
                    else
                    {
                        throw new Exception("不支持泛形数组");
                    }
                }
                else
                {
                    object retObj = null;
                    var value = group.Value;
                    //非泛形支持
                    if (ChangeType(matchObject, value, ref retObj))
                    {
                        PropertyInfo.SetValue(matchObject, retObj, null);
                        return true;
                    }
                }

            }
            catch (Exception)
            {
                throw new Exception("正则解析错误");
            }
            return false;
        }
        /// <summary>
        /// 判断是不是包含正则表达式的类
        /// </summary>
        bool IsRegexMatchClass(Type type)
        {
            var info = RegexClassFactory.GetRegexClass(type);
            if (info == null)
            {
                return false;
            }
            return true;
        }

        bool ChangeType(object setValue, string value, ref object retObj)
        {

            if (string.IsNullOrEmpty(_converFun))
            {
                //没有自己定义转换函数
                if (CreateType == null)
                {
                    CreateType = PropertyInfo.PropertyType;
                }
                retObj = Convert.ChangeType(value, CreateType, null);
                return true;
            }
            //自己定义了转换函数
            if (_converMethod == null)
            {
                //建立转化函数工厂
                var type = setValue.GetType();
                while (_converMethod == null)
                {
                    _converMethod = type.GetMethod(_converFun);
                    type = type.BaseType;
                    if (type == null)
                    {
                        break;
                    }
                }
                if (_converMethod == null)
                {
                    //获取标准数据转换函数
                    if (_converHelperClass != null)
                    {
                        var tempType = _converHelperClass;
                        while (_converMethod == null)
                        {
                            _converMethod = tempType.GetMethod(_converFun);
                            tempType = tempType.BaseType;
                            if (type == null)
                            {
                                break;
                            }
                        }
                    }
                }

            }
            if (_converMethod != null)
            {
                try
                {
                    retObj = _converMethod.Invoke(setValue, new object[] { value });
                    return true;
                }
                catch (Exception e1)
                {
                    throw new Exception("正则表达式分析数据转换异常", e1);

                }
            }
            throw new Exception($"未找到指定的转换函数{_converFun}");
        }

        #endregion

        #region [DefaultConvertClass]

        /// <summary>
        /// 数据转换辅助类
        /// </summary>
        private static class DefaultDataConverHelper
        {
            /// <summary>
            /// 从字符串转换到Int类型
            /// </summary>
            public static int StringToHexInt(string value)
            {
                return value.HexToInt();
            }
        }

        #endregion

        #region [Deleted]

        ///// <summary>
        ///// 属性匹配设置
        ///// </summary>
        ///// <param name="groupName">正则表达式中的GroupName</param>
        ///// <param name="createType">设定创建的类型数值</param>
        //public ParsePropertyAttribute(string groupName, Type createType)
        //{
        //    _groupName = groupName;
        //    _createType = createType;
        //}

        #endregion

    }

    public static class HexExtends
    {

        /// <summary>
        /// 16进制字符串转换为Int
        /// </summary>
        public static int HexToInt(this string hex)
        {
            if (string.IsNullOrWhiteSpace(hex)) { return 0; }

            var i = Convert.ToInt32(hex, 16);

            if (i >= 0x8000000)
                i = ~(i - 1);

            return i;
        }
    }


}
