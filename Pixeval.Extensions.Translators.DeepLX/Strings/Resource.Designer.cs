﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pixeval.Extensions.Translators.DeepLX.Strings {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Pixeval.Extensions.Translators.DeepLX.Strings.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性，对
        ///   使用此强类型资源类的所有资源查找执行重写。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 DeepL Access Token，留空则使用默认的 的本地化字符串。
        /// </summary>
        internal static string AccessTokenSettingsDescription {
            get {
                return ResourceManager.GetString("AccessTokenSettingsDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 DeepLX 翻译 的本地化字符串。
        /// </summary>
        internal static string DeepLXTranslatorLabel {
            get {
                return ResourceManager.GetString("DeepLXTranslatorLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 留空则会自动创建一个服务器使用，若填入自己的 DeepLX 服务器地址则不会创建，且以下的设置项都无效 的本地化字符串。
        /// </summary>
        internal static string EndPointSettingsDescription {
            get {
                return ResourceManager.GetString("EndPointSettingsDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 服务器地址 的本地化字符串。
        /// </summary>
        internal static string EndPointSettingsLabel {
            get {
                return ResourceManager.GetString("EndPointSettingsLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 DeepLX 翻译扩展，无需API Key 的本地化字符串。
        /// </summary>
        internal static string ExtensionHostDescription {
            get {
                return ResourceManager.GetString("ExtensionHostDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 DeepLX 翻译 的本地化字符串。
        /// </summary>
        internal static string ExtensionHostName {
            get {
                return ResourceManager.GetString("ExtensionHostName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 DeepLX 本地服务器使用的端口号 的本地化字符串。
        /// </summary>
        internal static string PortSettingsDescription {
            get {
                return ResourceManager.GetString("PortSettingsDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 端口号 的本地化字符串。
        /// </summary>
        internal static string PortSettingsLabel {
            get {
                return ResourceManager.GetString("PortSettingsLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 DeepL Pro 令牌，留空则不使用 的本地化字符串。
        /// </summary>
        internal static string ProSessionSettingsDescription {
            get {
                return ResourceManager.GetString("ProSessionSettingsDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 DeepLX 使用的 http 代理服务器 IP 的本地化字符串。
        /// </summary>
        internal static string ProxySettingsDescription {
            get {
                return ResourceManager.GetString("ProxySettingsDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 代理服务器 的本地化字符串。
        /// </summary>
        internal static string ProxySettingsLabel {
            get {
                return ResourceManager.GetString("ProxySettingsLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 DeepLX 请求超时秒数 的本地化字符串。
        /// </summary>
        internal static string TimeoutSettingsDescription {
            get {
                return ResourceManager.GetString("TimeoutSettingsDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 超时时间 的本地化字符串。
        /// </summary>
        internal static string TimeoutSettingsLabel {
            get {
                return ResourceManager.GetString("TimeoutSettingsLabel", resourceCulture);
            }
        }
    }
}
