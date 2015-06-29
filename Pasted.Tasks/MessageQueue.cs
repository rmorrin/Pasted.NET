using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Pasted.Tasks
{
    public class MessageQueue
    {

        public void Put(string message)
        {


            var factory = new ConnectionFactory()
            {
                HostName = "xxxxxxx.vps.ovh.ca",
                UserName = "elezium",
                Password = "xxxxxx.xxx"
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("Pasted.Net", false, false, false, null);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", "Pasted.Net", null, body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }


        }


        public void Empty()
        {
            throw new NotImplementedException();

        }



    }
}
