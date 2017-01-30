namespace HttpListenerTest
{
    using System;
    using System.Net;

    public class Program
    {
        public static void Main(string[] args)
        {
            var ws = new WebServer(SendResponse, "http://localhost:8080/test/");
            var ws2 = new WebServer(SendResponse2, "http://localhost:8080/");

            ws.Run();
            ws2.Run();

            Console.WriteLine("A simple webserver. Press a key to quit.");

            Console.ReadKey();

            ws.Stop();
            ws2.Stop();
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
        }

        public static string SendResponse2(HttpListenerRequest request)
        {
            return "{\"value\": 1}";

                //string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
        }
    }
}
