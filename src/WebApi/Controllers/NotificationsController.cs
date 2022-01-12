using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using UpWorkTask.Data;
using UpWorkTask.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using UpWorkTask.Observers;

namespace UpWorkTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public NotificationsController(MyDbContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: api/Notifications/notificationcount
        [Route("notificationcount")]
        [HttpGet]
        public async Task<ActionResult<NotificationCountResult>> GetNotificationCount()
        {
            return await Task.FromResult(new NotificationCountResult()
            {
                Count= CountTest.Count
            });
        }

    }
}
