 
namespace APEX.Common.Models
{
    public class AuthenticationResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
    }
}
