## Registry of NuGet.org packages tried with .NET Core 2.0

- [NuGet.Core](https://www.nuget.org/packages/nuget.core/) - Explodes with the following exception

    ```
    Unhandled Exception: System.IO.FileNotFoundException: Could not load file or assembly 'WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'. The system cannot find the file specified.
       at NuGet.PackageBuilder.Save(Stream stream)
    ```

- [HtmlAgilityPack](https://www.nuget.org/packages/HtmlAgilityPack/) - Seems to work
