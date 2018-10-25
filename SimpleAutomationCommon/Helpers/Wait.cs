namespace SimpleAutomationCommon.Helpers
{
    using System;

    public static class Wait
    {
        public static void For(Func<bool> condition, Action callBack = null, string message = "", double timeout = -1)
            => Actions.Persist(
                () =>
                {
                    if (!condition())
                    {
                        throw new Exception("Condition wasn't reached in specified timeout");
                    }
                }, callBack, message, timeout);

        public static void ForActionResult(Action action, Func<bool> result, string message = "", double timeout = -1)
            => Actions.Persist(
                () =>
                {
                    action();
                    if (!result())
                    {
                        throw new Exception("Condition wasn't reached in specified timeout");
                    }
                }, null, message, timeout);
    }
}