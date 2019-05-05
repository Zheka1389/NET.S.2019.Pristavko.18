namespace NET.S._2019.Pristavko._18
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NLog;

    /// <summary>
    /// Provides methods that parse URLS
    /// </summary>
    public static class URLParser
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Converts URLs array from string form to list of url class instances
        /// </summary>
        public static List<URL> Parse(string[] urls)
        {
            if (urls == null)
            {
                throw new ArgumentNullException();
            }

            return urls.Where(url => URLValidator.ValidateURL(url)).Select(url => ParseUrl(url)).ToList();
        }

        /// <summary>
        /// Converts an URL from it's string form to url class instances
        /// </summary>
        private static URL ParseUrl(string stringUrl)
        {
            var uri = new Uri(stringUrl);
            var url = new URL
            {
                Host = uri.Host,
                Paths = GetPaths(uri.Segments),
                Parameters = GetParameters(uri.Query)
            };

            return url;
        }

        /// <summary>
        /// Parser the form of URL segments
        /// </summary>
        private static List<string> GetPaths(string[] segments) => segments.Length > 1
                ? segments
                    .Select(s => s.Trim('/'))
                    .ToList<string>()
                : null;

        /// <summary>
        /// Parser to form URL parameters
        /// </summary>
        private static Dictionary<string, string> GetParameters(string parameters)
        {
            if (parameters != string.Empty)
            {
                try
                {
                    return parameters
                        .Trim('?')
                        .Split('&')
                        .Select(p => p.Split('='))
                        .ToDictionary(pair => pair[0], pair => pair[1]);
                }
                catch
                {
                    logger.Error(string.Format("Invalid parameter format: {0}", parameters));
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
