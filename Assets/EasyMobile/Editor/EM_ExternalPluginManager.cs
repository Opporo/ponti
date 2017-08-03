using UnityEngine;
using UnityEditor;
using System.Collections;

namespace EasyMobile.Editor
{
    public static class EM_ExternalPluginManager
    {
        // AdMob
        public const string GoogleMobileAdsNameSpace = "GoogleMobileAds";

        // Chartboost
        public const string ChartboostNameSpace = "ChartboostSDK";
        public const string ChartboostClassName = "Chartboost";

        // Heyzap
        public const string HeyzapNameSpace = "Heyzap";

        // UnityIAP
        public const string UnityPurchasingAssemblyName = "UnityEngine.Purchasing";
        public const string UnityPurchasingNameSpace = "UnityEngine.Purchasing";
        public const string UnityPurchasingSecurityNameSpace = "UnityEngine.Purchasing.Security";
        public const string UnityPurchasingClassName = "UnityPurchasing";

        // Google Play Games
        public const string GPGSNameSpace = "GooglePlayGames";
        public const string GPGSClassName = "PlayGamesPlatform";

        // OneSignal
        public const string OneSignalClassName = "OneSignal";

        // 3rd party plugin packages
        public const string PackagesFolder = EM_Constants.RootPath + "/Packages";
        public const string GoogleMobileAdsPackagePath = PackagesFolder + "/GoogleMobileAds/GoogleMobileAds.unitypackage";
        public const string GooglePlayGamesPackagePath = PackagesFolder + "/GooglePlayGames/GooglePlayGames.unitypackage";
        public const string OneSignalPackagePath = PackagesFolder + "/OneSignal/OneSignal.unitypackage";

        // 3rd party plugin download URLs
        public const string ChartboostDownloadURL = "https://answers.chartboost.com/hc/en-us/articles/200780379";
        public const string HeyzapDownloadURL = "https://developers.heyzap.com/docs/unity_sdk_setup_and_requirements";

        /// <summary>
        /// Determines if AdMob plugin is available.
        /// </summary>
        /// <returns><c>true</c> if is ad mob avail; otherwise, <c>false</c>.</returns>
        public static bool IsAdMobAvail()
        {
            return EM_EditorUtil.NamespaceExists(GoogleMobileAdsNameSpace);
        }

        /// <summary>
        /// Determines if Chartboost plugin is available.
        /// </summary>
        /// <returns><c>true</c> if is chartboost avail; otherwise, <c>false</c>.</returns>
        public static bool IsChartboostAvail()
        {
            System.Type chartboost = EM_EditorUtil.FindClass(ChartboostClassName, ChartboostNameSpace);

            return chartboost != null;
        }

        public static bool IsHeyzapAvail()
        {
            return EM_EditorUtil.NamespaceExists(HeyzapNameSpace);
        }

        /// <summary>
        /// Determines if UnityIAP is enabled.
        /// </summary>
        /// <returns><c>true</c> if enabled; otherwise, <c>false</c>.</returns>
        public static bool IsUnityIAPAvail()
        {
//            System.Type purchasing = EM_EditorUtil.FindClass(UnityPurchasingClassName, UnityPurchasingNameSpace, UnityPurchasingAssemblyName);
//            return purchasing != null;

            // Here we check for the existence of the Security namespace instead of UnityPurchasing class in order to
            // make sure that the plugin is actually imported (rather than the service just being enabled).
            return EM_EditorUtil.NamespaceExists(UnityPurchasingSecurityNameSpace);
        }

        /// <summary>
        /// Determines if GooglePlayGames plugin is available.
        /// </summary>
        /// <returns><c>true</c> if is GPGS avail; otherwise, <c>false</c>.</returns>
        public static bool IsGPGSAvail()
        {
            System.Type gpgs = EM_EditorUtil.FindClass(GPGSClassName, GPGSNameSpace);

            return gpgs != null;
        }

        /// <summary>
        /// Determines if OneSignal plugin is available.
        /// </summary>
        /// <returns><c>true</c> if is one signal avail; otherwise, <c>false</c>.</returns>
        public static bool IsOneSignalAvail()
        {
            System.Type oneSignal = EM_EditorUtil.FindClass(OneSignalClassName);

            return oneSignal != null;
        }

        public static void ImportGoogleMobileAdsPlugin()
        {
            AssetDatabase.ImportPackage(GoogleMobileAdsPackagePath, true);
        }

        public static void ImportGooglePlayGamesPlugin()
        {
            AssetDatabase.ImportPackage(GooglePlayGamesPackagePath, true);
        }

        public static void ImportOneSignalPlugin()
        {
            AssetDatabase.ImportPackage(OneSignalPackagePath, true);
        }

        public static void DownloadChartboostPlugin()
        {
            Application.OpenURL(ChartboostDownloadURL);
        }

        public static void DownloadHeyzapPlugin()
        {
            Application.OpenURL(HeyzapDownloadURL);
        }
    }
}

