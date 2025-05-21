
using Dto.dtos;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserLogin
    {
        CustumerDto getUserBy(string username, string pass);
    }
}
