﻿#pragma checksum "C:\Users\Nekozawa\Documents\Visual Studio 2015\Projects\KunappWinApp\cs\Views\CommandBarPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "49416DB288DD99BFE1F2FFE9E106DA2D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NavigationMenuSample.Views
{
    partial class CommandBarPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.webView = (global::Windows.UI.Xaml.Controls.WebView)(target);
                }
                break;
            case 2:
                {
                    this.ItemListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 108 "..\..\..\Views\CommandBarPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ItemListView).SelectionChanged += this.ItemListView_SelectionChanged;
                    #line default
                }
                break;
            case 3:
                {
                    this.buttonOpenViaExtWBrowser = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 93 "..\..\..\Views\CommandBarPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.buttonOpenViaExtWBrowser).Click += this.buttonOpenViaExtWBrowser_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.textBlockTargetFeed = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.feedButton1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 49 "..\..\..\Views\CommandBarPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.feedButton1).Click += this.feedButton1_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.feedButton2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 54 "..\..\..\Views\CommandBarPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.feedButton2).Click += this.feedButton2_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.feedButton3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 59 "..\..\..\Views\CommandBarPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.feedButton3).Click += this.feedButton3_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.feedButton4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 64 "..\..\..\Views\CommandBarPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.feedButton4).Click += this.feedButton4_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

