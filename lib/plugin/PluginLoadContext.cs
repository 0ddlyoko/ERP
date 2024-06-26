﻿using System.Reflection;
using System.Runtime.Loader;

namespace lib.plugin;

public class PluginLoadContext(string pluginPath) : AssemblyLoadContext
{
    
    private readonly AssemblyDependencyResolver _resolver = new(pluginPath);

    protected override Assembly? Load(AssemblyName assemblyName)
    {
        var assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
        if (assemblyPath == null)
            return null;
        return LoadFromAssemblyPath(assemblyPath);
    }
    
    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
    {
        var libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
        if (libraryPath == null)
            return IntPtr.Zero;
        return LoadUnmanagedDllFromPath(libraryPath);
    }
}
