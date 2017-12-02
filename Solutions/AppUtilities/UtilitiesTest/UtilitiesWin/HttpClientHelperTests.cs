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
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Web.Extends;
using WitsWay.Utilities.Web.Helpers;
using WitsWay.Utilities.Win.Helpers;
using WitsWay.Utlities.Tests.UtilitiesWin.Entities;
using System.Drawing.Imaging;

namespace WitsWay.Utlities.Tests.UtilitiesWin
{

    [TestClass]
    public class HttpClientHelperTests : Attribute
    {


        [TestMethod]
        public void DoHttpPostTest()
        {
            var urlLogin = "http://192.168.7.70/api/eshop/authorize/login";
            var urlSearch = "http://192.168.7.70/api/customerPreorder/search";
            var para22 = new GridSearchParameter<CustomerPreorderFilter>
            {
                Pager = new PageParameter { PageIndex = 1, PageSize = 20, SortColumns = new List<SortColumn>() },
                Filter = new CustomerPreorderFilter { IsLoad = true }
            };
            var loginPara = new ShopLoginPost()
            {
                CorpCode = "0280003",
                UserName = "admin",
                Password = "111111",
                Remember = false,
                LoginTypeEnum =LoginTypeEnum.Shop
            };
            var cookies = HttpClientHelper.HttpPostRequestCookies(urlLogin, loginPara);
            var cookie = cookies[0];
            var result = HttpClientHelper.HttpPostRequestString(urlSearch, para22, cookie);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));

        }

        [TestMethod]
        public void HttpRequestImageTest()
        {
            var urlImg = "https://github.com/wanghuaisheng/Articles/blob/master/OutMan/OutMan.png?raw=true";
            var uri = new Uri(urlImg);
            var img = uri.UriToImage();
            img.Save(@"D:\1.png", ImageFormat.Png);
            var stream = HttpClientHelper.HttpGetRequestStream(urlImg);
            var img2 = Image.FromStream(stream);
            img2.Save(@"D:\2.png", ImageFormat.Png);
            Assert.IsTrue(true);

        }

        [TestMethod]
        public void DoHttpPostTest2()
        {
            var urlSearch = "http://www.deberp.com:69/api/SendApi/InsetSendtask";
            var list = new List<SendSalaryMessageEntity>
            {
                new SendSalaryMessageEntity { MessageContent="MessageContent",MessageTitle="MessageTitle",WeChat="WeChat"}
            };

            var para = new SendSalaryPara
            {
                corpid = "1000",
                WeChatSendTasks = list
            };
            var result = HttpClientHelper.HttpPostRequestString(urlSearch, para);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));

        }

    }


    public class SendSalaryPara
    {
        public string corpid { get; set; }

        public List<SendSalaryMessageEntity> WeChatSendTasks { get; set; }
    }
    // 摘要: 
    //     发送工资条消息实体
    public class SendSalaryMessageEntity
    {

        // 摘要: 
        //     消息内容
        public string MessageContent { get; set; }
        //
        // 摘要: 
        //     消息标题
        public string MessageTitle { get; set; }
        //
        // 摘要: 
        //     微信用户ID
        public string WeChat { get; set; }
    }

}