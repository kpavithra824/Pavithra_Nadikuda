﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AdminMicroServices.Models
{
    public partial class TblAdminLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
