using MediatR;
using Microsoft.Extensions.Logging;
using RoomsEnglish.Domain.PlayerContext.Entities;
using RoomsEnglish.Domain.PlayerContext.Repositories;
using RoomsEnglish.Domain.PlayerContext.Services;

namespace RoomsEnglish.Application.PlayerContext.LoginPlayer;

public class LoginHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly IUserRepository _userRepository;
    private readonly ISecurityService _securityService;
    private readonly ILogger<LoginHandler> _logger;

    public LoginHandler(IUserRepository userRepository, ISecurityService securityService, ILogger<LoginHandler> logger)
    {
        _userRepository = userRepository;
        _securityService = securityService;
        _logger = logger;
    }
    public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implements a AuthHandler
        // 1 - Check If Command is Valid (We will use a Behiavor process)
        // 2 - Validate User Credentials
        IApplicationUser user = default!;

        try
        {
            user = await _userRepository.FindUserByEmailAsync(request.Username, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "an error occur on find player by email");
            // TODO: Implements error results
        }

        if (!_securityService.IsValidUser(user, request.Password))
        {
            // TODO: Implements error results
        }
        // 3 - Generate AuthToken
        string authToken = _securityService.GenerateToken(user);

        // 4 - Make a AuthUserResult
        // TODO: Change this to Autommaper
        return new LoginResult()
        {
            AuthToken = authToken,
            UserId = user.Id,
            Message = "authentication success!"
        };
    }
}
