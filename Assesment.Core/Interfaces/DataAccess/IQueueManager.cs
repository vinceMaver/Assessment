using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimental.System.Messaging;

namespace Assessment.Core.Interfaces.DataAccess
{
    public interface IQueueManager
    {
        bool Exists(string path);
        MessageQueue Create(string path);
    }
}
