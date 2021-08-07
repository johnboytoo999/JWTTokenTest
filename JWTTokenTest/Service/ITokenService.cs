using JWTTokenTest.Models;

namespace JWTTokenTest.Service
{

    public interface ITokenservice    {
        bool ValidUser(LoginViewModel user);
    }

}
