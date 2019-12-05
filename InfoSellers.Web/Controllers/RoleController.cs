using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoSellers.Model.Entities;
using InfoSellers.Model.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoSellers.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IBusinessService<Role, int> _roleBusinessService;

        public RoleController(IBusinessService<Role, int> _businessService)
        {
            _roleBusinessService = _businessService;
        }

        // GET: api/Role
        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetRoles()
        {
            return _roleBusinessService.GetAll().ToList();
        }

    }
}
