using Assessment.Core.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.DataAccessLayer
{
    public class QueueConfiguration : IQueueConfiguration
    {
        public string QueuePath()
        {
            return @".\Private$\Assessment";
        }
    }
}
