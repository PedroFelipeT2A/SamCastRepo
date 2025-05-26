using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Painel.Lib
{
    public class EnviarWhatsapp : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public static async Task EnviarWhatsappCliente(string numero,string mensagem)
        {
            try
            {   
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.blueticks.co/messages");
                var content = new StringContent("{\n    \"to\": \"+55" + numero + "\",\n    \"message\": \""+mensagem+ "\",\n    \"apiKey\": \"eYteMgCmjuof3DpZVTVg58H4OOveKj9P\"\n}", null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                //response.EnsureSuccessStatusCode();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        
    }
}