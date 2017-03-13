using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using GitVersion;
using GitVersion.Helpers;

namespace DotNetGitversionMSBuild
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger.SetLoggers(Console.WriteLine, Console.WriteLine, Console.WriteLine);

            var fs = new FileSystem();
            var gv = new GitVersion.ExecuteCore(fs);
            var auth = new GitVersion.Authentication();
            var version = gv.ExecuteGitVersion(null, null, auth, null, false, ".", null);

            var file = GetFile();
            if (file == null)
            {
                Console.WriteLine("Found no file");
                return;
            }
            Console.WriteLine($"Setting version: {version.NuGetVersion}");
            XDocument doc = XDocument.Load(file);
            var propertyGroup = doc.Descendants("PropertyGroup").FirstOrDefault();
            if(propertyGroup == null)
                Console.WriteLine("No propertygroup found");
            var versionAttribute = propertyGroup.Descendants("VersionPrefix").SingleOrDefault() as XElement;
            if (versionAttribute != null)
                versionAttribute.SetValue(version.NuGetVersion);
            else propertyGroup.Add(new XElement("VersionPrefix", version.NuGetVersion));

            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Write))
            {
                doc.Save(stream);
            }
        }

        private static string GetFile()
        {
            return Directory.EnumerateFiles(".").FirstOrDefault(f => f.EndsWith(".csproj"));
        }
    }
}
