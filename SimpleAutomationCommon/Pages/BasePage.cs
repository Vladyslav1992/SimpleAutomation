using Atata;
using SimpleAutomationCommon.Helpers.Extensions;

namespace SimpleAutomationCommon.Pages
{
    public class BasePage<TOwner> : Page<TOwner>
        where TOwner : BasePage<TOwner>
    {
        [FindByCss("a[href = '/login']")]
        public Link<TOwner> Login { get; set; }

        [FindByCss("a[href = '/user']")]
        public Text<TOwner> FullName { get; set; }

        [FindByCss("a[href = '/register']")]
        public Link<TOwner> Register { get; set; }

        [FindByXPath("//a[contains(text(), 'Language')]")]
        public Label<TOwner> Language { get; set; }

        [FindByXPath("//img[@alt = 'SimplCommerce']")]
        public Label<TOwner> Logo { get; set; }

        [FindByCss("input.form-control")]
        public Label<TOwner> Search { get; set; }

        [FindByCss("select.form-control")]
        public Label<TOwner> CategorySelector { get; set; }

        [FindByCss("button.search-btn")]
        public Label<TOwner> SearchButton { get; set; }

        [FindByCss("a[href='/cart']")]
        public Label<TOwner> Cart { get; set; }

        [FindByXPath("//a[text()='Phones']")]
        public Label<TOwner> Phones { get; set; }

        [FindByXPath("//a[text()='Tablets']")]
        public Label<TOwner> Tablets { get; set; }

        [FindByXPath("//a[text()='Computers']")]
        public Label<TOwner> Computers { get; set; }

        [FindByXPath("//a[text()='Accessories']")]
        public Label<TOwner> Accessories { get; set; }

        [FindByXPath("//footer//a[@href='/woman']")]
        public Text<TOwner> Woman { get; set; }

        [FindByXPath("//footer//a[@href='/man']")]
        public Text<TOwner> Man { get; set; }

        [FindByXPath("//footer//a[@href='/shoes']")]
        public Text<TOwner> Shoes { get; set; }

        [FindByXPath("//footer//a[@href='/watches']")]
        public Text<TOwner> Watches { get; set; }

        [FindByXPath("//footer//a[@href='/help-center']")]
        public Text<TOwner> HelpCenter { get; set; }

        [FindByCss("a[href='/about-us']")]
        public Link<AboutUsPage, TOwner> AboutUs { get; set; }

        [FindByCss("a[href='/terms-of-use']")]
        public Text<TOwner> TermsOfUse { get; set; }

        [FindByXPath("//p[text()='© 2018 - SimplCommerce']")]
        public Label<TOwner> CopyRights { get; set; }

        [FindByXPath("//p[text()='Powered by ']")]
        public Label<TOwner> PoweredBy { get; set; }

        public string GetUser()
        {
            var userName = FullName.Get();
            return userName.Remove("Hello ", "!");
        }
    }
}