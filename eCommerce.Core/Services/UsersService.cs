using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _userRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponseDTO?> Login(LoginRequestDTO loginRequestDTO)
        {
            ApplicationUser? user=  await _userRepository.GetUserByEmailAnPasswordAsync(loginRequestDTO.Email, loginRequestDTO.Password);
            if (user == null)
            {
                return null;
            }
            //return new AuthenticationResponseDTO(user.UserId,user.Email, user.PersonName,user.Gender,"token", Success:true);
            return _mapper.Map<AuthenticationResponseDTO>(user) with { Success = true, Token ="token"}; 
        }

        public async Task<AuthenticationResponseDTO?> Register(RegisterRequestDTO registerRequestDTO)
        {
            //ApplicationUser user = new ApplicationUser()
            //{
            //    PersonName = registerRequestDTO.PersonName,
            //    Email = registerRequestDTO.Email,
            //    Password = registerRequestDTO.Password,
            //    Gender = registerRequestDTO.Gender.ToString()
            //};
            ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequestDTO);
            ApplicationUser? registeredUser = await _userRepository.AddUserAsync(user);
            if (registeredUser == null)
            {
                return null;
            }
            //return new AuthenticationResponseDTO(
            //    registeredUser.UserId,
            //    registeredUser.Email,
            //    registeredUser.PersonName,
            //    registeredUser.Gender,"token",Success:true
            //    );
            return _mapper.Map<AuthenticationResponseDTO>(registeredUser) with
            {
                Success = true,
                Token = "token"
            };
        }
    }
}
