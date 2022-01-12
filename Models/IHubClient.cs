using System.Threading.Tasks;

namespace UpWorkTask.Models
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}
