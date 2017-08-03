using UnityEngine;
using System.Collections;

#if EASY_MOBILE
using EasyMobile;
#endif

namespace SgLib
{
    public class ScreenshotSharer : MonoBehaviour
    {
        [Header("Sharing Config")]
        [Tooltip("Any instances of [score] will be replaced by the actual score achieved in the last game")]
        [TextArea(3, 3)]
        public string shareMessage = "Awesome! I've just scored [score] in Bridges! #bridges";
        public string screenshotFilename = "screenshot.png";

        #if EASY_MOBILE
        public static ScreenshotSharer Instance { get; private set; }

        Texture2D capturedScreenshot;

        // On Android, we use a RenderTexture to take screenshot for better performance.
        #if UNITY_ANDROID
        RenderTexture screenshotRT;    
        #endif

        GameManager gameManager;

        void OnEnable()
        {
            PlayerController.PlayerFall += PlayerController_PlayerFall;
        }

        void OnDisable()
        {
            PlayerController.PlayerFall -= PlayerController_PlayerFall;
        }

        void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        void Start()
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();

            #if UNITY_ANDROID
            screenshotRT = new RenderTexture(Screen.width, Screen.width, 24);
            #endif
        }

        void PlayerController_PlayerFall()
        {
            if (gameManager.enablePremiumFeatures)
            {
                StartCoroutine(CRCaptureScreenshot());
            }
        }

        IEnumerator CRCaptureScreenshot()
        {
            // Wait for right timing to take screenshot
            yield return new WaitForEndOfFrame();

            #if UNITY_ANDROID
            if (screenshotRT != null)
            {
                // Temporarily render the camera content to our screenshotRenderTexture.
                // Later we'll share the screenshot from this rendertexture.
                Camera.main.targetTexture = screenshotRT;
                Camera.main.Render();
                yield return null;
                Camera.main.targetTexture = null;
                yield return null;

                // Read the rendertexture contents
                RenderTexture.active = screenshotRT;

                capturedScreenshot = new Texture2D(screenshotRT.width, screenshotRT.height, TextureFormat.RGB24, false);
                capturedScreenshot.ReadPixels(new Rect(0, 0, screenshotRT.width, screenshotRT.height), 0, 0);
                capturedScreenshot.Apply();

                RenderTexture.active = null;
            }
            #else
            capturedScreenshot = MobileNativeShare.CaptureScreenshot();
            #endif
        }

        public Texture2D GetScreenshotTexture()
        {
            return capturedScreenshot;
        }

        public void ShareScreenshot()
        {
            if (capturedScreenshot == null)
            {
                Debug.Log("ShareScreenshot: FAIL. No captured screenshot.");
                return;
            } 

            string msg = shareMessage;
            msg = msg.Replace("[score]", ScoreManager.Instance.Score.ToString());
            MobileNativeShare.ShareTexture2D(capturedScreenshot, screenshotFilename, msg);
        }

        #endif
    }
}
