namespace SimpleAutomationCommon.Pages.LoginPg
{
    using Atata;
    using DataModels.Users;
    using Helpers.Extensions;
    using _ = LoginPage;

    [Url("login")]
    public class LoginPage : BasePage<_>
    {
        [FindById("Email")]
        private EmailInput<_> LoginInput { get; set; }

        [FindByName("Password")]
        private PasswordInput<_> PasswordInput { get; set; }

        [FindByName("RememberMe")]
        private CheckBox<_> RememberMeCheckBox { get; set; }

        [FindByXPath("//button[.='Log in']")]
        private Button<_> LoginButton { get; set; }

        [FindByXPath("//div[@class='text-danger validation-summary-errors']//li")]
        private Text<_> Error { get; set; }

        public LoginPage FillAndSubmit(User user)
        {
            FillForm(user.Email.Value, user.Password);
            Submit();
            return this;
        }

        public LoginPage FillAndSubmit(string email, string password)
        {
            FillForm(email, password);
            Submit();
            return this;
        }

        public LoginPage FillForm(string email, string password)
        {
            LoginInput.Set(email);
            PasswordInput.Set(password);
            return this;
        }

        public LoginPage Submit()
            => LoginButton.ClickAndGo<LoginPage>();

        public LoginPage SwitchRememberMe(bool side)
        {
            if (!RememberMeCheckBox.IsChecked && side)
            {
                RememberMeCheckBox.Click();
            }

            return this;
        }

        public string GetUser()
            => FullName.Get().Remove("Hello ", "!");

        public string GetError()
            => Error.Get();

        public bool IsLoaded()
            => LoginButton.Exists();

        public bool IsLoggedIn()
            => FullName.Exists();
    }
}