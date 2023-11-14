using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Linq;
using System.Threading;

namespace DtoMapperPlugin.Services
{
    internal class CodeGenerationService
    {
        private AttributeTypeCode[] _notsupprted;
        public AttributeTypeCode[] NotSupportedTypes => GetNotSupportedTypes();
        public AttributeTypeCode[] GetNotSupportedTypes()
        {
            if (_notsupprted != null)
                return _notsupprted;

            var values = (AttributeTypeCode[])Enum.GetValues(typeof(AttributeTypeCode));
            _notsupprted = values.Where(v =>
            {
                var mapperAttribute = GetMapperType(v);
                return string.IsNullOrEmpty(mapperAttribute);
            }).ToArray();
            return _notsupprted;
        }
        public string GenerateModelClass(GenerateModelOptions options)
        {
            var entity = options.Entity;
            var cw = new CodeWriter();
            cw.AddUsing("DynamicsMapper.Abstractions");
            cw.AddUsing("System");
            using (cw.BeginScope($"namespace {options.Namespace}"))
            {
                var entityname = entity.DisplayName?.UserLocalizedLabel?.Label ?? string.Empty;
                if (options.GenerateLabels && entityname != string.Empty)
                {
                    cw.AppendLine("/// <summary>");
                    cw.AppendLine($"/// {entityname}");
                    cw.AppendLine($"/// <para>{entity.LogicalName}</para>");
                    cw.AppendLine("/// </summary>");
                }
                cw.AppendLine($"[CrmEntity(\"{entity.LogicalName}\")]");
                using (cw.BeginScope($"public class {LogicalToPropertyName(entity.LogicalName, entity.IsCustomEntity)}"))
                {
                    if (options.Attributes.Any(att => entity.PrimaryIdAttribute == att.LogicalName))
                    {
                        cw.AppendLine($"[CrmField(\"{entity.PrimaryIdAttribute}\", Mapping = MappingType.PrimaryId)]");
                        cw.AppendLine($"public Guid? Id {{ get; set; }}");
                    }
                    foreach (var att in options.Attributes)
                    {
                        // primary attribute is always first
                        if (entity.PrimaryIdAttribute == att.LogicalName)
                            continue;

                        var property = GetMapperAtribute(att);
                        var mapperAttribute = GetProperty(att);

                        if (string.IsNullOrEmpty(mapperAttribute) || string.IsNullOrEmpty(property))
                            continue;
                        var label = att.DisplayName?.UserLocalizedLabel?.Label ?? string.Empty;
                        if (options.GenerateLabels && label != string.Empty)
                        {
                            cw.AppendLine("/// <summary>");
                            cw.AppendLine($"/// {label}");
                            cw.AppendLine($"/// <para>{att.LogicalName}</para>");
                            cw.AppendLine("/// </summary>");
                        }
                        cw.AppendLine(property);
                        cw.AppendLine(mapperAttribute);
                    }
                }
            }
            return cw.ToString();
        }
        private string LogicalToPropertyName(string logicalName, bool? removePrefix = null)
        {
            // remove the publisher prefix for custom attributes
            string cleanSchema;
            if (removePrefix == true)
            {
                var parts = logicalName.Split('_');
                var skipCount = parts.Count() > 1 ? 1 : 0;
                cleanSchema = string.Join("_", parts.Skip(skipCount));
            }
            else
            {
                cleanSchema = logicalName;
            }

            return string.Concat(cleanSchema
                .Split('_')
                .Select(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase));
        }

        private string GetMapperAtribute(AttributeMetadata att)
        {
            switch (att.AttributeType)
            {
                case AttributeTypeCode.Customer:
                case AttributeTypeCode.Lookup:
                case AttributeTypeCode.Owner:
                    if (!(att is LookupAttributeMetadata lookupMd))
                        throw new Exception("invalid metadata type");
                    return $"[CrmField(\"{att.LogicalName}\", Mapping = MappingType.Lookup,Target = \"{lookupMd.Targets.FirstOrDefault()}\")]";
                case AttributeTypeCode.Money:
                    return $"[CrmField(\"{att.LogicalName}\", Mapping = MappingType.Money)]";
                case AttributeTypeCode.Picklist:
                case AttributeTypeCode.State:
                case AttributeTypeCode.Status:
                    return $"[CrmField(\"{att.LogicalName}\", Mapping = MappingType.Options)]";
                case null:
                case AttributeTypeCode.ManagedProperty:
                case AttributeTypeCode.PartyList:
                case AttributeTypeCode.CalendarRules:
                case AttributeTypeCode.Virtual:
                    return string.Empty;
                case AttributeTypeCode.Boolean:
                case AttributeTypeCode.DateTime:
                case AttributeTypeCode.Decimal:
                case AttributeTypeCode.Double:
                case AttributeTypeCode.String:
                case AttributeTypeCode.Integer:
                case AttributeTypeCode.Memo:
                case AttributeTypeCode.Uniqueidentifier:
                case AttributeTypeCode.BigInt:
                case AttributeTypeCode.EntityName:
                    return $"[CrmField(\"{att.LogicalName}\")]";
                default:
                    throw new Exception("attrbiute type is not supported");
            }
        }
        private string GetProperty(AttributeMetadata att)
        {
            var typeString = GetMapperType(att.AttributeType);
            return $"public {typeString} {LogicalToPropertyName(att.LogicalName, att.IsCustomAttribute)} {{ get; set; }}";
        }
        private string GetMapperType(AttributeTypeCode? attributeType)
        {
            switch (attributeType)
            {
                case AttributeTypeCode.Customer:
                case AttributeTypeCode.Lookup:
                case AttributeTypeCode.Owner:
                    return "Guid?";
                case AttributeTypeCode.Money:
                case AttributeTypeCode.Decimal:
                    return "decimal?";
                case AttributeTypeCode.Picklist:
                case AttributeTypeCode.State:
                case AttributeTypeCode.Status:
                    return "int?";
                case null:
                case AttributeTypeCode.ManagedProperty:
                case AttributeTypeCode.PartyList:
                case AttributeTypeCode.CalendarRules:
                case AttributeTypeCode.Virtual:
                    return string.Empty;
                case AttributeTypeCode.Boolean:
                    return "bool?";
                case AttributeTypeCode.DateTime:
                    return "DateTime?";
                case AttributeTypeCode.Double:
                    return "double?";
                case AttributeTypeCode.String:
                case AttributeTypeCode.EntityName:
                case AttributeTypeCode.Memo:
                    return "string?";
                case AttributeTypeCode.Integer:
                case AttributeTypeCode.BigInt:
                    return "int?";
                case AttributeTypeCode.Uniqueidentifier:
                    return "Guid?";
                default:
                    throw new Exception("attrbiute type is not supported");
            }
        }
    }
}
