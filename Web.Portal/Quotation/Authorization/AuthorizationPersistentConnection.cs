using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Web.Portal.Models;
using Newtonsoft.Json;

namespace Web.Portal.Quotation.Authorization
{
    public class AuthorizationPersistentConnection: PersistentConnection
    {
        protected override bool AuthorizeRequest(IRequest request)
        {
            return request.User != null && request.User.Identity != null && request.User.Identity.IsAuthenticated;
        }
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Connection.Broadcast("欢迎" + request.User.Identity.Name);
        }
        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            return Connection.Broadcast(request.User.Identity.Name + "已离线");
        }
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var message = JsonConvert.DeserializeObject<Message>(data);
            return base.OnReceived(request, connectionId, data);
        }
    }
}