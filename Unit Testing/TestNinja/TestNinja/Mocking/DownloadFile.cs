using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IDownloadFile
    {
        void Download(string url , string destination);
    }

    public class DownloadFile : IDownloadFile
    {
        public void Download(string url, string destination)
        {   try
            {
                var client = new WebClient();
                client.DownloadFile(
                    url,
                    destination);
            }
            catch(WebException)
            {
                throw (new WebException());
            }
        }
    }
}
