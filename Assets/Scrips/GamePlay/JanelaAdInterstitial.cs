using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JanelaAdInterstitial : MonoBehaviour
{
    public Idioma idioma;
    public TextMeshProUGUI textoJanela;
    public Text botaoSim;
    public Text botaoNao;

    int valor;
    
    // Start is called before the first frame update
    void Awake()
    {
        valor = 100;
    }

    private void OnEnable()
    {
        if (valor < 500)
        {
            valor += 100;
        }

        if(idioma.GetIdioma() == "Portuguese")
        {
            textoJanela.text = "Se clicar no anúncio a seguir você começará com bonus de pontos na próxima" +
            " rodada com valor de " + valor.ToString() + " pontos. Pretende prosseguir?";
            botaoNao.text = "Não";
            botaoSim.text = "Sim";
        }
        else if (idioma.GetIdioma() == "English")
        {
            textoJanela.text = "If you click on the ad below you will get bonus points next time" +
            " round with value of " + valor.ToString() + " points. Intends to proceed?";
            botaoNao.text = "No";
            botaoSim.text = "Yes";
        }
        else if (idioma.GetIdioma() == "Spanish")
        {
            textoJanela.text = "Si hace clic en el anuncio a continuación, obtendrá puntos de bonificación la próxima vez "+
            " ronda con valor de" + valor.ToString() + "puntos. ¿Desea continuar?";
            botaoNao.text = "No";
            botaoSim.text = "Sí";
        }

        
        //valor passado para a proxima rodada se aceitars
        AdmobGamePlay.valorPublico = valor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarPopUp()
    {
        //AdmobManager.instance.RequestInterstitial();
        AdmobManager.instance.ShowPopUp();
        this.gameObject.SetActive(false);
    }

    public void Sair()
    {
        this.gameObject.SetActive(false);
    }
}
