using System.Linq;
using Atata;

namespace SimpleAutomationCommon.Pages
{
    using _ = CheckOutShippingPage;

    public class CheckOutShippingPage : BasePage<_>
    {
        [FindByName("shippingAddressId")] 
        private ControlList<Label<_>, _> AllAddress { get; set; }

        [FindByName("NewAddressForm.ContactName")]
        private TextInput<_> ContactName { get; set; }

        [FindById("NewAddressForm_CountryId")] 
        private Select<string, _> Country { get; set; }

        [FindById("NewAddressForm_StateOrProvinceId")]
        private Select<string, _> State { get; set; }

        [FindById("NewAddressForm_DistrictId")]
        private Label<_> District { get; set; }

        [FindById("NewAddressForm_City")] 
        private Label<_> City { get; set; }

        [FindById("NewAddressForm_ZipCode")] 
        private Label<_> ZipCode { get; set; }

        [FindById("NewAddressForm_AddressLine1")]
        private TextInput<_> Address { get; set; }

        [FindById("NewAddressForm_Phone")] 
        private TextInput<_> PhoneNumber { get; set; }

        [FindByXPath("//button[@class='btn btn-order']")]
        private Button<_> ContinueButton { get; set; }

        public void ChooseAddress()
        {
            if (AllAddress.Any())
            {
                AllAddress.First().Click();
            }
            else
            {
                AllAddress.Last().Click();
            }
        }

        public bool IsLoaded() => ContinueButton.IsVisible;

        public void FillAddressForm(string contactName, string country, string state, string address,
            string phoneNumber)
        {
            if (ContactName.IsVisible)
            {
                ContactName.Set(contactName);
                SelectCountry(country);
                SelectState(state);
                Address.Set(address);
                PhoneNumber.Set(phoneNumber);
            }
        }

        public void SelectCountry(string country) => Country.Set(country);

        public void SelectState(string state) => State.Set(state);

        public void Submit() => ContinueButton.Click();
    }
}