namespace Analogy
{
    /// <summary>
    /// This example shows that a library that needs access to target .NET Standard 1.3
    /// can only access APIs available in that .NET Standard. Even though similar the APIs exist on .NET 
    /// Framework 4.5, it implements a version of .NET Standard that isn't compatible with the library.
    /// </summary>INetCoreApp10
    class Example1
    {
        public void Net45Application(INetFramework45 platform)
        {
            // .NET Framework 4.5 has access to all .NET Framework APIs
            platform.FileSystem();

            platform.Console();


            // This fails because .NET Framework 4.5 does not implement .NET Standard 1.3
            // Argument 1: cannot convert from 'Analogy.INetFramework45' to 'Analogy.INetStandard13'
            NetStandardLibrary13(project);
        }

        public void NetStandardLibrary13(INetStandard13 platform)
        {
            platform.FileSystem();

            platform.Console();
        }
    }


    /// <summary>
    /// This example shows a library targeting multiple frameworks and 2 different applications
    /// using that library. MultipleTargetsLibrary needs access to the FileSystem, that API was only available
    /// in .NET Standard 1.3. .NET Standard 1.3 only works with .NET Framework 4.6. Because of this
    /// MultipleTargetsLibrary needs to add support for .NET Framework 4.5 explicitly.
    /// </summary>
    class Example2
    {
        public void Net45Application(INetFramework451 platform)
        {
            // On the .NET 4.5.1 application, the INetFramework45 implementation is choson
            MultipleTargetsLibrary(platform);
        }

        public void NetCoreApplication(INetCoreApp10 platform)
        {
            // On the .NET Core 1.0 application, the INetStandard13 implementation is choson
            MultipleTargetsLibrary(platform);
        }

        public void MultipleTargetsLibrary(INetFramework45 platform)
        {
            platform.FileSystem();
        }

        public void MultipleTargetsLibrary(INetStandard13 platform)
        {
            platform.FileSystem();
        }
    }

    /// <summary>
    /// This example shows how future platforms can be added without the need to change libraries that
    /// target the .NET Standard. JSN.NET targets .NET Standard 1.0 and can run on *ANY* platform that implements
    /// the standard.
    /// </summary>
    class Example3
    {
        /// <summary>
        /// This future platform implements .NET Standard 1.3
        /// </summary>
        public void FuturePlatformApplication(ISomeFuturePlatform platform)
        {
            // You are able to use JSON.NET with the future platform without recompiling JSON.NET
            JsonNet(platform);
        }

        /// <summary>
        /// This method represents the implementation of JSON.NET. JSON.NET supports .NET Standard 1.0.
        /// </summary>
        public void JsonNet(INetStandard10 platform)
        {
            platform.Linq();

            platform.Reflection();

            platform.Collections();
        }
    }
}
