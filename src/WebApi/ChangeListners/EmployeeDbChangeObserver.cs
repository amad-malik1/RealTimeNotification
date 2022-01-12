
using Microsoft.AspNetCore.SignalR;
using UpWorkTask.BL;
using UpWorkTask.Models;

namespace UpWorkTask.Observers
{
    public  class EmployeeDbChangeObserver:IDbChangeObserver
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public EmployeeDbChangeObserver(IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _hubContext = hubContext;
        }
        public void RefreshEmployeeData()
        {
            CountTest.Count++;
             _hubContext.Clients.All.BroadcastMessage();
        }
    }
}
