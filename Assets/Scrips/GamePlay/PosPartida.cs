using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PosPartida : MonoBehaviour
{
    public GameObject painel;
    public GerarBolas gb;
    public TotalPontos totalPontos;
    public Text vidas;
    public Text pontos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Quando tiver gameOver o painel será exibido
        if (gb.GetGameOver())
        {
            if (BDManager.evento)
            {
                ExibirPainel(false);
            }
            else
            {
                ExibirPainel(true);
            }
            

            if (AdmobManager.rewardConcluido)
            {
                ExibirPainel(false);
                pontos.text = totalPontos.MostrarPontos().ToString();
                vidas.text = "1";
                AdmobManager.rewardConcluido = false;
                BDManager.evento = false;
                gb.Restart();
            }

        }
        else
        {
            if (AdmobGamePlay.confirmarClick)
            {
                //print(AdmobGamePlay.valorPublico);
                //totalPontos += AdmobGamePlay.valorPublico;
                //pontos.text = AdmobGamePlay.valorPublico.ToString();
                totalPontos.AdInterstitialPoint(AdmobGamePlay.valorPublico);
                AdmobGamePlay.confirmarClick = false;
            }
        }
        
    }


    public void ExibirPainel(bool exibir)
    {
        painel.SetActive(exibir);
    }

    public void JogarNovamente()
    {
        gb.Restart();
        totalPontos.ResetarPontos();
        //bonus adicional de pontos caso tenha click no anúncio
        vidas.text = "1";
        ExibirPainel(false);
    }

    public void SairGamePlay(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
