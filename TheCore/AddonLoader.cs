using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace TheCore
{
    class PluginLoadContext : AssemblyLoadContext
    {
        private AssemblyDependencyResolver _resolver;

        public PluginLoadContext(string pluginPath)
        {
            _resolver = new AssemblyDependencyResolver(pluginPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            string assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }

            return null;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            string libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null)
            {
                return LoadUnmanagedDllFromPath(libraryPath);
            }

            return IntPtr.Zero;
        }
    }
    public class AddonLoader
    {
        public static void LoadAndActivateAllAddons()
        {
            LoadAndActivateAddon("addons\\TheAddon.dll");
            LoadAndActivateAddon("addons\\TheOtherAddon.dll");
        }

        public static void LoadAndActivateAddon(string path)
        {
            var exepath = Path.GetDirectoryName(typeof(AddonLoader).Assembly.Location);

            string pluginLocation = Path.GetFullPath(Path.Combine(exepath, path));
            PluginLoadContext loadContext = new PluginLoadContext(pluginLocation);
            var assembly = loadContext.LoadFromAssemblyName(AssemblyName.GetAssemblyName(pluginLocation));
            var type = assembly.GetExportedTypes().Where(t => t.Name == "AddonMain").FirstOrDefault();
            object obj = Activator.CreateInstance(type);
            var addon = obj as IAddon;

            addon.Action();

            var t = addon.GetSomeType();
            if (t != null)
            {
                var resolver = new DefaultContractResolver();

                // This is where the shit hits the fan!
                // ResolveContract cannot load the TheAddon assembly, where the SomeClass type is defined.
                var contract = resolver.ResolveContract(t) as JsonObjectContract;
            }
        }
    }
}
