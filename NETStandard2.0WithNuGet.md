## Registry of NuGet.org packages tried with .NET Core 2.0

- [NuGet.Core](https://www.nuget.org/packages/nuget.core/) - Explodes with the following exception

    ```
    Unhandled Exception: System.IO.FileNotFoundException: Could not load file or assembly 'WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'. The system cannot find the file specified.
       at NuGet.PackageBuilder.Save(Stream stream)
    ```

- [HtmlAgilityPack](https://www.nuget.org/packages/HtmlAgilityPack/) - Seems to work
- [ClosedXML](https://www.nuget.org/packages/ClosedXML/) - Explodes with the following exception

   ```
   Unhandled Exception: System.TypeLoadException: Could not load type 'System.Drawing.ColorTranslator' from assembly 'System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'.
   at ClosedXML.Excel.XLColor.FromHtml(String htmlColor)
   at ClosedXML.Excel.XLWorkbook.InitializeTheme() in C:\Projects\ClosedXML\ClosedXML\Excel\XLWorkbook.cs:line 332
   at ClosedXML.Excel.XLWorkbook..ctor(XLEventTracking eventTracking) in C:\Projects\ClosedXML\ClosedXML\Excel\XLWorkbook.cs:line 678
   at ConsoleApp3.Program.Main(String[] args) in c:\users\davifowl\documents\visual studio 2017\Projects\ConsoleApp3\ConsoleApp3\Program.cs:line 13
   ```
- [EPPlus](https://www.nuget.org/packages/EPPlus/) - Explodes with the following exception

    ```
    Unhandled Exception: System.ArgumentException: 'IBM437' is not a supported encoding name. For information on defining a custom encoding, see the documentation for the Encoding.RegisterProvider method.
    Parameter name: name
    at System.Globalization.EncodingTable.internalGetCodePageFromName(String name)
    at System.Globalization.EncodingTable.GetCodePageFromName(String name)
    at System.Text.Encoding.GetEncoding(String name)
    at OfficeOpenXml.Packaging.ZipPackage.Save(Stream stream)
    at OfficeOpenXml.ExcelPackage.Save()
    at OfficeOpenXml.ExcelPackage.SaveAs(Stream OutputStream)
    at ConsoleApp3.Program.Main(String[] args) in c:\users\davifowl\documents\visual studio 2017\Projects\ConsoleApp3\ConsoleApp3\Program.cs:line 34
    ```
- [PayPal .NET SDK](https://www.nuget.org/packages/paypal/) - Explodes with the following exception

	```
    Unhandled Exception: FileNotFoundException: Could not load file or assembly 'System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'. The system cannot find the file specified.
    ```
