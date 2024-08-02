using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IDownloadFile _downloadFile;

        public InstallerHelper(IDownloadFile _downloadFile)
        {
            this._downloadFile = _downloadFile;
            
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {

            try
            {
                _downloadFile.Download(string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);
                return true;
            }
            catch (WebException)
            {
                return false;
            }

        }
    }
}