using ProftaakASP.App_DAL;
using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Controllers
{
    public class MessageRepository
    {
        private IMessageContext context;

        public MessageRepository(IMessageContext context)
        {
            this.context = context;
        }

        public List<Message> GetAllMessages()
        {
            return context.GetAllMessages();
        }

        public Message InsertMessage(Message message)
        {
            return context.InsertMessage(message);
        }

        public bool UpdateMessage(Message message)
        {
            return context.UpdateMessage(message);
        }

        public bool DeleteMessage(int id)
        {
            return context.DeleteMessage(id);
        }

        public Message GetMessageById(int id)
        {
            return context.GetMessageById(id);
        }

        public List<Message> GetAllMessagesByReceiver(int receiver)
        {
            return context.GetAllMessagesByReceiver(receiver);
        }

        public bool UpdateIsReadStatus(Message message)
        {
            return context.UpdateIsReadStatus(message);
        }
    }
}