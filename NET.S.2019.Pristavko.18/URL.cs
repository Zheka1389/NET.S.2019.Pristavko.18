namespace NET.S._2019.Pristavko._18
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents URL address.
    /// </summary>
    public class URL
    {
        public string Host { get; set; }

        public List<string> Paths { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}
