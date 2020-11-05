using Twitter.Domain.Models;

namespace Twitter.Domain.Communication
{
    public class UserResponse : BaseResponse
    {
        public User User { get; protected set; }

        public UserResponse(User user, string message, bool success) : base (message, success)
        {
            User = user;
        }

        public UserResponse(User user) : this(user, string.Empty, true)
        {}
        public UserResponse(string message) : this(null, message, false)
        {}
    }
}