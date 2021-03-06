﻿using System.Collections.Generic;
using Atata;
using SimpleAutomationCommon.DataModels.Users;
using SimpleAutomationCommon.Helpers.Extensions;

namespace SimpleAutomationCommon.Pages.RegistrationPg
{
    using _ = RegistrationPage;

    [Url("register")]
    public class RegistrationPage : BasePage<_>
    {
        [FindById("Email")]
        private EmailInput<_> EmailInput { get; set; }

        [FindById("FullName")]
        private TextInput<_> FullNameInput { get; set; }

        [FindById("Password")]
        private PasswordInput<_> PasswordInput { get; set; }

        [FindById("ConfirmPassword")]
        private PasswordInput<_> ConfirmPasswordInput { get; set; }

        [FindByXPath("//button[.='Register']")]
        private Button<_> RegisterButton { get; set; }

        [FindByXPath("//button[@value='Facebook']")]
        private Button<_> LoginWithFacebook { get; set; }

        [FindByXPath("//button[@value='Google']")]
        private TextInput<_> LoginWithGoogle { get; set; }

        [FindByXPath("//div[@class='text-danger validation-summary-errors']//li")]
        private Text<_> ErrorMessage { get; set; }

        [FindById("Email-error")]
        private Text<_> EmailError { get; set; }

        [FindById("FullName-error")]
        private Text<_> FullNameError { get; set; }

        [FindById("Password-error")]
        private Text<_> PasswordError { get; set; }

        [FindById("ConfirmPassword-error")]
        private Text<_> ConfirmPasswordError { get; set; }

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

        public RegistrationPage FillAndSubmit(User user)
        {
            FillForm(user);
            Submit();
            return this;
        }

        public RegistrationPage FillAndSubmit(string email, string fullName, string password, string cpassword)
        {
            FillForm(email, fullName, password, cpassword);
            Submit();
            return this;
        }

        public RegistrationPage FillForm(User user)
        {
            EmailInput.Clear();
            EmailInput.Set(user.Email.Value);
            FullNameInput.Clear();
            FullNameInput.Set(user.FullName);
            PasswordInput.Clear();
            PasswordInput.Set(user.Password);
            ConfirmPasswordInput.Clear();
            ConfirmPasswordInput.Set(user.Password);
            return this;
        }

        public RegistrationPage FillForm(string email, string fullName, string password, string cpassword)
        {
            EmailInput.Clear();
            EmailInput.Set(email);
            FullNameInput.Clear();
            FullNameInput.Set(fullName);
            PasswordInput.Clear();
            PasswordInput.Set(password);
            ConfirmPasswordInput.Clear();
            ConfirmPasswordInput.Set(cpassword);
            return this;
        }

        public RegistrationPage Submit()
            => RegisterButton.ClickAndGo<RegistrationPage>();

        public bool IsLoaded()
            => RegisterButton.Exists();

        public string GetUser()
            => FullName.Get().Remove("Hello ", "!");

        public bool IsRegistered() => FullName.IsVisible;
    }
}