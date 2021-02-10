using System;
using System.Linq;
using System.Reflection;

namespace TheCore
{
    public class AddonLoader
    {
        public static void LoadTheAddon()
        {
            var assembly = Assembly.LoadFrom("TheAddon.dll");
            var type = assembly.GetExportedTypes().Where(t => t.Name == "AddonMain").FirstOrDefault();
            object obj = Activator.CreateInstance(type);
            var addon = obj as IAddon;

            addon.Action();     // This is where the error shows !
        }
    }
}
