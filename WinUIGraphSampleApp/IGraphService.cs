using Microsoft.Graph;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinUIGraphSampleApp
{
    public interface IGraphService
    {
        Task<User> GetMyDetailsAsync();
    }
}
