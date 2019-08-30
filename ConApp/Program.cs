using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using eGP.Registration.Domain.Organization;

namespace ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var executionFolder = Path.GetDirectoryName(typeof(Program).Assembly.Location);

            //AssemblyLoadContext.Default.Resolving += (AssemblyLoadContext context, AssemblyName assembly) =>
            //{
            //    return context.LoadFromAssemblyPath(Path.Combine(executionFolder, $"{assembly.Name}.dll"));
            //};
            //var domainAssembly = typeof(IOrganizationRepository).Assembly;
            //var types = domainAssembly.GetTypes().Where(t => t.IsInterface && t.Name.EndsWith("Repository"));
            //var persistanceAssembly = typeof(OrganizationRepository).Assembly;
            Console.WriteLine("Enter");
            Console.ReadLine();
        }
    }
}
