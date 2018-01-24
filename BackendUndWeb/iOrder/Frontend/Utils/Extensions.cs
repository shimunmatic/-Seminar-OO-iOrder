using Backend.Models.ModelView;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

//This ISession methods are not generic extensions because we only save UserCredentials class.

namespace Frontend.Models
{
    public static class SessionExtensions
    {
        public static void Set<UserCredentials>(this ISession session, UserCredentials value)
        {
            session.SetString(Default.KEY, JsonConvert.SerializeObject(value));
        }

        public static UserCredentials Get(this ISession session)
        {
            var value = session.GetString(Default.KEY);
            return value == null ? default(UserCredentials) : JsonConvert.DeserializeObject<UserCredentials>(value);
        }
    }
}
