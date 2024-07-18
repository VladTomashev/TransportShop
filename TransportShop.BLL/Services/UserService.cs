using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System.Security.Claims;
using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.BLL.Exceptions;
using TransportShop.BLL.Interfaces;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Enums;
using TransportShop.DAL.Interfaces;

namespace TransportShop.BLL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepo;
        private IRefreshTokenRepository tokenRepo;
        private IAccountRepository accountRepo;
        private ITokenService tokenService;
        private IValidator<SignInRequest> signInValidator;
        private IValidator<SignUpRequest> signUpValidator;
        private IMapper mapper;

        public UserService(IUserRepository userRepo, IRefreshTokenRepository tokenRepo,
            IAccountRepository accountRepo, ITokenService tokenService, IMapper mapper,
            IValidator<SignInRequest> signInValidator, IValidator<SignUpRequest> signUpValidator)
        {
            this.userRepo = userRepo;
            this.tokenRepo = tokenRepo;
            this.accountRepo = accountRepo;
            this.tokenService = tokenService;
            this.signInValidator = signInValidator;
            this.signUpValidator = signUpValidator;
            this.mapper = mapper;
        }

        public async Task<TokenResponse> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default)
        {
            await ValidateRequestAsync(signInValidator, request, cancellationToken);

            Account? account = await accountRepo.GetAccountByLoginAsync(request.Login, cancellationToken = default);
            if (account == null)
                throw new NotFoundException("User is not found");

            if (account.Password != request.Password)
                throw new BadRequestException("Wrong password");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Login),
                new Claim(ClaimTypes.Role, ((int)account.Role).ToString())
            };

            string newAccessTokenString = tokenService.GenerateAccessToken(claims);
            string newRefreshTokenString = tokenService.GenerateRefreshToken();

            RefreshToken? refreshToken = await tokenRepo.GetByIdAsync(account.Id, cancellationToken);
            if (refreshToken != null)
            {
                refreshToken.Token = newRefreshTokenString;
                refreshToken.LifeTime = DateTime.Now.AddDays(7);
                await tokenRepo.UpdateAsync(refreshToken);
            }
            else
            {
                RefreshToken newRefreshToken = new RefreshToken()
                {
                    Id = account.Id,
                    Account = account,
                    Token = newRefreshTokenString,
                    LifeTime = DateTime.Now.AddDays(7)
                };

                await tokenRepo.AddAsync(newRefreshToken);
            }

            return new TokenResponse
            {
                AccessToken = newAccessTokenString,
                RefreshToken = newRefreshTokenString
            };
        }

        public async Task<TokenResponse> SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default)
        {
            await ValidateRequestAsync(signUpValidator, request, cancellationToken);

            if (await accountRepo.GetAccountByLoginAsync(request.Login, cancellationToken) != null)
                throw new BadRequestException("Login is already in use");

            Account account = mapper.Map<Account>(request);
            account.Role = Role.User;

            await accountRepo.AddAsync(account, cancellationToken = default);

            User user = mapper.Map<User>(request);
            user.Id = account.Id;
            user.Account = account;

            await userRepo.AddAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Login),
                new Claim(ClaimTypes.Role, ((int)account.Role).ToString())
            };

            string newAccessTokenString = tokenService.GenerateAccessToken(claims);
            string newRefreshTokenString = tokenService.GenerateRefreshToken();

            RefreshToken newRefreshToken = new RefreshToken()
            {
                Id = account.Id,
                Account = account,
                Token = newRefreshTokenString,
                LifeTime = DateTime.Now.AddDays(7)
            };

            await tokenRepo.AddAsync(newRefreshToken);

            return new TokenResponse
            {
                AccessToken = newAccessTokenString,
                RefreshToken = newRefreshTokenString
            };
        }

        public async Task<TokenResponse> RefreshTokenAsync(TokenRequest request, CancellationToken cancellationToken = default)
        {
            string requestAccessToken = request.AccessToken;
            string requestRefreshToken = request.RefreshToken;

            var principal = tokenService.GetPrincipalFromExpiredToken(requestAccessToken);
            string login = principal.Identity.Name;

            Account? account = await accountRepo.GetAccountByLoginAsync(login, cancellationToken);
            if (account == null)
                throw new NotFoundException("User is not found");

            RefreshToken refreshToken = await tokenRepo.GetByIdAsync(account.Id, cancellationToken);
            if (refreshToken.Token != requestRefreshToken)
                throw new BadRequestException("Incorrect refresh token");

            if (refreshToken.LifeTime <= DateTime.Now)
                throw new BadRequestException("The token has expired, please log in again");

            string newAccessToken = tokenService.GenerateAccessToken(principal.Claims);
            string newRefreshToken = tokenService.GenerateRefreshToken();

            refreshToken.Token = newRefreshToken;
            await tokenRepo.UpdateAsync(refreshToken);

            return new TokenResponse()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        public async Task<int> GetMyIdByJwtAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default)
        {
            string? login = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (login == null)
                throw new NotFoundException("User is not found");

            Account? account = await accountRepo.GetAccountByLoginAsync(login, cancellationToken = default);
            if (account == null)
                throw new NotFoundException("Account is not found");

            return account.Id;
        }

        public async Task<UserProfileResponse> GetMyProfileByJwtAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default)
        {
            string? login = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (login == null)
                throw new NotFoundException("User is not found");

            Account? account = await accountRepo.GetAccountByLoginAsync(login, cancellationToken = default);
            if (account == null)
                throw new NotFoundException("Account is not found");

            User? profile = await userRepo.GetByIdAsync(account.Id, cancellationToken = default);
            if (profile == null)
                throw new NotFoundException("Profile is not found");

            return new UserProfileResponse()
            {
                Name = profile.Name,
                Address = profile.Address,
                Phone = profile.Phone,
            };
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<User> users = await userRepo.GetAllAsync(cancellationToken = default);
            if (users == null || !users.Any())
                throw new NotFoundException("Users not found");
            return users;
        }

        public async Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            User user = await userRepo.GetByIdAsync(id, cancellationToken = default);
            if (user == null)
                throw new NotFoundException("User is not found");
            return user;
        }

        public async Task DeleteUserAsync(int id, CancellationToken cancellationToken = default)
        {
            User user = await userRepo.GetByIdAsync(id, cancellationToken = default);
            if (user == null)
                throw new NotFoundException("User is not found");
            await userRepo.DeleteAsync(id, cancellationToken = default);
        }

        private async Task ValidateRequestAsync<T>(IValidator<T> validator, T request, CancellationToken cancellationToken)
        {
            ValidationResult result = await validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                throw new BadRequestException(errors);
            }
        }
    }
}
