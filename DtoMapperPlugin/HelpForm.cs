using System;
using System.Windows.Forms;

namespace DtoMapperPlugin
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            codebox1.Language = FastColoredTextBoxNS.Language.XML;
            codebox1.Code = GetMapperProjectDemo();
        }
        private string GetMapperProjectDemo()
        {
            return "<Project Sdk=\"Microsoft.NET.Sdk\">\r\n\r\n  <PropertyGroup>\r\n    <TargetFrameworks>net462;net6.0</TargetFrameworks>\r\n    <Nullable>enable</Nullable>\r\n    <LangVersion>8.0</LangVersion>\r\n  </PropertyGroup>\r\n\r\n  <ItemGroup>\r\n    <PackageReference Include=\"YC.DynamicsMapper\" Version=\"1.1.1\" />\r\n  </ItemGroup>\r\n  <ItemGroup Condition=\"'$(TargetFramework)' == 'net462'\">\r\n    <PackageReference Include=\"Microsoft.CrmSdk.CoreAssemblies\" Version=\"9.0.2.49\" />\r\n  </ItemGroup>\r\n  <ItemGroup Condition=\"'$(TargetFramework)' == 'net6.0'\">\r\n    <PackageReference Include=\"Microsoft.PowerPlatform.Dataverse.Client\" Version=\"1.1.12\" />\r\n  </ItemGroup>\r\n</Project>\r\n";
        }

    }
}
