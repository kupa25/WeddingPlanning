using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json.Linq;

// See documentation at http://go.microsoft.com/fwlink/?LinkId=296704&clcid=0x409

namespace ShaadiTimeMobileService.Controllers
{
    public class NotifyAllUsersController : ApiController
    {
        public ApiServices Services { get; set; }

        // The following call is for illustration purpose only. The function
        // body should be moved to a controller in your app where you want 
        // to send a notification.
        public async Task<bool> Post(JObject data)
        {
            try
            {
                string wnsToast = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?><toast><visual><binding template=\"ToastText01\"><text id=\"1\">{0}</text></binding></visual></toast>", data.GetValue("toast").Value<string>());
                WindowsPushMessage message = new WindowsPushMessage();
                message.XmlPayload = wnsToast;
                await Services.Push.SendAsync(message);
                return true;
            }
            catch (Exception e)
            {
                Services.Log.Error(e.ToString());
            }

            return false;
        }
    }
}