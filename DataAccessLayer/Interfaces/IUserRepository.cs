using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository<T> where T :class
    {
        void Create(DataIdentityUser user);
        void Get(int id);
    }
}
