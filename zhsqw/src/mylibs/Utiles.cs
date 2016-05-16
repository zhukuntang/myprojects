using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.FileProviders;

public class Utiles
{
    public static IFileProvider WebRootFileProvider;

    public static string GetFilePhysicalPath(string subpath)
    {
        return WebRootFileProvider.GetFileInfo(subpath).PhysicalPath;
    }
}
