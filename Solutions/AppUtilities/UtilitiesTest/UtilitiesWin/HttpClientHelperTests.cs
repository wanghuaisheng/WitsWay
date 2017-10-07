using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Win.Helpers;
using WitsWay.Utlities.Tests.UtilitiesWin.Entities;

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
                LoginTypeEnum = LoginTypeEnum.Shop
            };
            var cookies = HttpClientHelper.HttpPostRequestCookies(urlLogin, loginPara);
            var cookie = cookies[0];
            var result = HttpClientHelper.HttpPostRequestString(urlSearch, para22, cookie);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));

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
                corpid="1000",
                WeChatSendTasks=list
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
        public SendSalaryMessageEntity() { }

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