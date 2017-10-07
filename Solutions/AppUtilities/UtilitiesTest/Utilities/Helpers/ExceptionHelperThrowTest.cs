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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Helpers;
using WitsWay.Utilities.Providers.ParseProviders;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{
    [TestClass]
    public class ExceptionHelperThrowTest
    {


        /// <summary>
        /// 抛出业务异常测试
        /// </summary>
        [TestMethod]
        public void ThrowBusinessExceptionTest()
        {
            WinUtilityHelper.HandleException(ClientMethod);
        }

        private void ClientMethod()
        {
            ExceptionHelper.HandleExceptionClient(ServiceMethod);
        }

        private void ServiceMethod()
        {
            ExceptionHelper.HandleExceptionService(LogicMethod);
        }

        private void LogicMethod()
        {
            throw ExceptionHelper.GetBusinessException(UtilityErrors.NotSupportParseProvider, JsonParseProvider.ProviderName);
        }

    }
}
