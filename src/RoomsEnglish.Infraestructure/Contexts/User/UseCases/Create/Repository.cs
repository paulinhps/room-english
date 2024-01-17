
using RoomsEnglish.User.UseCases.Create.Contracts;

namespace RoomsEnglish.Infraestructure.Contexts.User.UseCases.Create
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context) =>
            _context = context;

    }
}