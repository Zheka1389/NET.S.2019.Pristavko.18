namespace NET.S._2019.Pristavko._18
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string file = "test.txt";
            URLsContainer container = new URLsContainer(file);
            URLSerializer.SaveXml(URLParser.Parse(container.URLs), "result.txt");
        }
    }
}
