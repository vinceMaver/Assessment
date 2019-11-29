using Assesment.Core.Entities;
using Assesment.Core.Interfaces;
using Assesment.Core.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataSource userDataSource;

        public UserService(IUserDataSource userDataSource)
        {
            this.userDataSource = userDataSource;
        }

        public async Task AddUserSignUp(User user)
        {
            if (user.Id == Guid.Empty)
                user.Id = Guid.NewGuid();

            await userDataSource.AddUserSignUp(user);
        }

        public async Task<IList<User>> GetUserSignUps()
        {
            throw new NotImplementedException();
        }
    }
}
