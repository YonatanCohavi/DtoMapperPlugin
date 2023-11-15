using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace DtoMapperPlugin
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Dto Classes Generator"),
        ExportMetadata("Description", "This is a class generator designed to work with a dedicated source generator that generates mappers from the Dynamics CRM \"Entity\" object to a DTO"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAIGNIUk0AAHomAACAhAAA+gAAAIDoAAB1MAAA6mAAADqYAAAXcJy6UTwAAAAGYktHRAD/AP8A/6C9p5MAAAAJcEhZcwAAA7EAAAOxAfWD7UkAAAAHdElNRQfnCw4GDR4btvgkAAAHSElEQVRYw+WXe4wV1R3HP+fMfT92770suwsL7C5vWBBwgVgoaCmV0sCKVkIhtWJrgi2miZZQaVpjJIqYtkSrKYptokH6oBpBGlAD8pJHSwFZWFh2gX2xsC9279697zvn9I9798VDidr+0X6TyUzOzPnN9/f9zvnODPy/Q3zOeQlkA25AA11A8L9BwAfcixDfsfoHlFhcnoDWWptdnS3JYPsJYAewF4j8JwjcLR3OX/qnzZ6dM7fM5i25E1sgB60UiZarBE8eoeWjbZHOT4/+XZvmWqD8qySw2FFQtKHosZ8X5Jctw5KVlb5C9b863tLM5S2vUf/mS2eS7W0/Bg58UQJG384dBUWvj3321YL8sqUImx2UJtkRBCEQ0kg/BRoMlwf/9NlYfQNyg8cOlqp47GOg7csQ8EmH89URT66dlF+2FK1BCNApk6r1q7FmB3AWFqYl0N1qCLzjJ5EKdeZ1HDvoAnZmtJLA9Mxx1+cRkJn9vf5ps2bllS1Da1DxGNGGOqK11YSrzhC5VEmsrp5YQx0qmUjP0BphGBQsW4FnzMRFQGmfmquBjcCg21FAIsTPhv3wiVL/9FkIoKvyNOef/SnNO7cSrqogfL6ca/s/oPXAB2SVlGIfmNdjhyXLT7S22hk8cbheSLlPaK2AmQOzrT8wFcWm0gc+SwkLELD6c0q8JekGtNK4R4xl3LpNqHiMc7/6CfllSzETCbxjJ+IePgatdE8BYUDWHdMRVutknUz6SGdGfO6UAF6X8cAbu64IpfRK4MqtLHBbXG6/LZDT46+02XEOGYYyFanODpo/2kbDmy8TbahF2q39K2iwD8xH2hwz3A65vTjfcWDsUNeKojwHzz08nEfnDbpfCvHKreywpO3UaKV6BoUUtP/zEOefX0W04RK2/CEkg+3U/H4dhttL7rfKQPeqYCrN6MH2vLVLhuVNKPLgdhh4nAZZTgvPPzIcBA/8YdcVp6n0U8Cp658BIaRclDNnwVDn0MKMCoKaTb/GFsjF4s3G4huA4fKQ880ymnduZeDcMqTdkbFA0Hb0AJOu7uYXSwrJybbhcRrYrRKtwWWXzJrgw2mTo8ovhe+JJlQ5UNvXgo5ksP1E8OSRXloC7HkFhC+dJ1p/kbbd7zPou8vxjJmAGY+hzVSvAylF6PghphQ5MKRAKY3WvQIpDVkugzXfK+S5R4aP83stvwPG9lUAQJnRyP0531hgM9weANzFo4k11qPNFEMeWsng+5YRPHkUz6gS/FNn9lgVqjpLYssLrFngIz9gTweV7JMX3Z0KmDzcSyhq5n1SEfSQzg2zm0BjorlxvOHylPinzwYhMFxuBsyYQ978xWRPmoaQEu/oErImliKEACFQsSgXNzzNYt85ls7JRwgIRlJsO9zKkIF2HDbZj4QhBaMKnOw91VF0tT2xH6jrJpBE68quyvLZVl8g1ztuMkiZ6bK3iJASIQRCZm6+8UVGl29h3fIifG4LhhS8f6SVFS9XMqHQw8RiD31WLBrweazUN8cdB88Er9qsck/fd0GzikXLO44dLFXRSJ53QinS4QCdllpIgTAEKE1X1VkubHiaUeVbeOlHQxlZ4EZrCMcU6/5Si90qqW+NM3/qAGwWcYMKXTGT7UdaI7GEetegP+pUPPZx8F8HC1OdHWN8U7+OMAxCZ08Rrqqg/R8HadiykfBb61gSOMsLDxcxssCNUhpDCvaeaufD4+38dsVIth9uZViunVEFrr4rFiEEnZEU737SGgrHzK2Wm2RDpVbqsct/et1EyEUFy1ZQsXp5Ilp74aRKxC5o0xz8+MLBd69/dDRSgMpoHE8qNu9pojWY5L1DrbQGk7y9p4l77vBjMW5UQQokICQ3R6NW5srLf37tvZpX1qKikYgZDT9pOF3LgLejCd2zxLoLnqgOcbomzLypAYSAeVMDnK4Jc6I6lF4VPQpAWyhJOKY6gLCFW6NRp1Irm3a+g5ByIZCT6goBnDtTFw61d6W8Aa+lR96KujAL7xrAM98vRmby4JnNl6ioC3PXuOx+hT+92EVnJFUBhD6LAEAjWj2uTRUF7Jmx0xW14fJDFcEZ930th5SpMZXmwVm56W8IDSlTI4BVDw5D63RUd3d/LZRk17FrceBD6P9FdCuEgF1AJZACYvGktgYj5vxvTw1Il12iAbtFYrPIfvljy4z19X7z7ibe2Nm4L2XqF4HY7RAASGZu3o3qmqbYeA1jZ5b4sBri+uC7ARZDsK+8g6f+eKGluSP5BFBxuwrcDHGlOX6iumtKVzQ1bNIIL1mutJt9iQiR7tpUmh1H21i1qbqjsiGyxu+x/i2WSL99vygBgGtJU+8/WhnKPXa+c5RAWLI9Fhw2iZRgKgiGTY5VhfjNO/Ws/2vtuZqm2Coh2BxN9Obj5/0Z3Q7cwEK7VT5UnO+4szjfGfB7LJZ4UunLrfFwdWP0YmtncgfwFlB1/eSvgkA3nEBxZvMBceAyUO20y5ZoXH2J0v/L+Dd55w0jKSQBVwAAACV0RVh0ZGF0ZTpjcmVhdGUAMjAyMy0xMS0xNFQwNjoxMzoyNSswMDowME63ZKwAAAAldEVYdGRhdGU6bW9kaWZ5ADIwMjMtMTEtMTRUMDY6MTM6MjUrMDA6MDA/6twQAAAAKHRFWHRkYXRlOnRpbWVzdGFtcAAyMDIzLTExLTE0VDA2OjEzOjMwKzAwOjAw9m3S9gAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MapperPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MapperPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MapperPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}