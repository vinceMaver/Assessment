using Assesment.Core.Entities;
using Assesment.Core.Interfaces.DataAccess;
using Assessment.Core.Common.Extensions;
using Assessment.Core.Interfaces.DataAccess;
using Experimental.System.Messaging;
using MessageQueuing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Core.DataAccessLayer
{
    public class UserDataSource : IUserDataSource
    {
        private IQueueConfiguration queueConfiguration;

        public UserDataSource(IQueueConfiguration queueConfiguration)
        {
            this.queueConfiguration = queueConfiguration;
        }
        
        public async Task AddUserSignUp(User user)
        {
            string path = queueConfiguration.QueuePath();
            MessageQueue messageQueue = null;

            if (MessageQueue.Exists(path))
            {
                messageQueue = new MessageQueue(path);
            }
            else
            {
                // Create the Queue if it doesn't exist
                MessageQueue.Create(path);
                messageQueue = new MessageQueue(path);
            }

            try
            {
               using (messageQueue = new MessageQueue(path))
                {
                    //Send is always called async
                    //messageQueue.Formatter = new JsonMessageFormatter<User>();
                    await Task.Yield();
                    messageQueue.Send(user);
                }
            }
            catch (Exception ex)
            {
                //Log error first and throw error
                throw;
            }
        }

        public async Task<IList<User>> GetUserSignUps()
        {
            string path = queueConfiguration.QueuePath();

            if (!MessageQueue.Exists(path))
                return null;

            return await ReadQueue(path);
        }

        private async Task<IList<User>> ReadQueue(string path)
        {
            //Enable this to get messages async
            //MessageQueue messageQueue = new MessageQueue(path);
            //messageQueue.ReceiveCompleted += QueueMessageReceived;
            //messageQueue.BeginReceive();

            List<User> lstMessages = new List<User>();
            using (MessageQueue messageQueue = new MessageQueue(path))
            {
                Experimental.System.Messaging.Message[] messages = messageQueue.GetAllMessages();

                foreach (Experimental.System.Messaging.Message message in messages)
                {
                    message.Formatter = new XmlMessageFormatter(new Type[] { typeof(User) });
                    lstMessages.Add((User)message.Body);
                }
            }
            return lstMessages;
        }

        private void QueueMessageReceived(object source, ReceiveCompletedEventArgs args)
        {
            MessageQueue msQueue = (MessageQueue)source;

            //once a message is received, stop receiving
            Message msMessage = null;
            msMessage = msQueue.EndReceive(args.AsyncResult);

            // Add to read list
            //(User)msMessage.Body;
            
            //begin receiving again
            msQueue.BeginReceive();
        }

    }
}
