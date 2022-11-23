using Chat.Try.Data;
using Microsoft.EntityFrameworkCore;

namespace Chat.Try.Accessors
{
    public interface IUserDbAccessor
    {
        public string GetIdByUser(string user);
        public List<string> SearchForUsers(string userSearch, List<string> excludedUsers);
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

        public List<string> SearchForUsers(string userSearch, List<string> excludedUsers)
        {
            return _context.Users.AsNoTracking().Where(x => x.UserName.StartsWith(userSearch) && !excludedUsers.Contains(x.UserName)).Select(x => x.UserName).OrderBy(x => x).ToList();
        }
    }
}
