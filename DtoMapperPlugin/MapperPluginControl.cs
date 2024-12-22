using DtoMapperPlugin.Controllers;
using DtoMapperPlugin.Services;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace DtoMapperPlugin
{
    public partial class MapperPluginControl : PluginControlBase, IStatusBarMessenger
    {
        private Settings mySettings;
        private EntityMetadata[] _entitiesMetadta;
        private AttributeMetadata[] _attributesMetadta;
        private CodeGenerationService _codeGenerationService;

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

        public MapperPluginControl()
        {
            _codeGenerationService = new CodeGenerationService();
            InitializeComponent();
            entitilesList.SelectedItemsChanged += EntitilesList_SelectedItemsChanged;
            attributesList.SelectedItemsChanged += AttributesList_SelectedItemsChanged;
            codeTextbox.CodeCopidToClipboard += CodeTextbox_CodeCopidToClipboard;
        }

        private void CodeTextbox_CodeCopidToClipboard()
        {
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Code copied to clipboard"));
        }

        private void AttributesList_SelectedItemsChanged(IEnumerable<FilteredListItem> items)
        {
            if (!items.Any())
            {
                codeTextbox.Code = string.Empty;
                return;
            }
            var entityLogicalName = entitilesList.SelectedKeys.FirstOrDefault();
            if (entityLogicalName == default)
                return;

            var selectedAttributes = attributesList.SelectedKeys;
            var entity = _entitiesMetadta.FirstOrDefault(e => e.LogicalName == entityLogicalName);
            var attributes = _attributesMetadta.Where(a => selectedAttributes.Contains(a.LogicalName));
            var generationOptions = new GenerateModelOptions
            {
                Namespace = "Models",
                Entity = entity,
                Attributes = attributes,
                GenerateLabels = true,
            };
            var code = _codeGenerationService.GenerateModelClass(generationOptions);
            codeTextbox.Code = code;
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This tool is generating DTO classes that are designed to work with \"YC.DynamicsMapper\" source generator", new Uri("https://github.com/YonatanCohavi/DynamicsMapper"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
            Init();
        }
        private void Init()
        {
            attributesList.Reset();
            entitilesList.Reset();
            ExecuteMethod(GetEntities);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            var f = new HelpForm();
            f.ShowDialog();

        }
        private void EntitilesList_SelectedItemsChanged(IEnumerable<FilteredListItem> items)
        {
            var item = items.FirstOrDefault();
            if (item == default)
                return;

            var selectedEntity = _entitiesMetadta.Single(e => e.LogicalName == item.Key);
            ExecuteMethod(UpdateAttributes, selectedEntity);
        }

        private void UpdateAttributes(EntityMetadata entityMetadata)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieve Attributes",
                Work = (worker, args) =>
                {
                    var r = new RetrieveEntityRequest
                    {
                        EntityFilters = EntityFilters.Attributes,
                        RetrieveAsIfPublished = true,
                        LogicalName = entityMetadata.LogicalName,
                    };
                    var response = (RetrieveEntityResponse)Service.Execute(r);
                    args.Result = response.EntityMetadata.Attributes;

                },
                PostWorkCallBack = (args) =>
                {
                    var attributes = (AttributeMetadata[])args.Result;
                    _attributesMetadta = attributes
                        .Where(a => a.IsValidForRead == true)
                        .Where(a => string.IsNullOrEmpty(a.AttributeOf))
                        .OrderBy(a => a.LogicalName)
                        .ToArray();

                    var items = _attributesMetadta
                        .Select(e => new FilteredListItem(e.LogicalName)
                        {
                            Type = e.AttributeType.ToString(),
                            Bold = entityMetadata.PrimaryIdAttribute == e.LogicalName,
                            Disabled = _codeGenerationService.NotSupportedTypes.Contains(e.AttributeType.Value)
                        });
                    attributesList.SetItems(items, true);
                    attributesList.CheckItem(entityMetadata.PrimaryIdAttribute);

                }
            });
        }

        private void GetEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieve Entities",
                Work = (worker, args) =>
                {
                    var r = new RetrieveAllEntitiesRequest
                    {
                        EntityFilters = EntityFilters.Entity,
                        RetrieveAsIfPublished = true,
                    };
                    var response = (RetrieveAllEntitiesResponse)Service.Execute(r);
                    args.Result = response.EntityMetadata;

                },
                PostWorkCallBack = (args) =>
                {
                    var entities = (EntityMetadata[])args.Result;
                    _entitiesMetadta = entities
                    .Where(e => e.IsPrivate != true)
                    .OrderBy(e => e.LogicalName).ToArray();
                    var items = _entitiesMetadta
                    .Select(e => new FilteredListItem(e.LogicalName));
                    entitilesList.SetItems(items, true);
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
            Init();

        }
    }

}