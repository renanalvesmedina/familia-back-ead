using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Familia.Ead.Application.Utils
{
    public class Validators : IValidators
    {
        public bool IsValidEmail(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}
