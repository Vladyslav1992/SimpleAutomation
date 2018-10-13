using Atata;

namespace SimpleAutomationCommon.Pages
{
    [ControlDefinition("*")]
    public class Control1<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
