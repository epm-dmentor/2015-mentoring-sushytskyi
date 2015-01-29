
namespace Epam.NetMentoring.Factory.UVAR
{
    public class ValidationError
    {
        public string ErrorText { get; private set; }

        public ValidationError(string errorText)
        {
            ErrorText = errorText;
        }
    }
}
