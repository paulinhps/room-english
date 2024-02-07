namespace RoomsEnglish.Api.Constants
{
    public static class EndpointPathMapping
    {
        private static string PathBase => "/api/v1";
        public static string Auth => $"{PathBase}/auth";
        public static string Players => $"{PathBase}/players";
    }
}
