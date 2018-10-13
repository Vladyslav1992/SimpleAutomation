using Atata;

namespace SimpleAutomationCommon.Pages
{
    public abstract class Page1<TOwner> : Page<TOwner>
        where TOwner : Page1<TOwner>
    {
    }
}
