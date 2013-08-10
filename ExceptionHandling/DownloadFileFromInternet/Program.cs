using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;

namespace DownloadFileFromInternet
{
    class Program
    {
        static ManualResetEvent ma = new ManualResetEvent(false);
        
        /// <summary>
        /// Download file by given url.
        /// </summary>
        /// <param name="url"></param>
        static void DownloadFile(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
                webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;
                Uri urlAddress = new Uri(url);
                webClient.DownloadFileAsync(urlAddress, Path.GetFileName(url));
                Console.WriteLine("Download starting...");
                ma.WaitOne();
                Console.WriteLine("\nDownload is complete.");
            }
        }

        /// <summary>
        /// Invoke when download is complete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ma.Set();
        }

        /// <summary>
        /// Invoke when download progress is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.Write("\r{0}%", e.ProgressPercentage);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter path to file for download : ");
            string fileAddress = Console.ReadLine();
            try
            {
                DownloadFile(fileAddress);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Address or filename are emptys.");
            }
            catch (WebException)
            {
                Console.WriteLine("Address is invalid, file not exist or network problem.");
            }
            catch (UriFormatException)
            {
                Console.WriteLine("Url address is empty.");
            }
        }
    }
}
