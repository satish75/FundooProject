// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MsmqTokenSender.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// ----------------------------------------------------------------------------------------------------
namespace Common.MSMQ
{
    using System;
    using System.Messaging;
    /// <summary>
    /// this is class which is used to send the token to our 
    /// </summary>
    public class MsmqTokenSender
    {

        /// <summary>
        /// Sends the token queue.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="token">The token.</param>
        public void SendTokenQueue(string email, string token)
        {
          
            MessageQueue msmqObject = null;
            const string QueueName = @".\private$\EmailQueue";
            if (!MessageQueue.Exists(QueueName))
            {
                msmqObject =  MessageQueue.Create(QueueName);
            }
            else
            {
                msmqObject = new MessageQueue(QueueName);
            }
            try
            {
                msmqObject.Send(email, token);
            }
            catch (MessageQueueException mqe)
            {
                Console.Write(mqe.Message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                msmqObject.Close();
            }

            Console.WriteLine("message Sent");
        }
    }
}
