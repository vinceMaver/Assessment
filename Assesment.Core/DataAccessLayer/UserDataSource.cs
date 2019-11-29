using Assesment.Core.Entities;
using Assesment.Core.Interfaces.DataAccess;
using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Core.DataAccessLayer
{
    public class UserDataSource : IUserDataSource
    {
        public async Task AddUserSignUp(User user)
        {

            MessageQueue messageQueue = null;
            string path = @".\Private$\Assessment"; //this should be parameterised

            try{

                if (MessageQueue.Exists(path))

                {
                    messageQueue = new MessageQueue(path);
                }
                else
                {
                    MessageQueue.Create(path);
                    messageQueue = new MessageQueue(path);
                }
                messageQueue.Send(user);
            }
            catch
            {
                throw;
            }
            finally
            {
                messageQueue.Dispose();
            }
        }

        public Task<IList<User>> GetUserSignUps()
        {
            throw new NotImplementedException();
        }


        public void sendMessage()
        {
            MessageQueue queue = null;
            if (MessageQueue.Exists(@".\Private$\Assessment"))
            {
                queue = new MessageQueue(@".\Private$\Assessment");
                queue.Label = "Assessment Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\Assessment");
                queue = new MessageQueue(@".\Private$\Assessment");
                queue.Label = "Newly Created Queue";
            }

            // Open the queue.
            using (queue = new MessageQueue(@".\Private$\Assessment"))
            {
                // Enable the AppSpecific field in the messages.
                //queue.MessageReadPropertyFilter.AppSpecific = true;

                // Set the formatter to binary.
                //queue.Formatter = new BinaryMessageFormatter();

                // Since we're using a transactional queue, make a transaction.
                using (MessageQueueTransaction mqt = new MessageQueueTransaction())
                {
                    mqt.Begin();
                    // Create a simple text message.
                    Message myMessage = new Message(user, new BinaryMessageFormatter());
                    //myMessage.Label = "First Message";
                    //myMessage.AppSpecific = (int)MessageType. MESSAGE_TYPE_PLAIN_TEXT;
                    // Send the message.
                    queue.Send("Test", mqt);
                }
            }

        }
    }
}
