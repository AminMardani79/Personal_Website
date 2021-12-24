﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MessagesCount
    {
        [Key]
        public int Id { get; set; }
        public int NewMessagesNumber { get; set; }
    }
}
