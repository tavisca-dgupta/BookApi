using FluentValidation;
using WebApiStart.Model;

namespace WebApiStart
{
    public class RequestValidator:AbstractValidator<Book>
    {
        public RequestValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithErrorCode("101").WithMessage("Name should not be empty or null");
            RuleFor(b => b.Author).NotEmpty().WithErrorCode("102").WithMessage("Author should not be empty or null");
            RuleFor(b => b.Price).NotEmpty().WithErrorCode("103").WithMessage("Price should not be empty or null");
            RuleFor(b => b.Name).Must(IsAValidName).WithErrorCode("104").WithMessage("Name cannot contain digits");
            RuleFor(b => b.Author).Must(IsAValidName).WithErrorCode("105").WithMessage("Author name cannot contain digits");
            RuleFor(b => b.Price).Must(IsPositive).WithErrorCode("106").WithMessage("Price cannot be negetive");
        }

        public bool IsAValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            foreach (char n in name)
            {
                if (char.IsDigit(n))
                    return false;
            }
            return true;
        }

        public bool IsPositive(int price)
        {
            if(price>0)
            {
                return true;
            }
            return false;
        }
    }
}
