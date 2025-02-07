//using System.Diagnostics;
//using System.Net.Http;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace Async_demo3
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {

//        private readonly HttpClient client = new HttpClient
//        {
//            MaxResponseContentBufferSize = 1_000_000
//        };

//        //---------------------------------------------------
//        private readonly IEnumerable<string> UrlList = new string[]
//        {
//            "http://docs.microsoft.com",
//            "http://docs.microsoft.com/powershell",
//            "http://docs.microsoft.com/dotnet",
//            "http://docs.microsoft.com/aspnet/core",
//            "http://docs.microsoft.com/windows",
//            "http://docs.microsoft.com/azure",
//        };

//        //-------------------------------------------
//        private async void OnStartButtonClick(object sender, RoutedEventArgs e)
//        {
//            btnStartButton.IsEnabled = false;
//            txtResults.Clear();
//            await SumPageSizeAsync();
//            txtResults.Text = $"\n Control returned to {nameof(OnStartButtonClick)}.";
//            btnStartButton.IsEnabled = true;
//        }

//        private async Task SumPageSizeAsync()
//        {
//            var stopwatch = Stopwatch.StartNew();
//            int total = 0;
//            foreach (string url in UrlList)
//            {
//                int contentLength = await ProcessUrlAsync(url, client);
//                total += contentLength;
//            }
//            stopwatch.Stop();
//            txtResults.Text += $"\n total bytes returned: {total:#,#}";
//            txtResults.Text += $"\n elasped time: {stopwatch.Elapsed}\n";
//        }

//        private async Task<int> ProcessUrlAsync(string url, HttpClient client)
//        {
//            byte[] content = await client.GetByteArrayAsync(url);
//            DisplayResult(url, content);
//            return content.Length;
//        }

//        //------------------------------------------
//        private void DisplayResult(string url, byte[] content) => 
//            txtResults.Text += $"{url, -60} {content.Length, 10:#,#}\n";

//        //-------------------------------------------
//        protected override void OnClosed(EventArgs e) => client.Dispose();

//}
//
//    



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Async_demo3
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };

        private readonly IEnumerable<string> UrlList = new string[]
        {
            "http://docs.microsoft.com",
            "http://docs.microsoft.com/powershell",
            "http://docs.microsoft.com/dotnet",
            "http://docs.microsoft.com/aspnet/core",
            "http://docs.microsoft.com/windows",
            "http://docs.microsoft.com/azure",
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        // Event Handler for Button Click
        private async void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            btnStartButton.IsEnabled = false;
            txtResults.Clear();

            try
            {
                await SumPageSizeAsync();
                txtResults.Text += $"\nControl returned to {nameof(OnStartButtonClick)}.";
            }
            catch (Exception ex)
            {
                txtResults.Text += $"\nError: {ex.Message}";
            }

            btnStartButton.IsEnabled = true;
        }

        // Asynchronous method to calculate the total page size
        private async Task SumPageSizeAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            int total = 0;

            foreach (string url in UrlList)
            {
                try
                {
                    int contentLength = await ProcessUrlAsync(url, client);
                    total += contentLength;
                }
                catch (Exception ex)
                {
                    DisplayResult(url, $"Failed: {ex.Message}");
                }
            }

            stopwatch.Stop();
            AppendTextSafe($"\nTotal bytes returned: {total:#,#}");
            AppendTextSafe($"\nElapsed time: {stopwatch.Elapsed}\n");
        }

        // Fetches content from a URL asynchronously
        private async Task<int> ProcessUrlAsync(string url, HttpClient client)
        {
            try
            {
                byte[] content = await client.GetByteArrayAsync(url);
                DisplayResult(url, content.Length.ToString("#,#"));
                return content.Length;
            }
            catch
            {
                throw new Exception("Request failed.");
            }
        }

        // Safely updates the UI from a background thread
        private void DisplayResult(string url, string message)
        {
            AppendTextSafe($"{url,-60} {message}\n");
        }

        private void AppendTextSafe(string text)
        {
            Dispatcher.Invoke(() => txtResults.Text += text);
        }

        // Dispose HttpClient when window closes
        protected override void OnClosed(EventArgs e)
        {
            client.Dispose();
            base.OnClosed(e);
        }
    }
}
