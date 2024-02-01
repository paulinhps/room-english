using AutoMapper;
using Microsoft.Extensions.Logging;
using RoomsEnglish.Application.SharedContext.UseCases;
using RoomsEnglish.Domain.PlayerContext.Entities;
using RoomsEnglish.Domain.PlayerContext.Repositories;
using RoomsEnglish.Domain.PlayerContext.Services;
using RoomsEnglish.Domain.SharedContext.Constants;

namespace RoomsEnglish.Application.PlayerContext.UseCases.LoginPlayer;

public class LoginPlayerHandler : HandlerBase<LoginPlayerCommand, DataApplicationResponse<LoginPlayerResult>>
{
    private readonly IPlayerRepository _userRepository;
    private readonly ISecurityService _securityService;
    private readonly ILogger<LoginPlayerHandler> _logger;
    private readonly IMapper _mapper;

    public LoginPlayerHandler(IPlayerRepository userRepository,
                        ISecurityService securityService,
                        IMapper mapper,
                        ILogger<LoginPlayerHandler> logger,
                        INotificationContext notificationContext) : base(notificationContext)
    {
        _userRepository = userRepository;
        _securityService = securityService;
        _logger = logger;
        _mapper = mapper;
    }
    public override async Task<DataApplicationResponse<LoginPlayerResult>> Handle(LoginPlayerCommand request, CancellationToken cancellationToken)
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
        if(!NotificationContext.ExistsNotifications) {

        string authToken = _securityService.GenerateToken(user!);

        var loginResult = new LoginPlayerResult(authToken);

        _mapper.Map(user, loginResult);

         return ApplicationResponses.CreateResponse(
            data: loginResult,
            responseType: EResponseType.Success, 
            $"authentication success"
            );

        }

        // 4 - Make a AuthUserResult
        
        return ApplicationResponses.CreateResponse<LoginPlayerResult>(
            responseType: EResponseType.ProccessError, 
            $"authentication failure", 
            NotificationContext.GetErrors()
            );
    }
    
}
