namespace SimpleAutomationCommon.Pages
{
    using Atata;
    using Helpers.Extensions;

    public class BasePage<TOwner> : Page<TOwner>
        where TOwner : BasePage<TOwner>
    {
        [FindByCss("a[href = '/login']")]
        protected Link<TOwner> Login { get; set; }

        [FindByCss("a[href = '/user']")]
        protected Label<TOwner> FullName { get; set; }

        [FindByCss("a[href = '/register']")]
        protected Link<TOwner> Register { get; set; }

        [FindByXPath("//a[contains(text(), 'Language')]")]
        protected Label<TOwner> Language { get; set; }

        [FindByXPath("//img[@alt = 'SimplCommerce']")]
        protected Label<TOwner> Logo { get; set; }

        [FindByCss("input.form-control")]
        protected Label<TOwner> Search { get; set; }

        [FindByCss("select.form-control")]
        protected Label<TOwner> CategorySelector { get; set; }

        [FindByCss("button.search-btn")]
        protected Label<TOwner> SearchButton { get; set; }

        [FindByCss("a[href='/cart']")]
        protected Label<TOwner> Cart { get; set; }

        [FindByXPath("//a[text()='Phones']")]
        protected Label<TOwner> Phones { get; set; }

        [FindByXPath("//a[text()='Tablets']")]
        protected Label<TOwner> Tablets { get; set; }

        [FindByXPath("//a[text()='Computers']")]
        protected Label<TOwner> Computers { get; set; }

        [FindByXPath("//a[text()='Accessories']")]
        protected Label<TOwner> Accessories { get; set; }

        [FindByCss("a[href='/help-center']")]
        protected Label<TOwner> HelpCenter { get; set; }

        [FindByCss("a[href='/help-center/how-to-buy']")]
        protected Label<TOwner> HowToBuy { get; set; }

        [FindByCss("a[href='/help-center/shipping']")]
        protected Label<TOwner> Shipping { get; set; }

        [FindByCss("a[href='/help-center/how-to-return']")]
        protected Label<TOwner> HowToReturn { get; set; }

        [FindByCss("a[href='/about-us']")]
        protected Label<TOwner> AboutUs { get; set; }

        [FindByCss("a[href='/terms-of-use']")]
        protected Label<TOwner> TermsOfUse { get; set; }

        [FindByCss("a[href='/privacy']")]
        protected Label<TOwner> Privacy { get; set; }

        [FindByXPath("//p[text()='© 2018 - SimplCommerce']")]
        protected Label<TOwner> CopyRights { get; set; }

        [FindByXPath("//p[text()='Powered by ']")]
        protected Label<TOwner> PoweredBy { get; set; }

        protected string GetUser()
        {
            var userName = FullName.Get();
            return userName.Remove("Hello ", "!");
        }
    }
}