using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the SessionExtensions class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public static class SessionExtensions
    {
        #region Methods

        /// <summary>
        ///     Sets the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        ///     Gets the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }

        #endregion
    }
}