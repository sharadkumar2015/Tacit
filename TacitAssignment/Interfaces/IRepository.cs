using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TacitAssignment.Interfaces
{
    public interface IRepository
    {
        Task<string> GetDataAsync(string url);
    }
}