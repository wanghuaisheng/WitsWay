/******************************************
 * 2012��5��3�� ������ ���
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
    /// XML���л�������
    /// </summary>
    [TestClass]
    public class SerilizeHelperTests
    {

        /// <summary>
        /// JSONת��Ϊʵ��
        /// </summary>
        [TestMethod]
        public void DeserilizeJsonTest()
        {
            var json = "{UserId:100021,UserName:\"С��\"}";
            var result = SerilizeHelper.DeserilizeJson<UserInfo>(json);
            Assert.IsTrue(result.UserId == 100021);
        }

        /// <summary>
        /// ʵ��ת��ΪJSON
        /// </summary>
        [TestMethod]
        public void SerilizeToJson1Test()
        {
            //��ת���Ķ���
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "С��";

            var result = SerilizeHelper.SerilizeToJson(userInfo);

            //����ֻ�ж�ת������ĳ��ȣ�������ο���������
            Assert.IsTrue(result.Length > 0);
        }

        /// <summary>
        /// ʵ��תJSON����2
        /// </summary>
        [TestMethod]
        public void SerilizeToJson2Test()
        {
            //��ת���Ķ���
            var list = new List<UserInfo>();

            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "С��";
            list.Add(userInfo);

            userInfo = new UserInfo();
            userInfo.UserId = 100022;
            userInfo.UserName = "С��";
            list.Add(userInfo);

            var result = SerilizeHelper.SerilizeToJson<UserInfo>(list);

            //����ֻ�ж�ת������ĳ��ȣ�������ο���������
            Assert.IsTrue(result.Length > 0);
        }

        /// <summary>
        /// ����ת��ΪXML
        /// </summary>
        [TestMethod]
        public void SerilizeToXMLTest()
        {
            //��ת���Ķ���
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "С��";

            var result1 = SerilizeHelper.SerilizeToXML(userInfo);
            var result2 = SerilizeHelper.SerilizeToXML(userInfo, Encoding.UTF8);

            Assert.IsTrue(result1 == result2);
        }
        
        /// <summary>
        /// XMLת��Ϊ����
        /// </summary>
        [TestMethod]
        public void DeserilizeXMLTest()
        {
            //��ת���Ķ���
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "С��";

            var result = SerilizeHelper.SerilizeToXML(userInfo);

            var result1 = SerilizeHelper.DeserilizeXML<UserInfo>(result);
            var result2 = SerilizeHelper.DeserilizeXML<UserInfo>(result, Encoding.UTF8);

            Assert.IsTrue(result1.UserId == 100021);
            Assert.IsTrue(result2.UserId == 100021);
        }
        
        /// <summary>
        /// ʵ��ת��ΪXML�ļ�
        /// </summary>
        [TestMethod]
        public void SerilizeToFileTest()
        {
            var path = "d:\\��ʱ�ļ�\\xiaoming" + DateTime.Now.ToString("MMddHHmmssffff") + ".xml";

            //��ת���Ķ���
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "С��";

            SerilizeHelper.SerilizeToFile(userInfo, path);
            Assert.IsTrue(File.Exists(path));
        }

        /// <summary>
        /// XML�ļ�ת����ʵ��
        /// </summary>
        [TestMethod]
        public void DeserilizeFileTest()
        {
            //�ȴ����ļ�
            var path = "d:\\��ʱ�ļ�\\xiaoming" + DateTime.Now.ToString("MMddHHmmssffff") + ".xml";
            //��ת���Ķ���
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "С��";
            SerilizeHelper.SerilizeToFile(userInfo, path);

            var result= SerilizeHelper.DeserilizeFile<UserInfo>(path);
            Assert.IsTrue(result.UserId==100021);
        }
        

        /// <summary>
        /// BinaryFormatter���л�
        /// </summary>
        [TestMethod]
        public void SerilizeToStreamBinaryTest()
        {
            //��ת���Ķ���
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "С��";

            var result1 = SerilizeHelper.SerilizeToStreamBinary(userInfo);
            var result2 = SerilizeHelper.SerilizeToStreamBinary(userInfo, Encoding.Default);

            Assert.IsTrue(result1.Length > 0);
            Assert.IsTrue(result1 == result2);
        }

        /// <summary>
        /// �����л�StreamBinary������
        /// </summary>
        [TestMethod]
        public void DeserilizeStreamBinaryTest()
        {
            //��ת���Ķ���
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "С��";
            //�����л�ΪStreamBinary
            var result1 = SerilizeHelper.SerilizeToStreamBinary(userInfo);
            //�ٷ����л�
            var result2 = SerilizeHelper.DeserilizeStreamBinary<UserInfo>(result1);
            var result3 = SerilizeHelper.DeserilizeStreamBinary<UserInfo>(result1, Encoding.Default);

            Assert.IsTrue(result1.Length > 0);
            Assert.IsTrue(result2.UserId == 100021);
            Assert.IsTrue(result3.UserId == 100021);
        }
        
        /// <summary>
        /// MemoryStream��String�໥ת��
        /// </summary>
        [TestMethod]
        public void StreamInterconversionStringTest()
        {
            //��ת���Ķ���
            var objStr = "��ת���Ķ���";

            //�����л�ΪMemoryStream
            var result1 = SerilizeHelper.StringToStream(objStr, Encoding.Default);

            //��ת��Ϊstring
            var result2 = SerilizeHelper.StreamToString(result1, Encoding.Default);

            Assert.IsTrue(result2 == "��ת���Ķ���");
        }

        /// <summary>
        /// ���л�Ϊbyte����
        /// </summary>
        [TestMethod]
        public void SerilizeToBytesTest()
        {
            //��ת���Ķ���
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "С��";

            var result1 = SerilizeHelper.SerilizeToBytes(userInfo);

            Assert.IsTrue(result1.Length > 0);
        }
        
        /// <summary>
        /// ��byte���鷴���л�������
        /// </summary>
        [TestMethod]
        public void DeserilizeFromBytesTest()
        {
            //��ת���Ķ���
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "С��";
            //�����л�Ϊ����
            var result1 = SerilizeHelper.SerilizeToBytes(userInfo);
            //�ٷ����л�
            var result2 = SerilizeHelper.DeserilizeFromBytes<UserInfo>(result1);

            Assert.IsTrue(result2.UserId == 100021);
        }
        
    }
}
