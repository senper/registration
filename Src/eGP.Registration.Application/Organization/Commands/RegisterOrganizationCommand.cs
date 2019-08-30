using System;
using System.Threading;
using System.Threading.Tasks;
using eGP.Registration.Application.Organization.Repository;
using MediatR;

namespace eGP.Registration.Application.Organization.Commands
{
    public class RegisterOrganizationCommand : IRequest<int>
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public Guid? Id { get;  set; }

        [Newtonsoft.Json.JsonProperty("name", 
            Required = Newtonsoft.Json.Required.Default, 
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get;  set; }

        [Newtonsoft.Json.JsonProperty("shortName",
            Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ShortName { get;  set; }

        [Newtonsoft.Json.JsonProperty("registerdBy")]
        public string RegisteredBy { get;  set; }

        public RegisterOrganizationCommand()
        {

        }
        public RegisterOrganizationCommand(Guid id, string name, string shortName, string registerdBy)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
            RegisteredBy = registerdBy;
        }
    }

    public class RegisterOrganizationCommandHandler : IRequestHandler<RegisterOrganizationCommand, int>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public RegisterOrganizationCommandHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
            
        }

        /// <summary>
        /// Handler which processes the command when the eGov admin executes
        /// Register Organization command
        /// </summary>
        /// <param name="request"> carries the name of the organization as a parameter</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(RegisterOrganizationCommand request, CancellationToken cancellationToken)
        {

            var code = _organizationRepository.GetNewCode();
            var newOrganization = Domain.Organization.Organization.Register(request.Name, request.ShortName, code);

            _organizationRepository.Add(newOrganization);

            try
            {
                return  _organizationRepository
                    .UnitOfWork
                    .SaveChanges(request.RegisteredBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}