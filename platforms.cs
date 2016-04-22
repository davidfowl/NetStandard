
namespace Analogy
{
    // Each interface represents a target framework and methods represents groups of APIs available on that target framework. 
    // The goal is to show the relationship between .NET Standard API surface and other .NET platforms


    // .NET Standard

    interface INetStandard10
    {
        void Primitives();
        void Reflection();
        void Tasks();
        void Xml();
        void Collections();
        void Linq();
    }

    interface INetStandard11 : INetStandard10
    {
        void ConcurrentCollections();
        void LinqParallel();
        void Compression();
        void HttpClient();
    }

    interface INetStandard12 : INetStandard11
    {
        void ThreadingTimer();
    }

    interface INetStandard13 : INetStandard12
    {
        void FileSystem();
        void Console();
        void ThreadPool();
        void Crypto();
        void WebSockets();
        void Process();
        void Sockets();

        void AsyncLocal();
    }

    interface INetStandard14 : INetStandard13
    {
        void IsolatedStorage();
    }

    interface INetStandard15 : INetStandard14
    {
        void AssemblyLoadContext();
    }

    // .NET Framework 

    interface INetFramework45 : INetStandard11
    {
        void FileSystem();
        void Console();
        void ThreadPool();
        void Crypto();
        void WebSockets();
        void Process();
        void Drawing();
        void SystemWeb();
        void WPF();
        void WindowsForms();
        void WCF();
    }

    interface INetFramework451 : INetFramework45, INetStandard12
    {
        // TODO: .NET Framework 4.5.1 specific APIs
    }

    interface INetFramework452 : INetFramework451, INetStandard12
    {
        // TODO: .NET Framework 4.5.2 specific APIs
    }

    interface INetFramework46 : INetFramework452, INetStandard13
    {
        // TODO: .NET Framework 4.6 specific APIs
    }

    interface INetFramework461 : INetFramework46, INetStandard14
    {
        // TODO: .NET Framework 4.6.1 specific APIs
    }

    interface INetFramework462 : INetFramework461, INetStandard15
    {
        // TODO: .NET Framework 4.6 specific APIs
    }

    // Windows Universal Platform

    interface IWindowsUniversalPlatform : INetStandard13
    {
        void GPS();
        void Xaml();
    }

    // Xamarin 

    interface IXamarinIOS : INetStandard15
    {
        void AppleAPIs();
    }

    interface IXamarinAndroid : INetStandard15
    {
        void GoogleAPIs();
    }

    // .NET Core

    interface INetCore10 : INetStandard15
    {

    }

    // Future platform

    interface ISomeFuturePlatform : INetStandard13
    {
        // A future platform chooses to implement a specific .NET Standard version.
        // All libraries that target that version are instantly compatible with this new
        // platform
    }
}
