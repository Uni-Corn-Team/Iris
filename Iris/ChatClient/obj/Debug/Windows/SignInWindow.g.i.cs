﻿#pragma checksum "..\..\..\Windows\SignInWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B8EFE9BF8BCAE4559757FF5AB8BE82753BCA1A624D740DFF155F16DD9ECA3762"
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
    /// SignIn
    /// </summary>
    public partial class SignIn : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 120 "..\..\..\Windows\SignInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bSignIn;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\Windows\SignInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bSignUp;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Windows\SignInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tblogin;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\Windows\SignInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPassword;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\Windows\SignInWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lableLoginError;
        
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
            System.Uri resourceLocater = new System.Uri("/ChatClient;component/windows/signinwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\SignInWindow.xaml"
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
            this.bSignIn = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\Windows\SignInWindow.xaml"
            this.bSignIn.Click += new System.Windows.RoutedEventHandler(this.Button_Click_SignIn);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bSignUp = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\..\Windows\SignInWindow.xaml"
            this.bSignUp.Click += new System.Windows.RoutedEventHandler(this.Button_Click_SignUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tblogin = ((System.Windows.Controls.TextBox)(target));
            
            #line 122 "..\..\..\Windows\SignInWindow.xaml"
            this.tblogin.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RemoveTextLogin);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 123 "..\..\..\Windows\SignInWindow.xaml"
            this.tbPassword.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RemoveTextPassword);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lableLoginError = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

