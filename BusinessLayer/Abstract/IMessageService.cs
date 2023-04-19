﻿using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        List<Message> TGetReceiverMessageList(string mail);
        List<Message> TGetSenderMessageList(string mail);
    }
}
