using System;
using System.Diagnostics;
using System.Threading;

namespace SimpleAutomationCommon.Helpers
{
    public static class Actions
    {
        public static void Persist(Action action, Action callBack = null, string message = "", double timeout = -1)
        {
            Action persistor = null;
            if (callBack != null)
                persistor = () => TimedLoop(callBack.Invoke);
            TimedLoop(action, persistor, message, timeout);
        }

        private static void TimedLoop(Action action, Action callBack = null, string message = null, double timeout = -1)
        {
            Exception exception = null;
            if (timeout < 0)
                timeout = ConfigurationHelper.ElementTimeOut.TotalMilliseconds;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds <= timeout)
            {
                try
                {
                    action();
                    break;
                }
                catch (Exception lastException)
                {
                    exception = lastException;
                    if (callBack == null)
                        Thread.Sleep(ConfigurationHelper.RetryTimeOut);
                    else
                        callBack();
                }
            }
            stopwatch.Stop();
            if (exception != null && stopwatch.ElapsedMilliseconds >= timeout)
                throw new Exception(message, exception);
        }

        public static T Return<T>(Func<T> func, Action callBack = null, string message = "", double timeout = -1)
        {
            var result = default(T);
            Persist(() => result = func(), callBack, message, timeout);
            return result;
        }
    }
}