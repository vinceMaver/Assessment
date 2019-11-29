using Assesment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Core.Interfaces.DataAccess
{
    public interface IUserDataSource
    {

        Task AddUserSignUp(User user);

        Task<IList<User>> GetUserSignUps();

    }
}
