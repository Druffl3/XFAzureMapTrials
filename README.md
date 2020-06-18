# XFAzureMapTrials
Azure Maps recently announced a 'Create' feature where custom maps can be loaded for implementing functionalities like indoor navigation, occupancy and such. To use this feature in an application requires Azure Maps SDK, which hasn't been provided to Xamarin.Forms yet. It might even take an year from the time of writing this for a Xamarin.Forms support as stated here: https://github.com/MicrosoftDocs/azure-docs/issues/56691#issuecomment-643448608 .

An alternative solution would be to embed the Web implmentation in a WebView as suggested in the link above.

Android
<img src="https://github.com/Druffl3/XFAzureMapTrials/blob/master/Screenshots/androidAzureIndoorMap.png" width="200" height="400" />

iOS
<img src="https://github.com/Druffl3/XFAzureMapTrials/blob/master/Screenshots/iOSAzureIndoorMap.png" width="200" height="400" />

UWP
<img src="https://github.com/Druffl3/XFAzureMapTrials/blob/master/Screenshots/uwpAzureIndoorMap.PNG" width="400" height="400" />

Before building this project follow through their documentation: https://docs.microsoft.com/en-us/azure/azure-maps/tutorial-creator-indoor-maps#prerequisites and have your prerequisites listed below ready.

Prerequisites:
1. Azure Subscription Key (For the web app)
2. A map package converted to a Dataset (For the web app)
3. TileSet ID from the Dataset (For the web app) 
4. Feature StateSet ID from the Dataset (For the web app)
5. OPTIONAL: Google(Android) and Bing Maps(UWP), API key if you want to use Azure Maps REST APIs

Once you have the above requirements, perform the following steps:

1. If you want to use Azure Maps REST APIs with Xamarin.Forms.Map then-
   In AndroidManifest.xml add your Google Maps API key in 
   <code>&lt;meta-data android:name="com.google.android.maps.v2.API_KEY" android:value="Your_API_Key"/&gt;</code>
   If you don't want to use Xamarin.Forms.Map, then simply remove this tag from the manifest.
   
   In UWP add your Bing Maps API key in MainPage.xaml.cs inside XFAzureMapTrial.UWP project
   <code>Xamarin.FormsMaps.Init("Your_API_Key");</code>
   If you don't want to use Xamarin.Forms.Map then do not initialise FormsMaps and remove the render assemblies from App.Xaml.cs instead initializing Forms like this
   <code>Xamarin.Forms.Forms.Init(e);</code>
 
 2. Open index.html present in IndoorMapWeb folder and add your subscription key and IDs
    <code>
    const subscriptionKey = "From Prerequisite 1";
    const tilesetId = "From Prerequisite 3";
    const statesetId = "From Prerequisite 4";
    </code>
    
    Open index.html in any of your preferred browser to verify if the map is loading as expected.
  
  3. Host the files in IndoorMapWeb folder in any hosting service of your choice. I used static website available in Azure Portal. Watch this quick tutorial if you want to know how https://www.youtube.com/watch?v=gYpNC_tdbQQ
  
  4. In XFAzureMapTrial/AppConstants.cs, add your Azure subscription key and endpoint of your hosted IndoorMapWeb from step 3.
     <code>
     public static string SubscriptionKey { get; } = "From Prerequisite 1";
     public static string EndPoint { get; } = "Primary Endpoint of hosted IndoorMapWeb";
     </code>
  
  5. Build and run.
  
  
  NOTE:
  Since the .js files used in the IndoorMapWeb sample uses WebGL components, the WebView might not render index.html in certain Android devices. According to this document https://developer.chrome.com/multidevice/webview/overview, WebGL support is available from chromium v36 and above. You can update the same on your android device. 
  This answer https://stackoverflow.com/questions/30844557/supporting-webgl-on-android-5s-webview/30916299#30916299, informs on how to check if the device gpu is blocked by the browser and suggested workaround using CrossWalk.
