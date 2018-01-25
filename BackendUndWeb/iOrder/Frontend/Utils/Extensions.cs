using Backend.Models.Business;
using Backend.Models.ModelView;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

//This ISession methods are not generic extensions because we only save UserCredentials class.

namespace Frontend.Models
{
    public static class SessionExtensions
    {
        public static void Set<User>(this ISession session, User value)
        {
            session.SetString(Default.KEY, JsonConvert.SerializeObject(value));
        }

        public static User Get(this ISession session)
        {
            var value = session.GetString(Default.KEY);
            return value == null ? default(User) : JsonConvert.DeserializeObject<User>(value);
        }
    }
}
