using System.Net.Mail;

namespace SimpleAutomationCommon.DataModels
{
    public class Email
    {
        public string Value { get; }

        public Email(string value)
        {
            Value = IsValid(value) ? value : string.Empty;
        }

        private static bool IsValid(string email)
        {
            try
            {
                return new MailAddress(email).Address.Length > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}