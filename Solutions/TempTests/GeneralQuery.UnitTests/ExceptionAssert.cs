﻿using System;
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
            catch (Exception ex)
            {

            }
            if (!exceptionThrown)
            {
                throw new Exception(
                    string.Format("An exception of type {0} was expected, but not thrown", typeof(T))
                    );
            }
        }
    }
}
