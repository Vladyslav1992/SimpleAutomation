namespace SimpleAutomationCommon.Pages.RegistrationPg
{
    using System.Collections.Generic;
    using Atata;
    using DataModels.Users;
    using _ = RegistrationPage;

    [Url("register")]
    public class RegistrationPage : BasePage<_>
    {
        [FindById("Email")]
        private EmailInput<_> EmailInput { get; set; }

        [FindById("FullName")]
        private TextInput<_> FullNameInput { get; set; }

        [FindById("Password")]
        private TextInput<_> PasswordInput { get; set; }

        [FindById("ConfirmPassword")]
        private TextInput<_> ConfirmPasswordInput { get; set; }

        [FindByXPath("//button[.='Register']")]
        private Button<_> RegisterButton { get; set; }

        [FindByXPath("//button[@value='Facebook']")]
        private Button<_> LoginWithFacebook { get; set; }

        [FindByXPath("//button[@value='Google']")]
        private TextInput<_> LoginWithGoogle { get; set; }

        [FindByXPath("//div[@class='text-danger validation-summary-errors']//li")]
        private Label<_> ErrorMessage { get; set; }

        [FindById("Email-error")]
        public Label<_> EmailError { get; set; }

        [FindById("FullName-error")]
        private Label<_> FullNameError { get; set; }

        [FindById("Password-error")]
        private Label<_> PasswordError { get; set; }

        [FindById("ConfirmPassword-error")]
        private Label<_> ConfirmPasswordError { get; set; }

        public IEnumerable<string> GetErrors()
        {
            var errors = new List<string>();

            if (ErrorMessage.IsVisible)
            {
                errors.Add(ErrorMessage.Get());
            }

            if (EmailError.IsVisible)
            {
                errors.Add(EmailError.Get());
            }

            if (FullNameError.IsVisible)
            {
                errors.Add(FullNameError.Get());
            }

            if (PasswordError.IsVisible)
            {
                errors.Add(PasswordError.Get());
            }

            if (ConfirmPasswordError.IsVisible)
            {
                errors.Add(ConfirmPasswordError.Get());
            }

            return errors;
        }

        public void FillAndSubmit(User user)
        {
            FillForm(user);
            Submit();
        }

        public void FillAndSubmit(string email, string fullName, string password, string cpassword)
        {
            FillForm(email, fullName, password, cpassword);
            Submit();
        }

        public void FillForm(User user)
        {
            EmailInput.Clear();
            EmailInput.Set(user.Email.Value);
            FullNameInput.Clear();
            FullNameInput.Set(user.FullName);
            PasswordInput.Clear();
            PasswordInput.Set(user.Password);
            ConfirmPasswordInput.Clear();
            ConfirmPasswordInput.Set(user.Password);
        }

        public void FillForm(string email, string fullName, string password, string cpassword)
        {
            EmailInput.Clear();
            EmailInput.Set(email);
            FullNameInput.Clear();
            FullNameInput.Set(fullName);
            PasswordInput.Clear();
            PasswordInput.Set(password);
            ConfirmPasswordInput.Clear();
            ConfirmPasswordInput.Set(cpassword);
        }

        public void Submit()
            => RegisterButton.Click();

        public bool IsLoaded()
            => RegisterButton.Exists();

        public bool IsRegistered() => FullName.IsVisible;
    }
}