﻿#pragma checksum "C:\Users\Nekozawa\Dropbox\Documents\Visual Studio 2015\Projects\Old\KunappWinApp(20150815)\cs\Views\BasicPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1DD59067EB2F0DF85779CB52C8C29C4D"
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
    partial class BasicPage : 
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
                    this.navigatorImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 2:
                {
                    this.navigatorComment = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Grid element3 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 32 "..\..\..\Views\BasicPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)element3).Tapped += this.Grid_OnTapped0;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Grid element4 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 44 "..\..\..\Views\BasicPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)element4).Tapped += this.Grid_OnTapped1;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.Grid element5 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 51 "..\..\..\Views\BasicPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)element5).Tapped += this.Grid_OnTapped3;
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

