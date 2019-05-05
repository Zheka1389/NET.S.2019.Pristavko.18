namespace NET.S._2019.Pristavko._18
{
    using System;
    using NLog;

    /// <summary>
    /// Provides method that validates string if it's an url 
    /// </summary>
    internal static class URLValidator
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Validates string if it's an url 
        /// </summary>
        internal static bool ValidateURL(string url)
        {
            var result = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result)
            {
                logger.Info(string.Format("{0} is not URL", url));
            }

            return result;
        }
    }
}
