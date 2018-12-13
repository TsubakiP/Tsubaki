
namespace Tsubaki.Tax
{
    using System.Diagnostics;
    using System.IO;
    using Tsubaki.Core;

    // Tsubaki Api Extensions

    public static class Tax
    {

        /// <summary>
        /// [Debug Only] Creates the new chrome client for debug. 
        /// </summary>
        /// <returns></returns>
#if DEBUG
        public static Process CreateDebugClient(this WsLocalhost wss, string contentPath = "./test.html")
        {
            try
            {
                var fi = new FileInfo(contentPath);

                return Process.Start("chrome.exe", $@"file://{fi.FullName}" + " --incognito");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Debug.WriteLine("Unable to find Google Chrome, chrome.exe not found!");
            }
            return default(Process);
        }
#endif
    }
}
