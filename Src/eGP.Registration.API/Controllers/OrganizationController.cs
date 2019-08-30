using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eGP.Registration.Application.Organization;
using eGP.Registration.Application.Organization.Commands;
using eGP.Registration.Application.Organization.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eGP.Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private IMediator Mediator { get; }
        public OrganizationController(IMediator mediator)
        {
            Mediator = mediator;
        }
        // GET: api/Organization
        [HttpGet]
        public  IEnumerable<OrganizationDTO> Get()
        {
            var query = new OrganizationGetAllQuery();
           var lst =  Mediator.Send(query).Result;
           

            return lst.Organizations;
        }

        // GET: api/Organization/5
        [HttpGet("{id}", Name = "Get")]
        public OrganizationDTO Get(Guid id)
        {
            var qry = new OrganizationGetByIdQuery {Id = id};
            var org = Mediator.Send(qry);
            return org.Result;
        }

        // POST: api/Organization
        [HttpGet("{name}", Name = "getByName")]
        public void GetByName(string name)
        {
        }

        [HttpPost, Route("register")]
        public void Register([FromBody] RegisterOrganizationCommand command)
        {
            command.RegisteredBy = Guid.NewGuid().ToString();
            Mediator.Send(command);
        }
       
        // PUT: api/Organization/5
        [HttpPut("changeName/{id}")]
        public async Task ChangeName(Guid id, [FromBody] ChangeOrganizationNameCommand command)
        {
            command.ChangedBy = Guid.NewGuid().ToString();
            var resutl = await Mediator.Send(command);
        }

        [HttpPut("changeVersion/{id}")]
        public void ChangeVersion(Guid id, [FromBody] ChangeOrganizationVersionCommand command)
        {
            command.ChangedBy = Guid.NewGuid().ToString();
            Mediator.Send(command);
        }

        [HttpPut("setProfile/{id}")]
        public void SetProfile(Guid id, [FromBody] SetOrganizationProfileCommand command)
        {
            command.ChangedBy = Guid.NewGuid().ToString();
            Mediator.Send(command);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
