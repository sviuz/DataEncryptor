using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class IdentityRepository : IUserRepository<DataIdentityUser>
    {
        public IdentityRepository()
        {

        }
        public void Create(DataIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public void Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
