using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XFAzureMapTrial.UWP.CustomRenderers;

[assembly: ExportRenderer(typeof(Xamarin.Forms.WebView), typeof(CustomWebViewRenderer))]
namespace XFAzureMapTrial.UWP.CustomRenderers
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null || Control == null)
                return;

            Windows.UI.Xaml.Controls.WebView webView = new Windows.UI.Xaml.Controls.WebView(WebViewExecutionMode.SeparateProcess);
            webView.Source = Control.Source;
            SetNativeControl(webView);
        }
    }
}