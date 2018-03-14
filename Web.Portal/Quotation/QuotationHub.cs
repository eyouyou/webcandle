using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;

namespace Web.Portal.Quotation
{
    [HubName("quotationhub")]
    public class QuotationHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public override Task OnConnected()
        {
            return Clients.All.hubMessage(Context.ConnectionId + "已连接");
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            return Clients.All.hubMessage(Context.ConnectionId + "断开" + (stopCalled ? "用户主动断开" : "非正常断开"));
        }
        public override Task OnReconnected()
        {
            return Clients.Caller.hubMessage("已重连");
        }
        public async Task StartBackgroundThread()
        {
            BackgroundThread.Enable = true;
            await BackgroundThread.SendOnHub();
        }
    }
    public class BackgroundThread
    {
        public static bool Enable { set; get; }
        public static async Task SendOnHub()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<QuotationHub>();
            var now = DateTime.Now;

            while (Enable)
            {
                var simulation= now.ToString("yyyy-MM-dd-fffff");
                var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
                var temp = (DateTime.Now-startTime).TotalMilliseconds;
                var temp2 = DateTime.Now;
                await context.Clients.All.hubMessage("后台进程hub发送 时间：" + temp);
                //await context.Clients.All.hubMessage("后台进程hub发送 时间2：" + temp2);

                //await context.Clients.All.getData(simulation + ",10452.74,10409.85,10367.41,10554.96,168890000");
                await Task.Delay(TimeSpan.FromSeconds(10));
                now = now.AddDays(1);
            }
        }
    }
}