using AutoMapper;
using Microsoft.Extensions.Logging;
using RoomsEnglish.Application.SharedContext.UseCases;
using RoomsEnglish.Domain.AccountContext.Repositories;
using RoomsEnglish.Domain.AccountContext.Services;
using RoomsEnglish.Domain.SharedContext.Constants;
using RoomsEnglish.Domain.UserContext.Entities;

namespace RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;

public class LoginHandler : HandlerBase<LoginCommand, DataApplicationResponse<LoginResult>>
{
    private readonly IPlayerRepository _userRepository;
    private readonly ISecurityService _securityService;
    private readonly ILogger<LoginHandler> _logger;
    private readonly IMapper _mapper;

    public LoginHandler(IPlayerRepository userRepository,
                        ISecurityService securityService,
                        IMapper mapper,
                        ILogger<LoginHandler> logger,
                        INotificationContext notificationContext) : base(notificationContext)
    {
        _userRepository = userRepository;
        _securityService = securityService;
        _logger = logger;
        _mapper = mapper;
    }
    public override async Task<DataApplicationResponse<LoginResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implements a AuthHandler
        // 1 - Check If Command is Valid (We will use a Behiavor process)
        // 2 - Validate User Credentials
        IApplicationUser? user = default!;

        try
        {
            user = await _userRepository.FindPlayerByEmailAsync(request.Username, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "an error occur on find player by email");
            
            NotificationContext.AddNotification("FindPlayerByEmail", "an error occur on find player by email");
        }

        if (!_securityService.IsValidUser(user, request.Password))
        {
            _logger.LogError("user name or password is invalid");
            
            NotificationContext.AddNotification("LoginError", "user name or password is invalid");

        }
        // 3 - Generate AuthToken
        string authToken = _securityService.GenerateToken(user!);

        var loginResult = new LoginResult(authToken);

        _mapper.Map(user, loginResult);

        // 4 - Make a AuthUserResult
        
        return ApplicationResponses.CreateResponse(
            data: loginResult, 
            responseType: NotificationContext.ExistsNotifications ? EResponseType.ProccessError : EResponseType.Success, 
            $"authentication {(NotificationContext.ExistsNotifications ? "success" : "failere")}", 
            NotificationContext.GetErrors()
            );
    }
    
}
