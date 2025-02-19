using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModelExtensions", Version = "1.0")]

namespace Intent.Modules.VisualStudio.Projects.Api
{
    public static class AzureFunctionsProjectModelStereotypeExtensions
    {
        public static NETCoreSettings GetNETCoreSettings(this AzureFunctionsProjectModel model)
        {
            var stereotype = model.GetStereotype(".NET Core Settings");
            return stereotype != null ? new NETCoreSettings(stereotype) : null;
        }


        public static bool HasNETCoreSettings(this AzureFunctionsProjectModel model)
        {
            return model.HasStereotype(".NET Core Settings");
        }

        public static bool TryGetNETCoreSettings(this AzureFunctionsProjectModel model, out NETCoreSettings stereotype)
        {
            if (!HasNETCoreSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new NETCoreSettings(model.GetStereotype(".NET Core Settings"));
            return true;
        }

        public static AzureFunctionsProjectSettings GetAzureFunctionsProjectSettings(this AzureFunctionsProjectModel model)
        {
            var stereotype = model.GetStereotype("Azure Functions Project Settings");
            return stereotype != null ? new AzureFunctionsProjectSettings(stereotype) : null;
        }


        public static bool HasAzureFunctionsProjectSettings(this AzureFunctionsProjectModel model)
        {
            return model.HasStereotype("Azure Functions Project Settings");
        }

        public static bool TryGetAzureFunctionsProjectSettings(this AzureFunctionsProjectModel model, out AzureFunctionsProjectSettings stereotype)
        {
            if (!HasAzureFunctionsProjectSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new AzureFunctionsProjectSettings(model.GetStereotype("Azure Functions Project Settings"));
            return true;
        }

        public static CSharpProjectOptions GetCSharpProjectOptions(this AzureFunctionsProjectModel model)
        {
            var stereotype = model.GetStereotype("C# Project Options");
            return stereotype != null ? new CSharpProjectOptions(stereotype) : null;
        }


        public static bool HasCSharpProjectOptions(this AzureFunctionsProjectModel model)
        {
            return model.HasStereotype("C# Project Options");
        }

        public static bool TryGetCSharpProjectOptions(this AzureFunctionsProjectModel model, out CSharpProjectOptions stereotype)
        {
            if (!HasCSharpProjectOptions(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new CSharpProjectOptions(model.GetStereotype("C# Project Options"));
            return true;
        }

        public class NETCoreSettings
        {
            private IStereotype _stereotype;

            public NETCoreSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public bool TargetMultipleFrameworks()
            {
                return _stereotype.GetProperty<bool>("Target Multiple Frameworks");
            }

            public IElement TargetFramework()
            {
                return _stereotype.GetProperty<IElement>("Target Framework");
            }

            public IElement[] TargetFrameworks()
            {
                return _stereotype.GetProperty<IElement[]>("Target Frameworks") ?? new IElement[0];
            }

            public string RuntimeIdentifiers()
            {
                return _stereotype.GetProperty<string>("Runtime Identifiers");
            }

            public string Configurations()
            {
                return _stereotype.GetProperty<string>("Configurations");
            }

            public string RootNamespace()
            {
                return _stereotype.GetProperty<string>("Root Namespace");
            }

            public string UserSecretsId()
            {
                return _stereotype.GetProperty<string>("User Secrets Id");
            }

            public GenerateRuntimeConfigurationFilesOptions GenerateRuntimeConfigurationFiles()
            {
                return new GenerateRuntimeConfigurationFilesOptions(_stereotype.GetProperty<string>("Generate Runtime Configuration Files"));
            }

            public GenerateDocumentationFileOptions GenerateDocumentationFile()
            {
                return new GenerateDocumentationFileOptions(_stereotype.GetProperty<string>("Generate Documentation File"));
            }

            public string AssemblyName()
            {
                return _stereotype.GetProperty<string>("Assembly Name");
            }

            public class GenerateRuntimeConfigurationFilesOptions
            {
                public readonly string Value;

                public GenerateRuntimeConfigurationFilesOptions(string value)
                {
                    Value = value;
                }

                public GenerateRuntimeConfigurationFilesOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "(unspecified)":
                            return GenerateRuntimeConfigurationFilesOptionsEnum.Unspecified;
                        case "false":
                            return GenerateRuntimeConfigurationFilesOptionsEnum.False;
                        case "true":
                            return GenerateRuntimeConfigurationFilesOptionsEnum.True;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsUnspecified()
                {
                    return Value == "(unspecified)";
                }
                public bool IsFalse()
                {
                    return Value == "false";
                }
                public bool IsTrue()
                {
                    return Value == "true";
                }
            }

            public enum GenerateRuntimeConfigurationFilesOptionsEnum
            {
                Unspecified,
                False,
                True
            }
            public class GenerateDocumentationFileOptions
            {
                public readonly string Value;

                public GenerateDocumentationFileOptions(string value)
                {
                    Value = value;
                }

                public GenerateDocumentationFileOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "(unspecified)":
                            return GenerateDocumentationFileOptionsEnum.Unspecified;
                        case "false":
                            return GenerateDocumentationFileOptionsEnum.False;
                        case "true":
                            return GenerateDocumentationFileOptionsEnum.True;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsUnspecified()
                {
                    return Value == "(unspecified)";
                }
                public bool IsFalse()
                {
                    return Value == "false";
                }
                public bool IsTrue()
                {
                    return Value == "true";
                }
            }

            public enum GenerateDocumentationFileOptionsEnum
            {
                Unspecified,
                False,
                True
            }
        }

        public class AzureFunctionsProjectSettings
        {
            private IStereotype _stereotype;

            public AzureFunctionsProjectSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public AzureFunctionsVersionOptions AzureFunctionsVersion()
            {
                return new AzureFunctionsVersionOptions(_stereotype.GetProperty<string>("Azure Functions Version"));
            }

            public class AzureFunctionsVersionOptions
            {
                public readonly string Value;

                public AzureFunctionsVersionOptions(string value)
                {
                    Value = value;
                }

                public AzureFunctionsVersionOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "v2":
                            return AzureFunctionsVersionOptionsEnum.V2;
                        case "v3":
                            return AzureFunctionsVersionOptionsEnum.V3;
                        case "v4":
                            return AzureFunctionsVersionOptionsEnum.V4;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsV2()
                {
                    return Value == "v2";
                }
                public bool IsV3()
                {
                    return Value == "v3";
                }
                public bool IsV4()
                {
                    return Value == "v4";
                }
            }

            public enum AzureFunctionsVersionOptionsEnum
            {
                V2,
                V3,
                V4
            }
        }

        public class CSharpProjectOptions
        {
            private IStereotype _stereotype;

            public CSharpProjectOptions(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public LanguageVersionOptions LanguageVersion()
            {
                return new LanguageVersionOptions(_stereotype.GetProperty<string>("Language Version"));
            }

            public string RelativeLocation()
            {
                return _stereotype.GetProperty<string>("Relative Location");
            }

            public NullableOptions Nullable()
            {
                return new NullableOptions(_stereotype.GetProperty<string>("Nullable"));
            }

            public bool NullableEnabled()
            {
                return _stereotype.GetProperty<bool>("Nullable Enabled");
            }

            public class LanguageVersionOptions
            {
                public readonly string Value;

                public LanguageVersionOptions(string value)
                {
                    Value = value;
                }

                public LanguageVersionOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "default":
                            return LanguageVersionOptionsEnum.Default;
                        case "latest":
                            return LanguageVersionOptionsEnum.Latest;
                        case "preview":
                            return LanguageVersionOptionsEnum.Preview;
                        case "9.0":
                            return LanguageVersionOptionsEnum._90;
                        case "8.0":
                            return LanguageVersionOptionsEnum._80;
                        case "7.3":
                            return LanguageVersionOptionsEnum._73;
                        case "7.2":
                            return LanguageVersionOptionsEnum._72;
                        case "7.1":
                            return LanguageVersionOptionsEnum._71;
                        case "7":
                            return LanguageVersionOptionsEnum._7;
                        case "6":
                            return LanguageVersionOptionsEnum._6;
                        case "5":
                            return LanguageVersionOptionsEnum._5;
                        case "4":
                            return LanguageVersionOptionsEnum._4;
                        case "3":
                            return LanguageVersionOptionsEnum._3;
                        case "2":
                            return LanguageVersionOptionsEnum._2;
                        case "1":
                            return LanguageVersionOptionsEnum._1;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsDefault()
                {
                    return Value == "default";
                }
                public bool IsLatest()
                {
                    return Value == "latest";
                }
                public bool IsPreview()
                {
                    return Value == "preview";
                }
                public bool Is90()
                {
                    return Value == "9.0";
                }
                public bool Is80()
                {
                    return Value == "8.0";
                }
                public bool Is73()
                {
                    return Value == "7.3";
                }
                public bool Is72()
                {
                    return Value == "7.2";
                }
                public bool Is71()
                {
                    return Value == "7.1";
                }
                public bool Is7()
                {
                    return Value == "7";
                }
                public bool Is6()
                {
                    return Value == "6";
                }
                public bool Is5()
                {
                    return Value == "5";
                }
                public bool Is4()
                {
                    return Value == "4";
                }
                public bool Is3()
                {
                    return Value == "3";
                }
                public bool Is2()
                {
                    return Value == "2";
                }
                public bool Is1()
                {
                    return Value == "1";
                }
            }

            public enum LanguageVersionOptionsEnum
            {
                Default,
                Latest,
                Preview,
                _90,
                _80,
                _73,
                _72,
                _71,
                _7,
                _6,
                _5,
                _4,
                _3,
                _2,
                _1
            }
            public class NullableOptions
            {
                public readonly string Value;

                public NullableOptions(string value)
                {
                    Value = value;
                }

                public NullableOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "(unspecified)":
                            return NullableOptionsEnum.Unspecified;
                        case "disable":
                            return NullableOptionsEnum.Disable;
                        case "enable":
                            return NullableOptionsEnum.Enable;
                        case "warnings":
                            return NullableOptionsEnum.Warnings;
                        case "annotations":
                            return NullableOptionsEnum.Annotations;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsUnspecified()
                {
                    return Value == "(unspecified)";
                }

                public bool IsDisable()
                {
                    return Value == "disable";
                }
                public bool IsEnable()
                {
                    return Value == "enable";
                }
                public bool IsWarnings()
                {
                    return Value == "warnings";
                }
                public bool IsAnnotations()
                {
                    return Value == "annotations";
                }
            }

            public enum NullableOptionsEnum
            {
                Unspecified,
                Disable,
                Enable,
                Warnings,
                Annotations
            }
        }

    }
}