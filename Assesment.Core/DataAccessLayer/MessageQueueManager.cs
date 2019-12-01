using Assessment.Core.Interfaces.DataAccess;
using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.DataAccessLayer
{
    public class MessageQueueManager : IQueueManager
    {
        public MessageQueue Create(string path)
        {
            return MessageQueue.Create(path);
        }

        public bool Exists(string path)
        {
            return MessageQueue.Exists(path);
        }
    }
}
