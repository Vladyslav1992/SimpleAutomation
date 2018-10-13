using Atata;
using SimpleAutomationCommon.DataModels.Users;
using SimpleAutomationCommon.Helpers.Extensions;

namespace SimpleAutomationCommon.Pages.LoginPg
{
    using _ = LoginPage;

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
        private Label<_> Error { get; set; }

        public void FillAndSubmit(User user)
        {
            FillForm(user.Email.Value, user.Password);
            Submit();
        }
        
        public void FillAndSubmit(string email, string password)
        {
            FillForm(email, password);
            Submit();
        }

        public void FillForm(string email, string password)
        {
            LoginInput.Set(email);
            PasswordInput.Set(password);
            PasswordInput.RemoveFocus();
        }

        public void Submit()
            => LoginButton.Click();

        public void SwitchRememberMe(bool side)
        {
            if (!RememberMeCheckBox.IsChecked && side)
            {
                RememberMeCheckBox.Click();
            }
        }

        public string GetUser()
        {
            var userName = FullName.Get();
            return userName.Remove("Hello ", "!");
        }

        public string GetError() => Error.Get();

        public bool IsLoaded()
            => LoginButton.Exists();

        public bool IsLogedIn()
            => FullName.Exists();
    }
}