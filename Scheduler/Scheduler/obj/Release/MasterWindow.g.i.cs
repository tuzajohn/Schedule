﻿#pragma checksum "..\..\MasterWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5E929CF78A0BBD4ED7866E1553C2C8E78F4A2010049B4A22BB2901B3C5516FB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Scheduler;
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


namespace Scheduler {
    
    
    /// <summary>
    /// MasterWindow
    /// </summary>
    public partial class MasterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TimerTick;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddUserBtn;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelAddUserBtn;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Chip AccountData;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HomeBtn;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AccountPageBtn;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DivisionPageBtn;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UserPageBtn;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WardPageBtn;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShiftPage;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignOutBtn;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\MasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame controlInstance;
        
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
            System.Uri resourceLocater = new System.Uri("/Scheduler;component/masterwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MasterWindow.xaml"
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
            
            #line 39 "..\..\MasterWindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SignOutBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TimerTick = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.AddUserBtn = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\MasterWindow.xaml"
            this.AddUserBtn.Click += new System.Windows.RoutedEventHandler(this.AddUserBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CancelAddUserBtn = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\MasterWindow.xaml"
            this.CancelAddUserBtn.Click += new System.Windows.RoutedEventHandler(this.CancelAddUserBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AccountData = ((MaterialDesignThemes.Wpf.Chip)(target));
            return;
            case 6:
            this.HomeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 122 "..\..\MasterWindow.xaml"
            this.HomeBtn.Click += new System.Windows.RoutedEventHandler(this.HomeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AccountPageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\MasterWindow.xaml"
            this.AccountPageBtn.Click += new System.Windows.RoutedEventHandler(this.AccountPageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DivisionPageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 144 "..\..\MasterWindow.xaml"
            this.DivisionPageBtn.Click += new System.Windows.RoutedEventHandler(this.DivisionPageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.UserPageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 154 "..\..\MasterWindow.xaml"
            this.UserPageBtn.Click += new System.Windows.RoutedEventHandler(this.UserPageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.WardPageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 165 "..\..\MasterWindow.xaml"
            this.WardPageBtn.Click += new System.Windows.RoutedEventHandler(this.WardPageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ShiftPage = ((System.Windows.Controls.Button)(target));
            
            #line 178 "..\..\MasterWindow.xaml"
            this.ShiftPage.Click += new System.Windows.RoutedEventHandler(this.ShiftPage_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.SignOutBtn = ((System.Windows.Controls.Button)(target));
            
            #line 190 "..\..\MasterWindow.xaml"
            this.SignOutBtn.Click += new System.Windows.RoutedEventHandler(this.SignOutBtn_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.controlInstance = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

