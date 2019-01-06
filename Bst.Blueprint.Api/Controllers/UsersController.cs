using System.Collections.Generic;
using System.Linq;
using Bst.Blueprint.Api.Models;
using Bst.Blueprint.Core.Models;
using Bst.Blueprint.Core.Policies.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bst.Blueprint.Api.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        private readonly IRepository<User> _userRepository;

        public UsersController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("all")]
        public IEnumerable<UserModel> GetAll()
        {
            var users = _userRepository.Entities().Include(u => u.Tenants).ThenInclude(t => t.Tenant);
            return users.Select(u => new UserModel(u));
        }
    }
}