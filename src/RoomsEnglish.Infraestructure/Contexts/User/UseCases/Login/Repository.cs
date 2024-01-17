
using RoomsEnglish.User.UseCases.Login.Contracts;

namespace RoomsEnglish.Infraestructure.Contexts.User.UseCases.Login
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context) =>
            _context = context;

    }
}