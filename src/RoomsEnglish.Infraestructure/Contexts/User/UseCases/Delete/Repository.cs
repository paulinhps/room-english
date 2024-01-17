
using RoomsEnglish.User.UseCases.Delete.Contracts;

namespace RoomsEnglish.Infraestructure.Contexts.User.UseCases.Delete
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context) =>
            _context = context;

    }
}