using System.Collections.Generic;
using Atata;
using SimpleAutomationCommon.DataModels.Users;

namespace SimpleAutomationCommon.Pages.RegistrationPg
{
    using _ = RegistrationPage;

    public class RegistrationPage : BasePage<_>
    {
        [FindById("Email")] 
        private EmailInput<_> _emailInput { get; set; }

        [FindById("FullName")] 
        private TextInput<_> _fullNameInput { get; set; }

        [FindById("Password")] 
        private TextInput<_> _passwordInput { get; set; }

        [FindById("ConfirmPassword")] 
        private TextInput<_> _confirmPasswordInput { get; set; }

        [FindByXPath("//button[.='Register']")]
        private Button<_> _registerButton { get; set; }

        [FindByXPath("//button[@value='Facebook']")]
        private Button<_> _loginWithFacebook { get; set; }

        [FindByXPath("//button[@value='Google']")]
        private TextInput<_> _loginWithGoogle { get; set; }

        [FindByXPath("//div[@class='text-danger validation-summary-errors']//li")]
        private Label<_> _errorMessage { get; set; }

        [FindById("Email-error")] 
        private Label<_> _emailError { get; set; }

        [FindById("FullName-error")] 
        private Label<_> _fullNameError { get; set; }

        [FindById("Password-error")] 
        private Label<_> _passwordError { get; set; }

        [FindById("ConfirmPassword-error")] 
        private Label<_> _confirmPasswordError { get; set; }

        public IEnumerable<string> GetErrors()
        {
            var errors = new List<string>();

            if (_errorMessage.IsVisible)
            {
                errors.Add(_errorMessage.Get());
            }

            if (_emailError.IsVisible)
            {
                errors.Add(_emailError.Get());
            }

            if (_fullNameError.IsVisible)
            {
                errors.Add(_fullNameError.Get());
            }

            if (_passwordError.IsVisible)
            {
                errors.Add(_passwordError.Get());
            }

            if (_confirmPasswordError.IsVisible)
            {
                errors.Add(_confirmPasswordError.Get());
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
            _emailInput.Clear();
            _emailInput.Set(user.Email.Value);
            _fullNameInput.Clear();
            _fullNameInput.Set(user.FullName);
            _passwordInput.Clear();
            _passwordInput.Set(user.Password);
            _confirmPasswordInput.Clear();
            _confirmPasswordInput.Set(user.Password);
        }

        public void FillForm(string email, string fullName, string password, string cpassword)
        {
            _emailInput.Clear();
            _emailInput.Set(email);
            _fullNameInput.Clear();
            _fullNameInput.Set(fullName);
            _passwordInput.Clear();
            _passwordInput.Set(password);
            _confirmPasswordInput.Clear();
            _confirmPasswordInput.Set(cpassword);
        }

        public void Submit()
            => _registerButton.Click();

        public bool IsLoaded()
            => _registerButton.Exists();
       
        public bool IsRegistered() => FullName.IsVisible;
    }
}