
using RoomsEnglish.Api.Endpoints.User;

namespace RoomsEnglish.Api.DependencyInjection
{
    public static class CommonsInjectionsExtensions
    {
        public static WebApplication MapApiEndPoints(this WebApplication app)
        {
            app.MapUsersEndpoints();
            return app;
        }
    }
}