
using RoomsEnglish.User.UseCases.Get.Contracts;

namespace RoomsEnglish.Infraestructure.Contexts.User.UseCases.Get
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context) =>
            _context = context;

    }
}