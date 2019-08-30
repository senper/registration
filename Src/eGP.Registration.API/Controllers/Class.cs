//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//namespace eGP.Registration
//{
    

//    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.0.4.0 (NJsonSchema v10.0.21.0 (Newtonsoft.Json v11.0.0.0))")]
//    [Microsoft.AspNetCore.Mvc.Route("v2")]
//    [ApiController]
//    public partial class Controller : ControllerBase
//    {
//        private IController _implementation;

//        public Controller(IController implementation)
//        {
//            _implementation = implementation;
//        }

//        /// <summary>Finds all Organizations</summary>
//        /// <returns>successful operation</returns>
//        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("GetAll")]
//        public async System.Threading.Tasks.Task<HttpResponseMessage> GetAllOrganizations(System.Threading.CancellationToken cancellationToken)
//        {
//            var result = await _implementation.GetAllOrganizationsAsync(cancellationToken).ConfigureAwait(false);

//            var status = (System.Net.HttpStatusCode)result.Value;
//            HttpResponseMessage response = Request.CreateResponse(status, result.Result);

//            foreach (var header in result.Headers)
//                response.Headers.Add(header.Key, header.Value);

//            return response;
//        }

//        /// <summary>Finds Organization by Id</summary>
//        /// <param name="id">Id of the organization</param>
//        /// <returns>successful operation</returns>
//        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("GetById")]
//        public async System.Threading.Tasks.Task<HttpResponseMessage> GetOrganizationById([Microsoft.AspNetCore.Mvc.FromQuery] [Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] string id, System.Threading.CancellationToken cancellationToken)
//        {
//            var result = await _implementation.GetOrganizationByIdAsync(id, cancellationToken).ConfigureAwait(false);

//            var status = (System.Net.HttpStatusCode)result.StatusCode;
//            HttpResponseMessage response = Request.CreateResponse(status, result.Result);

//            foreach (var header in result.Headers)
//                response.Headers.Add(header.Key, header.Value);

//            return response;
//        }

//        /// <summary>Add a new organization</summary>
//        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("Register")]
//        public async System.Threading.Tasks.Task<HttpResponseMessage> RegisterOrganization([Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] Microsoft.AspNetCore.Http.IFormFile body, System.Threading.CancellationToken cancellationToken)
//        {
//            var result = await _implementation.RegisterOrganizationAsync(body, cancellationToken).ConfigureAwait(false);

//            var status = (System.Net.HttpStatusCode)result.StatusCode;
//            HttpResponseMessage response = Request.CreateResponse(status);

//            foreach (var header in result.Headers)
//                response.Headers.Add(header.Key, header.Value);

//            return response;
//        }

//        /// <summary>Finds all PeragoApplications</summary>
//        /// <returns>successful operation</returns>
//        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("PeragoApplication/GetAll")]
//        public async System.Threading.Tasks.Task<HttpResponseMessage> GetAllPeragoApplications(System.Threading.CancellationToken cancellationToken)
//        {
//            var result = await _implementation.GetAllPeragoApplicationsAsync(cancellationToken).ConfigureAwait(false);

//            var status = (System.Net.HttpStatusCode)result.StatusCode;
//            HttpResponseMessage response = Request.CreateResponse(status, result.Result);

//            foreach (var header in result.Headers)
//                response.Headers.Add(header.Key, header.Value);

//            return response;
//        }

//        /// <summary>Finds PeragoApplication by Id</summary>
//        /// <param name="id">Id of the PeragoApplication</param>
//        /// <returns>successful operation</returns>
//        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("PeragoApplication/GetById")]
//        public async System.Threading.Tasks.Task<HttpResponseMessage> GetById([Microsoft.AspNetCore.Mvc.FromQuery] [Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] string id, System.Threading.CancellationToken cancellationToken)
//        {
//            var result = await _implementation.GetByIdAsync(id, cancellationToken).ConfigureAwait(false);

//            var status = (System.Net.HttpStatusCode)result.StatusCode;
//            HttpResponseMessage response = Request.CreateResponse(status, result.Result);

//            foreach (var header in result.Headers)
//                response.Headers.Add(header.Key, header.Value);

//            return response;
//        }

//        /// <summary>Finds all Mandates</summary>
//        /// <returns>successful operation</returns>
//        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("Mandate/GetAll")]
//        public async System.Threading.Tasks.Task<HttpResponseMessage> GetAllMandates(System.Threading.CancellationToken cancellationToken)
//        {
//            var result = await _implementation.GetAllMandatesAsync(cancellationToken).ConfigureAwait(false);

//            var status = (System.Net.HttpStatusCode)result.StatusCode;
//            HttpResponseMessage response = Request.CreateResponse(status, result.Result);

//            foreach (var header in result.Headers)
//                response.Headers.Add(header.Key, header.Value);

//            return response;
//        }

//        /// <summary>Finds Mandate by id</summary>
//        /// <returns>successful operation</returns>
//        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("Mandate/GetById")]
//        public async System.Threading.Tasks.Task<HttpResponseMessage> GetMandateById([Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] string id, System.Threading.CancellationToken cancellationToken)
//        {
//            var result = await _implementation.GetMandateByIdAsync(id, cancellationToken).ConfigureAwait(false);

//            var status = (System.Net.HttpStatusCode)result.StatusCode;
//            HttpResponseMessage response = Request.CreateResponse(status, result.Result);

//            foreach (var header in result.Headers)
//                response.Headers.Add(header.Key, header.Value);

//            return response;
//        }

//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public partial class Organization
//    {
//        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Id { get; set; }

//        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Name { get; set; }

//        /// <summary>Abbreviated name of the organization e.g. MoWIE, MoH</summary>
//        [Newtonsoft.Json.JsonProperty("shortName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string ShortName { get; set; }

//        /// <summary>code assigned by the PeragoSystem. To be used in procurement code</summary>
//        [Newtonsoft.Json.JsonProperty("code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Code { get; set; }

//        /// <summary>Organization Status</summary>
//        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
//        public OrganizationStatus? Status { get; set; }

//        [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Version { get; set; }

//        [Newtonsoft.Json.JsonProperty("rootStructureId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string RootStructureId { get; set; }

//        [Newtonsoft.Json.JsonProperty("profile", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public System.Collections.Generic.List<Profile> Profile { get; set; }


//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public partial class OrganizationStructure
//    {
//        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Id { get; set; }

//        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Name { get; set; }

//        [Newtonsoft.Json.JsonProperty("code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Code { get; set; }

//        [Newtonsoft.Json.JsonProperty("organizationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string OrganizationId { get; set; }

//        [Newtonsoft.Json.JsonProperty("parentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string ParentId { get; set; }

//        [Newtonsoft.Json.JsonProperty("canAddSubUnit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public bool? CanAddSubUnit { get; set; }

//        [Newtonsoft.Json.JsonProperty("profile", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public System.Collections.Generic.List<Profile> Profile { get; set; }

//        [Newtonsoft.Json.JsonProperty("structureType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public StructureType StructureType { get; set; }


//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public partial class StructureType
//    {
//        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public long? Id { get; set; }

//        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Description { get; set; }


//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public partial class Placement
//    {
//        [Newtonsoft.Json.JsonProperty("organizationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public System.Guid? OrganizationId { get; set; }

//        [Newtonsoft.Json.JsonProperty("personnelId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string PersonnelId { get; set; }


//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public partial class Subscription
//    {
//        [Newtonsoft.Json.JsonProperty("parentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string ParentId { get; set; }

//        [Newtonsoft.Json.JsonProperty("subscriptionType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public SubscriptionType SubscriptionType { get; set; }

//        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
//        public SubscriptionStatus? Status { get; set; }


//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public partial class SubscriptionType
//    {
//        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public int? Id { get; set; }

//        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Description { get; set; }


//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public partial class PeragoSystem
//    {
//        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Id { get; set; }

//        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Name { get; set; }

//        [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Version { get; set; }

//        [Newtonsoft.Json.JsonProperty("setting", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public System.Collections.Generic.List<Profile> Setting { get; set; }

//        [Newtonsoft.Json.JsonProperty("profile", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public System.Collections.Generic.List<Profile> Profile { get; set; }


//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public partial class PeragoApplication
//    {
//        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Id { get; set; }

//        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Name { get; set; }

//        [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Version { get; set; }

//        [Newtonsoft.Json.JsonProperty("PeragoSystem", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public PeragoSystem PeragoSystem { get; set; }

//        [Newtonsoft.Json.JsonProperty("profile", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public System.Collections.Generic.List<Profile> Profile { get; set; }

//        [Newtonsoft.Json.JsonProperty("setting", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public System.Collections.Generic.List<Profile> Setting { get; set; }


//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public partial class Mandate
//    {
//        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Id { get; set; }

//        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Name { get; set; }

//        [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Version { get; set; }

//        [Newtonsoft.Json.JsonProperty("PeragoSystem", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public PeragoSystem PeragoSystem { get; set; }

//        [Newtonsoft.Json.JsonProperty("template", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public System.Collections.Generic.List<Profile> Template { get; set; }


//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public partial class Role
//    {
//        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Id { get; set; }

//        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Name { get; set; }

//        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Status { get; set; }

//        [Newtonsoft.Json.JsonProperty("mandate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public Mandate Mandate { get; set; }

//        [Newtonsoft.Json.JsonProperty("template", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public System.Collections.Generic.List<Profile> Template { get; set; }


//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public partial class Profile
//    {
//        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Name { get; set; }

//        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
//        public string Value { get; set; }


//    }


//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public enum OrganizationStatus
//    {
//        [System.Runtime.Serialization.EnumMember(Value = @"new")]
//        New = 0,

//        [System.Runtime.Serialization.EnumMember(Value = @"activated")]
//        Activated = 1,

//        [System.Runtime.Serialization.EnumMember(Value = @"disabled")]
//        Disabled = 2,

//    }

//    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.21.0 (Newtonsoft.Json v11.0.0.0)")]
//    public enum SubscriptionStatus
//    {
//        [System.Runtime.Serialization.EnumMember(Value = @"new")]
//        New = 0,

//        [System.Runtime.Serialization.EnumMember(Value = @"active")]
//        Active = 1,

//        [System.Runtime.Serialization.EnumMember(Value = @"disabled")]
//        Disabled = 2,

//    }






//}