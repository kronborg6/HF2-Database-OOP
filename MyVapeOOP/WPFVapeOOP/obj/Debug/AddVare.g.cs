#pragma checksum "..\..\AddVare.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F8A2AAA21D41A33BBC0C27008DD449E81075CBEDB7BAEC7F4632450444B76367"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WPFVapeOOP;


namespace WPFVapeOOP {
    
    
    /// <summary>
    /// AddVare
    /// </summary>
    public partial class AddVare : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\AddVare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox INavn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AddVare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IPrise;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AddVare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IAntal;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AddVare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IFirmaID;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFVapeOOP;component/addvare.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddVare.xaml"
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
            this.INavn = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.IPrise = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.IAntal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.IFirmaID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 35 "..\..\AddVare.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Tilbage);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 36 "..\..\AddVare.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_AddVare);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

