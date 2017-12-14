using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProftaakASP.App_DAL
{
    public interface IMessageContext
    {
        List<Message> GetAllMessages();
        Message InsertMessage(Message message);
        bool UpdateMessage(Message message);
        bool DeleteMessage(int id);
        Message GetMessageById(int id);
        List<Message> GetAllMessagesByReceiver(int receiver);
        bool UpdateIsReadStatus(Message message);
    }
}
