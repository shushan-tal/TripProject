﻿using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1.Interfaces
{
    public interface Ilogin
    {
        Custumer getUserByPassAndUser(string pass,string user);
    }
}
