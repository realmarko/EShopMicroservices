using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts;

public interface IUsersService
{
    /// <summary>
    /// Method to handle user login use case and returns an AuthenticationResponse
    /// </summary>
    /// <param name="loginRequestDTO"></param>
    /// <returns></returns>
    Task<AuthenticationResponseDTO?> Login(LoginRequestDTO loginRequestDTO);

    /// <summary>
    /// Method to handle user registration use case and return and object of AuthenticationResponse type that represents
    /// status of user registration
    /// </summary>
    /// <param name="registerRequestDTO"></param>
    /// <returns></returns>
    Task<AuthenticationResponseDTO?> Register(RegisterRequestDTO registerRequestDTO);
}
