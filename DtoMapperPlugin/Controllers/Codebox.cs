using FastColoredTextBoxNS;
using System;
using System.Windows.Forms;

namespace DtoMapperPlugin.Controllers
{
    public partial class Codebox : UserControl
    {
        public event Action CodeCopidToClipboard;
        public string Code { get => codeTextbox.Text; set => codeTextbox.Text = value; }
        public Language Language { get => codeTextbox.Language; set => codeTextbox.Language = value; }
        public Codebox()
        {
            InitializeComponent();
        }

        private void CopyCode(object sender, System.EventArgs e)
        {
            Clipboard.SetText(Code);
            CodeCopidToClipboard?.Invoke();
        }
    }
}
