namespace NET.S._2019.Pristavko._18
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents an abstraction of a URL container and provides its methods.
    /// </summary>
    public class URLsContainer
    {        
        /// <summary>
        /// Initializes a new instance of the URLsContainer class.
        /// </summary>
        public URLsContainer(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentException("Invalid path");
            }

            this.SetUrls(filePath);
        }

        public string[] URLs { get; private set; }

        /// <summary>
        /// Reads all lines from a file into an array of strings.
        /// </summary>
        private void SetUrls(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException("Incorrect file path");
            }

            this.URLs = File.ReadAllLines(filePath);
        }
    }
}
