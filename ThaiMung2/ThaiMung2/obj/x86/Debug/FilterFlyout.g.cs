﻿

#pragma checksum "C:\Users\parat_000\Documents\Visual Studio 2012\Projects\ThaiMung2\ThaiMung2\FilterFlyout.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DACA21554ADA15FBF71A13C879059B99"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThaiMung2
{
    partial class FilterFlyout : global::Windows.UI.Xaml.Controls.UserControl, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 12 "..\..\..\FilterFlyout.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Popup)(target)).Closed += this.OnPopupClosed;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 42 "..\..\..\FilterFlyout.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.yesButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 43 "..\..\..\FilterFlyout.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.cancelButton_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

