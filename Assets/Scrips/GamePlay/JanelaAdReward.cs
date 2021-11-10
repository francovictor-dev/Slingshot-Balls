using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JanelaAdReward : MonoBehaviour
{
    public Idioma idioma;
    public TextMeshProUGUI textoJanela;
    public Text botaoSim;
    public Text botaoNao;
    public Text vidaExtra;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    private void OnEnable()
    {
        BDManager.evento = true;
        if (idioma.GetIdioma() == "Portuguese")
        {
            textoJanela.text = "Conseguiu uma vida extra! Assista todo o vídeo de anúncio para continuar" +
            " na pontuação onde parou!";
            botaoNao.text = "Não";
            botaoSim.text = "Sim";
            vidaExtra.text = "<b>Vida Extra!</b>";
        }
        else if (idioma.GetIdioma() == "English")
        {
            textoJanela.text = "Got an extra life! Watch the entire ad video to continue" +
            " on the score where you left off!";
            botaoNao.text = "No";
            botaoSim.text = "Yes";
            vidaExtra.text = "<b>Extra Life!</b>";
        }
        else if (idioma.GetIdioma() == "Spanish")
        {
            textoJanela.text = "¡Tengo una vida extra! Mire el video del anuncio completo para continuar" +
            " en la partitura donde lo dejaste!";
            botaoNao.text = "No";
            botaoSim.text = "Sí";
            vidaExtra.text = "<b>¡Vida extra!!</b>";
        }
      
    }

    void Update()
    {
        BDManager.evento = true;
    }

    public void MostrarAd()
    {
        //AdmobManager.instance.RequestRewardAd();
        AdmobManager.instance.ShowRewardAd();
        this.gameObject.SetActive(false);
    }
    public void Fechar()
    {
        BDManager.evento = false;
        this.gameObject.SetActive(false);
        //adiciona um stack para o banner insterstitial
        //AdmobManager.instance.GameOver++;
    }
}
