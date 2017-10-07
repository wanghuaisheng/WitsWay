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
