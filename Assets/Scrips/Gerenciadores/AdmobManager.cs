using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class AdmobManager : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardAd;

    public static AdmobManager instance;
    public static bool rewardConcluido = false;

    private float time = 600f;
    private int gameOver = 0;
    //private Text adText;
    //private Text adText2;
    //private Text adText3;
    public float Time
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
        }
    }

    public int GameOver
    {
        get
        {
            return gameOver;
        }
        set
        {
            gameOver = value;
        }
    }

  
    void Awake()
    {
        instance = this;
        /*
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        */
    }
    
    // Start is called before the first frame update
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
       
        //adText = GameObject.Find("Canvas/Ad").GetComponent<Text>();
        //adText2 = GameObject.Find("Canvas/Ad2").GetComponent<Text>();
        //adText3 = GameObject.Find("Canvas/Ad3").GetComponent<Text>();

        instance.RequestInterstitial();
        instance.RequestRewardAd();
    }

    public void RequestBanner(float seg)
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9086401416949729/2059601564";
        //string adUnitId = "ca-app-pub-3940256099942544/6300978111"; teste
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif
        //size adaptive para o banner
        AdSize adaptiveSize =
                AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        // Create a adaptiveSize banner at the bottom of the screen.
        instance.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);
        /*
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        */
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        
        // Load the banner with the request.
        instance.bannerView.LoadAd(request);
        //adText.text = request.ToString();
        //this.bannerView.Show();
        Invoke("DestroyBanner", seg);
    }

    public void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9086401416949729/2059601564";
        //string adUnitId = "ca-app-pub-3940256099942544/6300978111"; //teste
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif
        //size adaptive para o banner
        AdSize adaptiveSize =
                AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        // Create a adaptiveSize banner at the bottom of the screen.
        instance.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        instance.bannerView.LoadAd(request);

    }

    public BannerView MostrarObjetoBanner()
    {
        return instance.bannerView;
    }

    public void DestroyBanner()
    {
        instance.bannerView.Destroy();
    }

    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9086401416949729/8433438229";
        //string adUnitId = "ca-app-pub-3940256099942544/1033173712";// teste
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        instance.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        instance.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        instance.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        instance.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        instance.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        instance.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        instance.interstitial.LoadAd(request);

        //adText.text = request.ToString();

        //adText2.text = instance.interstitial.IsLoaded().ToString();
    }

    public void ShowPopUp()
    {
        if (instance.interstitial.IsLoaded())
        {
            //adText2.text = instance.interstitial.IsLoaded().ToString();
            instance.interstitial.Show();
        }
    }

    public void RequestRewardAd()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9086401416949729/6739926022";
        //string adUnitId = "ca-app-pub-3940256099942544/5224354917";// teste
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        instance.rewardAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        instance.rewardAd.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad is shown.
        instance.rewardAd.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        instance.rewardAd.OnAdClosed += HandleOnAdRewarded;


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        instance.rewardAd.LoadAd(request);
 
    }

    public void ShowRewardAd()
    {
        if (instance.rewardAd.IsLoaded())
        {
            //adText3.text = instance.rewardAd.IsLoaded().ToString();
            instance.rewardAd.Show();
        }
    }

    public void HandleOnAdLoaded(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");  
    }

    public void HandleOnAdClosed(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        instance.RequestInterstitial();
    }

    public void HandleOnAdLeavingApplication(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
        //fazer confirmar click quando clica no anuncio
        AdmobGamePlay.confirmarClick = true;
    }

    public void HandleOnAdRewarded(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("Recompensa feita!");
        rewardConcluido = true;
        instance.RequestRewardAd();
    }

    

}