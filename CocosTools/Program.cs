﻿using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Linq;

namespace CocosTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CocosToolsForm());
        }

        static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            //We dont' care about System Assembies and so on...
            //if (!args.Name.ToLower().StartsWith("Test")) return null;

            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            //Get the Name of the AssemblyFile
            var name = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";

            //Load form Embedded Resources - This Function is not called if the Assembly is in the Application Folder
            var resources = thisAssembly.GetManifestResourceNames().Where(s => s.EndsWith(name));
            if (resources.Count() > 0)
            {
                var resourceName = resources.First();
                using (Stream stream = thisAssembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null) return null;
                    var block = new byte[stream.Length];
                    stream.Read(block, 0, block.Length);
                    return Assembly.Load(block);
                }
            }
            return null;
        }
    }
}
