﻿#pragma checksum "..\..\AuftragsnummerSuchenBearbeiten.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D277216D24336F949623F954EA7DF118C682E4E298F00D73726D6D62F2E25E28"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PichlerUndStroblDashbaord;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace PichlerUndStroblDashbaord {
    
    
    /// <summary>
    /// AuftragsnummerSuchenBearbeiten
    /// </summary>
    public partial class AuftragsnummerSuchenBearbeiten : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\AuftragsnummerSuchenBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAuftragsnummer;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AuftragsnummerSuchenBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSchließen;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\AuftragsnummerSuchenBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSuche;
        
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
            System.Uri resourceLocater = new System.Uri("/PichlerUndStroblDashbaord;component/auftragsnummersuchenbearbeiten.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AuftragsnummerSuchenBearbeiten.xaml"
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
            this.txtAuftragsnummer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btnSchließen = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\AuftragsnummerSuchenBearbeiten.xaml"
            this.btnSchließen.Click += new System.Windows.RoutedEventHandler(this.btnSchließen_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnSuche = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\AuftragsnummerSuchenBearbeiten.xaml"
            this.btnSuche.Click += new System.Windows.RoutedEventHandler(this.btnSuche_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

