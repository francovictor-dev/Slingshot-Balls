using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdmobGamePlay : MonoBehaviour
{
    private Text vidas;
    public Text pontos;
    public Text botaoSim;
    public Text botaoNao;
    public Text textoJanela;
    public GameObject janelaAd;
    public GameObject janelaAdReward;

    int valor;
    bool mostrarJanela = false;
    public static bool confirmarClick = false;
    public static int valorPublico;
    public static bool extraVida = false;

    // Start is called before the first frame update
    void Awake()
    {
   
    }

    void Start()
    {
        vidas = GameObject.Find("Canvas/Vida/Quant").GetComponent<Text>();
        AdmobManager.instance.Time = 1200f;
        
    }

    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //banner
        if(vidas.text == "0"){
            
            if (AdmobManager.instance.Time == 1200f)
            {
                AdmobManager.instance.RequestBanner(5f);
                AdmobManager.instance.Time = 600;
            }
            AdmobManager.instance.Time++;
        }

        //interstitial
        if (AdmobManager.instance.GameOver == 2)
        {
            if (mostrarJanela)
            {
                //AdmobManager.instance.RequestInterstitial();
                //AdmobManager.instance.ShowPopUp();
                janelaAd.SetActive(true);
                mostrarJanela = false;
            }
            else
            {
                //AdmobManager.instance.RequestInterstitial();
                AdmobManager.instance.ShowPopUp();
                //janelaAd.SetActive(true);
                mostrarJanela = true;
            }
            AdmobManager.instance.GameOver = 0;
            
        }

        //Ad Video Reward
        if (extraVida)
        {
            //AdmobManager.instance.RequestInterstitial();
            //AdmobManager.instance.ShowPopUp(); 
            //janelaAd.SetActive(true);
            janelaAdReward.SetActive(true);
            extraVida = false;
        }
    }
}
