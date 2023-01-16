using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OzkaInsaat.Common.APIConnection
{
    public class APIConnectionFunctions
    {
        public static string Connection(string URL, string Request, ConnectionType ConnectionType)
        {
            WebRequest request = WebRequest.Create(URL);
            request.Method = ConnectionType.ToString();
            request.ContentType = "application/json";
            Stream dataStream;
            if (ConnectionType.ToString() != "GET")
            {
                dataStream = request.GetRequestStream();
                byte[] byteArray = Encoding.UTF8.GetBytes(Request);
                request.ContentLength = byteArray.Length;
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseString;
        }
    }
}
