﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Resources.Messages {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MessageContents {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MessageContents() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Core.Resources.Messages.MessageContents", typeof(MessageContents).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Oops! It seems you&apos;re not a member of our channel yet. To access all the features and resources, please join our channel first.
        ///
        ///
        ///@LexiEnglish
        ///Once you&apos;ve joined, you&apos;ll be able to chat with me and get started on your English learning journey!.
        /// </summary>
        public static string USER_IS_NOT_IN_CHANNEL {
            get {
                return ResourceManager.GetString("USER_IS_NOT_IN_CHANNEL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hi there! 👋 I&apos;m Lexi, your friendly English learning assistant. I&apos;m here to help you improve your English skills. Just send me a message and we can get started.
        ///
        ///Need help with:
        ///
        ///Grammar
        ///Vocabulary
        ///Pronunciation
        ///Writing
        ///Speaking practice
        ///Let&apos;s make learning English fun and easy together! 📚.
        /// </summary>
        public static string WELCOME {
            get {
                return ResourceManager.GetString("WELCOME", resourceCulture);
            }
        }
    }
}