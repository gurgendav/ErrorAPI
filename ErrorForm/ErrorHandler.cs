using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ErrorAPI.DTO;
using Newtonsoft.Json;

namespace ErrorForm
{
    public class ErrorHandler : IDisposable
    {
        private const int MaxResponseWaitTimeSec = 3;

        private readonly HttpClient _httpClient;

        public ErrorHandler()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["ErrorAPIBaseUri"])
            };

            Application.ThreadException += Application_ThreadException;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        public void Dispose()
        {
            Application.ThreadException -= Application_ThreadException;

            AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var handlingDetails = new ExceptionHandlingDetails(false, false);
            SendErrorDetails("Unhandled exception occured", e.ExceptionObject as Exception, handlingDetails);
        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var result = MessageBox.Show(
                "Oh oh oh. Unhandled exception has occured. Would you like to continue program execution anyway?",
                "Unhandled exception has occured",
                MessageBoxButtons.YesNo);

            var continueExecution = result == DialogResult.Yes;

            var handlingDetails = new ExceptionHandlingDetails(true, continueExecution);
            SendErrorDetails("Exception occured on UI thread", e.Exception, handlingDetails);

            if (!continueExecution)
            {
                Environment.Exit(-1);
            }
        }

        private void SendErrorDetails(string faultingContextDetails, Exception exception, ExceptionHandlingDetails exceptionHandlingDetails)
        {
            var details = CreateErrorDetails(faultingContextDetails, exception, exceptionHandlingDetails);

            var json = JsonConvert.SerializeObject(details, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.PostAsync("api/error-details", content).Wait(TimeSpan.FromSeconds(MaxResponseWaitTimeSec));
        }

        private static ErrorDetails CreateErrorDetails(string faultingContextDetails, Exception exception, ExceptionHandlingDetails exceptionHandlingDetails) =>
            new ErrorDetails(
                GetEnvironmentDetails(),
                exceptionHandlingDetails,
                new ExceptionDetails(exception),
                faultingContextDetails,
                Assembly.GetExecutingAssembly().GetName().Name
            );

        private static EnvironmentDetails GetEnvironmentDetails()
        {
            var usedMemoryByte = Process.GetCurrentProcess().WorkingSet64;
            var usedMemoryMb = usedMemoryByte / 1024d / 1024d;

            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            return new EnvironmentDetails(
                version,
                Environment.MachineName,
                Environment.OSVersion.VersionString,
                usedMemoryMb,
                Environment.UserName,
                DateTime.UtcNow
            );
        }
    }
}