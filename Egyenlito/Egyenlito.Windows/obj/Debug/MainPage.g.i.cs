﻿

#pragma checksum "d:\SoftIT\EgyenlitoUniversal\Egyenlito\Egyenlito.Windows\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "312E2CFAAC1F2B2B1B2DA588EAE50954"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Egyenlito
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.HubSection Newspapers; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.HubSection AllArticles; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.HubSection Events; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Data.CollectionViewSource AllArticlesGrouped; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///MainPage.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            Newspapers = (global::Windows.UI.Xaml.Controls.HubSection)this.FindName("Newspapers");
            AllArticles = (global::Windows.UI.Xaml.Controls.HubSection)this.FindName("AllArticles");
            Events = (global::Windows.UI.Xaml.Controls.HubSection)this.FindName("Events");
            AllArticlesGrouped = (global::Windows.UI.Xaml.Data.CollectionViewSource)this.FindName("AllArticlesGrouped");
        }
    }
}



