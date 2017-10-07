/******************************************
 * 2012年5月3日 王怀生 添加
 * 
 * ***************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{
    /// <summary>
    /// XML序列化辅助类
    /// </summary>
    [TestClass]
    public class SerilizeHelperTests
    {

        /// <summary>
        /// JSON转换为实体
        /// </summary>
        [TestMethod]
        public void DeserilizeJsonTest()
        {
            var json = "{UserId:100021,UserName:\"小明\"}";
            var result = SerilizeHelper.DeserilizeJson<UserInfo>(json);
            Assert.IsTrue(result.UserId == 100021);
        }

        /// <summary>
        /// 实体转换为JSON
        /// </summary>
        [TestMethod]
        public void SerilizeToJson1Test()
        {
            //待转换的对象
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";

            var result = SerilizeHelper.SerilizeToJson(userInfo);

            //这里只判断转换结果的长度，具体请参考返回数据
            Assert.IsTrue(result.Length > 0);
        }

        /// <summary>
        /// 实体转JSON测试2
        /// </summary>
        [TestMethod]
        public void SerilizeToJson2Test()
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

            var result = SerilizeHelper.SerilizeToJson<UserInfo>(list);

            //这里只判断转换结果的长度，具体请参考返回数据
            Assert.IsTrue(result.Length > 0);
        }

        /// <summary>
        /// 对象转换为XML
        /// </summary>
        [TestMethod]
        public void SerilizeToXMLTest()
        {
            //待转换的对象
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";

            var result1 = SerilizeHelper.SerilizeToXML(userInfo);
            var result2 = SerilizeHelper.SerilizeToXML(userInfo, Encoding.UTF8);

            Assert.IsTrue(result1 == result2);
        }
        
        /// <summary>
        /// XML转换为对象
        /// </summary>
        [TestMethod]
        public void DeserilizeXMLTest()
        {
            //待转换的对象
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";

            var result = SerilizeHelper.SerilizeToXML(userInfo);

            var result1 = SerilizeHelper.DeserilizeXML<UserInfo>(result);
            var result2 = SerilizeHelper.DeserilizeXML<UserInfo>(result, Encoding.UTF8);

            Assert.IsTrue(result1.UserId == 100021);
            Assert.IsTrue(result2.UserId == 100021);
        }
        
        /// <summary>
        /// 实体转换为XML文件
        /// </summary>
        [TestMethod]
        public void SerilizeToFileTest()
        {
            var path = "d:\\临时文件\\xiaoming" + DateTime.Now.ToString("MMddHHmmssffff") + ".xml";

            //待转换的对象
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";

            SerilizeHelper.SerilizeToFile(userInfo, path);
            Assert.IsTrue(File.Exists(path));
        }

        /// <summary>
        /// XML文件转换到实体
        /// </summary>
        [TestMethod]
        public void DeserilizeFileTest()
        {
            //先创建文件
            var path = "d:\\临时文件\\xiaoming" + DateTime.Now.ToString("MMddHHmmssffff") + ".xml";
            //待转换的对象
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";
            SerilizeHelper.SerilizeToFile(userInfo, path);

            var result= SerilizeHelper.DeserilizeFile<UserInfo>(path);
            Assert.IsTrue(result.UserId==100021);
        }
        

        /// <summary>
        /// BinaryFormatter序列化
        /// </summary>
        [TestMethod]
        public void SerilizeToStreamBinaryTest()
        {
            //待转换的对象
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";

            var result1 = SerilizeHelper.SerilizeToStreamBinary(userInfo);
            var result2 = SerilizeHelper.SerilizeToStreamBinary(userInfo, Encoding.Default);

            Assert.IsTrue(result1.Length > 0);
            Assert.IsTrue(result1 == result2);
        }

        /// <summary>
        /// 反序列化StreamBinary到对象
        /// </summary>
        [TestMethod]
        public void DeserilizeStreamBinaryTest()
        {
            //待转换的对象
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";
            //先序列化为StreamBinary
            var result1 = SerilizeHelper.SerilizeToStreamBinary(userInfo);
            //再反序列化
            var result2 = SerilizeHelper.DeserilizeStreamBinary<UserInfo>(result1);
            var result3 = SerilizeHelper.DeserilizeStreamBinary<UserInfo>(result1, Encoding.Default);

            Assert.IsTrue(result1.Length > 0);
            Assert.IsTrue(result2.UserId == 100021);
            Assert.IsTrue(result3.UserId == 100021);
        }
        
        /// <summary>
        /// MemoryStream与String相互转换
        /// </summary>
        [TestMethod]
        public void StreamInterconversionStringTest()
        {
            //待转换的对象
            var objStr = "待转换的对象";

            //先序列化为MemoryStream
            var result1 = SerilizeHelper.StringToStream(objStr, Encoding.Default);

            //再转换为string
            var result2 = SerilizeHelper.StreamToString(result1, Encoding.Default);

            Assert.IsTrue(result2 == "待转换的对象");
        }

        /// <summary>
        /// 序列化为byte数组
        /// </summary>
        [TestMethod]
        public void SerilizeToBytesTest()
        {
            //待转换的对象
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";

            var result1 = SerilizeHelper.SerilizeToBytes(userInfo);

            Assert.IsTrue(result1.Length > 0);
        }
        
        /// <summary>
        /// 从byte数组反序列化到对象
        /// </summary>
        [TestMethod]
        public void DeserilizeFromBytesTest()
        {
            //待转换的对象
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";
            //先序列化为数组
            var result1 = SerilizeHelper.SerilizeToBytes(userInfo);
            //再反序列化
            var result2 = SerilizeHelper.DeserilizeFromBytes<UserInfo>(result1);

            Assert.IsTrue(result2.UserId == 100021);
        }
        
    }
}
