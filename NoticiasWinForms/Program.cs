using Docker.DotNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoticiasWinForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InicioSesion());

            //NoticiasClient client = new NoticiasClient();

            //var auth = client.Authenticate("admin", "admin1");         
        }
    }

    //public class NoticiasClient
    //{
    //    static HttpClient httpClient = new HttpClient();
        
    //    public NoticiasClient()
    //    {
    //        httpClient.BaseAddress = new Uri("https://localhost:44340/");
    //    }
    //    public AuthResponse Authenticate(string username, string password)
    //    {
    //        var formData = new MultipartFormDataContent("Upload..." + DateTime.Now.ToString(CultureInfo.InvariantCulture));
    //        formData.Add(new StringContent(username), "username");
    //        formData.Add(new StringContent(password), "password");

    //        var response = httpClient.PostAsync("/api/InicioSesion/authenticate", formData).Result;
    //        var responseTest = response.Content.ReadAsStringAsync().Result;
            

    //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
    //        {
    //            var responseObject = JsonConvert.DeserializeObject<AuthResponse>(responseTest);
    //            return responseObject;
    //        }
    //        else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
    //        {
    //            throw new UnauthorizedAccessException("Login Invalid");
    //        }
    //        else
    //        {
    //            throw new ApplicationException("Internal Server Error");
    //        }
    //    }
    //}

    //public class Rootobject
    //{
    //    public string token { get; set; }
    //    public int expires_in { get; set; }
    //}
}
    

