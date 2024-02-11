using DtoMapperPlugin.Services;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DtoMapperPlugin
{
    public partial class SettingsForm : Form
    {
        public Settings Settings { get; }
        private readonly CodeGenerationService _codeGenerationService;
        private readonly EntityMetadata _entityMetadata;
        private readonly IEnumerable<AttributeMetadata> _attributes;

        public SettingsForm(Settings settings, EntityMetadata entityMetadata, AttributeMetadata[] attributes)
        {
            _codeGenerationService = new CodeGenerationService();
            InitializeComponent();
            Settings = settings;
            _entityMetadata = entityMetadata;
            _attributes = attributes;
            UpdateControls();
            UpdateNotesTree();
            chk_notes.CheckedChanged += (s, e) => UpdateSettings();
            chk_onelineattributes.CheckedChanged += (s, e) => UpdateSettings();
            chk_onelinenotes.CheckedChanged += (s, e) => UpdateSettings();
        }

        private void GenerateCode()
        {
            var generationOptions = new GenerateModelOptions
            {
                Namespace = "Models",
                Entity = _entityMetadata,
                Attributes = _attributes,
                GenerationSettings = Settings,
            };
            var code = _codeGenerationService.GenerateModelClass(generationOptions);
            codebox.Code = code;
        }

        private void UpdateSettings()
        {
            Settings.GenerateLabels = chk_notes.Checked;
            Settings.GenerateLabelsOneLine = chk_onelinenotes.Checked;
            Settings.OneLineAttributes = chk_onelineattributes.Checked;
            GenerateCode();

        }
        private void UpdateControls()
        {
            chk_notes.Checked = Settings.GenerateLabels;
            chk_onelinenotes.Checked = Settings.GenerateLabelsOneLine;
            chk_onelineattributes.Checked = Settings.OneLineAttributes;
        }

        private void UpdateNotesTree()
        {
            if (!chk_notes.Checked)
            {
                chk_onelinenotes.Checked = false;
                chk_onelinenotes.Enabled = false;
            }
            else
            {
                chk_onelinenotes.Enabled = true;
            }

        }
        private void chk_notes_CheckedChanged(object sender, EventArgs e) => UpdateNotesTree();

        private void btn_saveclose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            UpdateSettings();
            Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            GenerateCode();
        }
    }
}
