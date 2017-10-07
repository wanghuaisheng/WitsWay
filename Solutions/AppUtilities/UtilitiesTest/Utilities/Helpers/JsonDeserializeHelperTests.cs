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
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{
    /// <summary>
    /// Json格式对象反序列化帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [TestClass]
    public class JsonDeserializeHelperTests
    {
        /// <summary>
        /// 转换为实体
        /// </summary>
        [TestMethod]
        public void DeserializeTest()
        {
            //待转换的JSON字符串
            var jsonStr = "{UserId:100021,UserName:\"小明\"}";

            var encode = Encoding.Default;
            var bytedata = encode.GetBytes(jsonStr);
            jsonStr = Convert.ToBase64String(bytedata, 0, bytedata.Length);

            //注意：使用时传入的值，需要进行Base64编码
            var result = JsonDeserializeHelper<UserInfo>.Deserialize(jsonStr);
            Assert.IsTrue(result.UserId == 100021);
        }

        /// <summary>
        /// 实体转JSON测试1
        /// </summary>
        [TestMethod]
        public void Serialize1Test()
        {
            //待转换的对象
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";

            var result = JsonDeserializeHelper<UserInfo>.Serialize(userInfo);

            //这里只判断转换结果的长度，具体请参考返回数据
            Assert.IsTrue(result.Length > 0);
        }

        /// <summary>
        /// 实体转JSON测试2
        /// </summary>
        [TestMethod]
        public void Serialize2Test()
        {
            //待转换的对象
            var list = new List<UserInfo>();

            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";
            list.Add(userInfo);

            userInfo = new UserInfo();
            userInfo.UserId = 100022;
            userInfo.UserName = "小红";
            list.Add(userInfo);

            var result = JsonDeserializeHelper<UserInfo>.Serialize(list);

            //这里只判断转换结果的长度，具体请参考返回数据
            Assert.IsTrue(result.Length > 0);
        }



    }

    /// <summary>
    /// 用户信息
    /// </summary>
    [Serializable]
    public class UserInfo
    {
        private int _userId;
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private string _userName;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

    }

}
