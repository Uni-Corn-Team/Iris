﻿#pragma checksum "..\..\..\Windows\SignUpWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D77093D4CBC15E59989E77EB1371D5825E6F10F11AE370416042F8533A5D013F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ChatClient;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ChatClient {
    
    
    /// <summary>
    /// SignUpWindow
    /// </summary>
    public partial class SignUpWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 120 "..\..\..\Windows\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\Windows\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSurname;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Windows\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNickname;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\Windows\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbAge;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\Windows\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbLogin;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\Windows\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPassword;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\Windows\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lErorrMes;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\Windows\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lAgeErorr;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Windows\SignUpWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/IrisClient;component/windows/signupwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\SignUpWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbName = ((System.Windows.Controls.TextBox)(target));
            
            #line 120 "..\..\..\Windows\SignUpWindow.xaml"
            this.tbName.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RemoveTextName);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbSurname = ((System.Windows.Controls.TextBox)(target));
            
            #line 121 "..\..\..\Windows\SignUpWindow.xaml"
            this.tbSurname.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RemoveTextSurname);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbNickname = ((System.Windows.Controls.TextBox)(target));
            
            #line 122 "..\..\..\Windows\SignUpWindow.xaml"
            this.tbNickname.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RemoveTextNickname);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbAge = ((System.Windows.Controls.TextBox)(target));
            
            #line 123 "..\..\..\Windows\SignUpWindow.xaml"
            this.tbAge.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RemoveTextAge);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbLogin = ((System.Windows.Controls.TextBox)(target));
            
            #line 124 "..\..\..\Windows\SignUpWindow.xaml"
            this.tbLogin.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RemoveTextLogin);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tbPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 125 "..\..\..\Windows\SignUpWindow.xaml"
            this.tbPassword.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RemoveTextPassword);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 126 "..\..\..\Windows\SignUpWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_SignUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lErorrMes = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lAgeErorr = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\..\Windows\SignUpWindow.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.ButtonClickBack);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

