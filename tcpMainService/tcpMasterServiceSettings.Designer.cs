﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34209
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tcpMainService {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class tcpMasterServiceSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static tcpMasterServiceSettings defaultInstance = ((tcpMasterServiceSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new tcpMasterServiceSettings())));
        
        public static tcpMasterServiceSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("12437")]
        public int port {
            get {
                return ((int)(this["port"]));
            }
            set {
                this["port"] = value;
            }
        }
    }
}