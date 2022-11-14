using Chat.Try.Data;

namespace Chat.Try.Accessors
{
    public interface IUserDbAccessor
    {
        public string GetIdByUser(string user);
    }


    public class UserDbAccessor : IUserDbAccessor
    {

        private readonly ApplicationDbContext _context;

        public UserDbAccessor(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetIdByUser(string user)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == user)?.Id;
        }
    }
}
