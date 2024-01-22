using MediatR;
using RoomsEnglish.Domain.AccountContext.Repositories;
using RoomsEnglish.Domain.AccountContext.Services;
using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Application.AccountContext.LoginIn;

public class LoginHandler : IRequestHandler<AuthUserCommand, AuthUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly ISecurityService _securityService;

    public LoginHandler(IUserRepository userRepository, ISecurityService securityService)
    {
        _userRepository = userRepository;
        _securityService = securityService;
    }
    public async Task<AuthUserResult> Handle(AuthUserCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implements a AuthHandler
        // 1 - Check If Command is Valid (We will use a Behiavor process)
        // 2 - Validate User Credentials
             ApplicationUser user = default!;

            try
            {
                user = await _userRepository.FindUserByEmailAsync(request.Username, cancellationToken);
                
            }
            catch (Exception ex)
            {
                 // TODO: Implements error results
            }

            if(!_securityService.IsValidUser(user)) {
                // TODO: Implements error results
            }
        // 3 - Generate AuthToken
            string authToken = await _securityService.GetAuthToken(user);

        // 4 - Make a AuthUserResult
        // TODO: Change this to Autommaper
         return new AuthUserResult() {
            AuthToken = authToken,
            UserId = user.Id,
            Message = "authentication success!"
         };
    }
}
