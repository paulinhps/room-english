
using RoomsEnglish.User.UseCases.Update.Contracts;

namespace RoomsEnglish.Infraestructure.Contexts.User.UseCases.Update
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context) =>
            _context = context;

    }
}