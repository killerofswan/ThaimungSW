﻿

#pragma checksum "C:\Users\parat_000\Downloads\ThaimungSW-master (1)\ThaimungSW-master\ThaiMung2\ThaiMung2\OwnerEvent.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "70C716C4D3C91AEBC0E86D4988ED8309"
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
    partial class OwnerEvent : global::ThaiMung2.Common.LayoutAwarePage, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 23 "..\..\..\OwnerEvent.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.deleteButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 24 "..\..\..\OwnerEvent.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.editButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 48 "..\..\..\OwnerEvent.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


