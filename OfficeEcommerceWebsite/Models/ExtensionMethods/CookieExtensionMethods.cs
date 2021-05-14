using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the CookieExtensions class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public static class CookieExtensions
    {
        #region Methods

        /// <summary>
        ///     Gets the string.
        /// </summary>
        /// <param name="cookies">The cookies.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetString(this IRequestCookieCollection cookies, string key)
        {
            return cookies[key];
        }

        /// <summary>
        ///     Gets the int32.
        /// </summary>
        /// <param name="cookies">The cookies.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static int? GetInt32(this IRequestCookieCollection cookies, string key)
        {
            return int.TryParse(cookies[key], out var i) ? i : (int?) null;
        }

        /// <summary>
        ///     Gets the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cookies">The cookies.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static T GetObject<T>(this IRequestCookieCollection cookies, string key)
        {
            var value = cookies[key];
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        ///     Sets the string.
        /// </summary>
        /// <param name="cookies">The cookies.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="days">The days.</param>
        public static void SetString(this IResponseCookies cookies, string key,
            string value, int days = 30)
        {
            cookies.Delete(key);
            if (days == 0)
            {
                cookies.Append(key, value);
            }
            else
            {
                var options = new CookieOptions {Expires = DateTime.Now.AddDays(days)};
                cookies.Append(key, value, options);
            }
        }

        /// <summary>
        ///     Sets the int32.
        /// </summary>
        /// <param name="cookies">The cookies.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="days">The days.</param>
        public static void SetInt32(this IResponseCookies cookies, string key,
            int value, int days = 30)
        {
            cookies.SetString(key, value.ToString(), days);
        }

        /// <summary>
        ///     Sets the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cookies">The cookies.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="days">The days.</param>
        public static void SetObject<T>(this IResponseCookies cookies, string key,
            T value, int days = 30)
        {
            cookies.SetString(key, JsonConvert.SerializeObject(value), days);
        }

        #endregion
    }
}