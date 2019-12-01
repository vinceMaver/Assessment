using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Common.Extensions
{
    public class MessageReceivedEventArgs<T> : EventArgs
    {
        #region Fields
        private T message;
        #endregion

        #region Properies
        /// <summary>
        /// Message of type T read from the message queue
        /// </summary>
        public T Message
        {
            get
            {
                return this.message;
            }
        }
        #endregion

        #region Constructors
        public MessageReceivedEventArgs(T message)
        {
            this.message = message;
        }
        #endregion
    }
}
