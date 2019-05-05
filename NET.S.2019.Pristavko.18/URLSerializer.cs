namespace NET.S._2019.Pristavko._18
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Provides a method that converts a list of URLs into an XML document and saves it.
    /// </summary>
    public static class URLSerializer
    {
        /// <summary>
        /// Converts a list of URLs into an XML document and saves it.
        /// </summary>
        public static void SaveXml(List<URL> urls, string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentException("Invalid path");
            }

            if (urls != null)
            {
                var root = new XElement("urlAddresses");
                XElement node;

                foreach (URL url in urls)
                {
                    node = new XElement("urlAddress");
                    node.Add(new XElement("host", new XAttribute("name", url.Host)));

                    if (url.Paths != null)
                    {
                        node.Add(new XElement("uri", url.Paths.Where(path => path.Length > 0).Select(path => new XElement("segment", path))));
                    }

                    if (url.Parameters != null)
                    {
                        node.Add(new XElement("parameters", url.Parameters.Select(y => new XElement("parametr",
                                                                                                    new XAttribute("value", y.Value),
                                                                                                    new XAttribute("key", y.Key)))));
                    }

                    root.Add(node);
                }

                var document = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), root);
                document.Save(filePath);
            }
        }
    }
}
