using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace SimpleAutomationCommon.Pages
{
    public class CheckOutShippingPage : BasePage
    {
        [FindsBy(How = How.Name, Using = "shippingAddressId")]
        private IList<IWebElement> _allAddress;

        [FindsBy(How = How.Name, Using = "NewAddressForm.ContactName")]
        private IWebElement _contactName;

        [FindsBy(How = How.Id, Using = "NewAddressForm_CountryId")]
        private IWebElement _country;

        [FindsBy(How = How.Id, Using = "NewAddressForm_StateOrProvinceId")]
        private IWebElement _state;

        [FindsBy(How = How.Id, Using = "NewAddressForm_DistrictId")]
        private IWebElement _district;

        [FindsBy(How = How.Id, Using = "NewAddressForm_City")]
        private IWebElement _city;

        [FindsBy(How = How.Id, Using = "NewAddressForm_ZipCode")]
        private IWebElement _zipCode;

        [FindsBy(How = How.Id, Using = "NewAddressForm_AddressLine1")]
        private IWebElement _address;

        [FindsBy(How = How.Id, Using = "NewAddressForm_Phone")]
        private IWebElement _phoneNumber;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-order']")]
        private IWebElement _continueButton;

        public void ChooseAddress()
        {
            if (_allAddress.Any())
            {
                _allAddress.First().Click();
            }

            else
            {
                _allAddress.Last().Click();
            }
        }

        public bool IsLoaded() => _continueButton.Displayed;

        public void FillAddressForm(string contactName, string country, string state, string address, string phoneNumber)
        {
            if (_contactName.Displayed)
            {
                _contactName.SendKeys(contactName);
                SelectCountry(country);
                SelectState(state);
                _address.SendKeys(address);
                _phoneNumber.SendKeys(phoneNumber);
            }
        }

        public void SelectCountry(string country)
        {   
            SelectElement countrySelect = new SelectElement(_country);
            countrySelect.SelectByText(country);
        }

        public void SelectState(string state)
        {
            SelectElement stateSelect = new SelectElement(_state);
            stateSelect.SelectByText(state);
        }

        public void Submit()
        {
            _continueButton.Submit();
        }
    }
}
