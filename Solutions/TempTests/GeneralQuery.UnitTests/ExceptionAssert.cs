using System;
using System.Diagnostics.CodeAnalysis;

namespace WitsWay.TempTests.GeneralQuery.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class ExceptionAssert
    {
        public static void Throws<T>(Action func) where T : Exception
        {
            var exceptionThrown = false;
            try
            {
                func.Invoke();
            }

            catch (T)
            {
                exceptionThrown = true;
            }
            catch (Exception)
            {
                // ignored
            }
            if (!exceptionThrown)
            {
                throw new Exception(
                    $"An exception of type {typeof(T)} was expected, but not thrown"
                );
            }
        }
    }
}
