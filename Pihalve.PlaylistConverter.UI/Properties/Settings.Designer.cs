﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pihalve.PlaylistConverter.UI.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IncludeArtistInSearch {
            get {
                return ((bool)(this["IncludeArtistInSearch"]));
            }
            set {
                this["IncludeArtistInSearch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IncludeAlbumInSearch {
            get {
                return ((bool)(this["IncludeAlbumInSearch"]));
            }
            set {
                this["IncludeAlbumInSearch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IncludeYearInSearch {
            get {
                return ((bool)(this["IncludeYearInSearch"]));
            }
            set {
                this["IncludeYearInSearch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IncludeTrackInSearch {
            get {
                return ((bool)(this["IncludeTrackInSearch"]));
            }
            set {
                this["IncludeTrackInSearch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool RemoveParenthesesPartsFromArtist {
            get {
                return ((bool)(this["RemoveParenthesesPartsFromArtist"]));
            }
            set {
                this["RemoveParenthesesPartsFromArtist"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool RemoveParenthesesPartsFromAlbum {
            get {
                return ((bool)(this["RemoveParenthesesPartsFromAlbum"]));
            }
            set {
                this["RemoveParenthesesPartsFromAlbum"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool RemoveParenthesesPartsFromTrack {
            get {
                return ((bool)(this["RemoveParenthesesPartsFromTrack"]));
            }
            set {
                this["RemoveParenthesesPartsFromTrack"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>Pihalve.PlaylistConverter.Application.Services.Spotify.Rules.IncludeAlbumF" +
            "ilterRule,Pihalve.PlaylistConverter.Application;False;Exclude album from search<" +
            "/string>\r\n  <string>Pihalve.PlaylistConverter.Application.Services.Spotify.Rules" +
            ".IncludeArtistFilterRule,Pihalve.PlaylistConverter.Application;False;Exclude art" +
            "ist from search</string>\r\n  <string>Pihalve.PlaylistConverter.Application.Servic" +
            "es.Spotify.Rules.IncludeTrackFilterRule,Pihalve.PlaylistConverter.Application;Fa" +
            "lse;Exclude track from search</string>\r\n  <string>Pihalve.PlaylistConverter.Appl" +
            "ication.Services.Spotify.Rules.IncludeYearFilterRule,Pihalve.PlaylistConverter.A" +
            "pplication;False;Exclude year from search</string>\r\n  <string>Pihalve.PlaylistCo" +
            "nverter.Application.Domain.Rules.RemoveArtistParenthesesPartsProcessorRule,Pihal" +
            "ve.PlaylistConverter.Application;False;Remove artist parentheses parts from sear" +
            "ch</string>\r\n  <string>Pihalve.PlaylistConverter.Application.Domain.Rules.Remove" +
            "AlbumParenthesesPartsProcessorRule,Pihalve.PlaylistConverter.Application;False;R" +
            "emove album parentheses parts from search</string>\r\n  <string>Pihalve.PlaylistCo" +
            "nverter.Application.Domain.Rules.RemoveTrackParenthesesPartsProcessorRule,Pihalv" +
            "e.PlaylistConverter.Application;False;Remove track parentheses parts from search" +
            "</string>\r\n  <string>Pihalve.PlaylistConverter.Application.Domain.Rules.RemoveWo" +
            "rdsProcessorRule,Pihalve.PlaylistConverter.Application;False;Remove words from s" +
            "earch</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection FallbackSequence {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["FallbackSequence"]));
            }
            set {
                this["FallbackSequence"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string WordsToRemove {
            get {
                return ((string)(this["WordsToRemove"]));
            }
            set {
                this["WordsToRemove"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool RemoveWords {
            get {
                return ((bool)(this["RemoveWords"]));
            }
            set {
                this["RemoveWords"] = value;
            }
        }
    }
}
