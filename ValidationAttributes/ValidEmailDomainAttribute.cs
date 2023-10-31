using System.ComponentModel.DataAnnotations;

namespace WebAppDemo4._0.ValidationAttributes
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string allowDomain;

        public ValidEmailDomainAttribute(string allowDomain)
        {
            this.allowDomain = allowDomain;
        }
        public override bool IsValid(object value)
        {
            string[] str = value.ToString().Split("@");
            return str[1].ToLower() == allowDomain.ToLower();
        }
    }
}
