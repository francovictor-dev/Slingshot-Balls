using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConquestManager : MonoBehaviour
{
    public DataBase bd;

    private GerarBolas gameOver;

    private GameObject paredes;
    private int[] conquista;

    private bool ativo;
    void Start()
    {
        paredes = GameObject.Find("BackgroundManager").GetComponent<BackgroundManager>().Background();
        conquista = new int[20];
        conquista[0] = 0;

        //localizar e adquirir o script de GerarBolas
        gameOver = GameObject.Find("Main Camera").GetComponent<GerarBolas>();
    }

    void Update()
    {

        //print(conquista[5]);
        if (gameOver.GetGameOver())
        {
            //toda vez que der gameover o valor dos requisitos no banco de dados são atualizados
            if (ativo)
            {    
                //2000 pontos
                bd.UpdateBd("Conquista", "valor", ValorConquista(1).ToString(), "id", "1");
                //100 colisões na parede
                bd.UpdateBd("Conquista", "valor", ValorConquista(2).ToString(), "id", "2");
                //100 bolas brancas
                bd.UpdateBd("Conquista", "valor", ValorConquista(3).ToString(), "id", "3");
                //100 bolas azuis
                bd.UpdateBd("Conquista", "valor", ValorConquista(4).ToString(), "id", "4");
                //20000 pontos
                bd.UpdateBd("Conquista", "valor", ValorConquista(5).ToString(), "id", "5");
                //100 vezes com bonus 20x
                bd.UpdateBd("Conquista", "valor", ValorConquista(6).ToString(), "id", "6");
                //2000 em uma rodada
                bd.UpdateBd("Conquista", "valor", ValorConquista(7).ToString(), "id", "7");
                //100 bolas vermelhas
                bd.UpdateBd("Conquista", "valor", ValorConquista(8).ToString(), "id", "8");
                //bolas amarelas
                bd.UpdateBd("Conquista", "valor", ValorConquista(9).ToString(), "id", "9");
                //bolas verdes
                bd.UpdateBd("Conquista", "valor", ValorConquista(10).ToString(), "id", "10");
                //bolas rosas
                bd.UpdateBd("Conquista", "valor", ValorConquista(11).ToString(), "id", "11");
                //bolas laranjas
                bd.UpdateBd("Conquista", "valor", ValorConquista(12).ToString(), "id", "12");
                //bolas pretas
                bd.UpdateBd("Conquista", "valor", ValorConquista(13).ToString(), "id", "13");
                //50 skyrocket
                bd.UpdateBd("Conquista", "valor", ValorConquista(14).ToString(), "id", "14");
                ativo = false;
            }
        }
        else
        { 
            ativo = true;
        }

    }

    private int ValorConquista(int id)
    {
        //buscando no banco de dados os valores atuais e os requisitos da conquista
        int requisito = bd.QueryInt("requisito", "Conquista", "id", id.ToString());
        int valor = bd.QueryInt("valor", "Conquista", "id", id.ToString());

        if(valor < requisito)
        {
            valor += conquista[id - 1];
            //se na soma total dos pontos do valor for maior que o requisito da conquista ele
            //recebera o valor total que é do requisito para não ultrapassar deste limite
            if(valor > requisito)
            {
                valor = requisito;
            }
        }
        else
        {
            valor = requisito;
        }
        //variavel publico de conquista vai zerar para poder ser utilizado novamente 
        conquista[id-1] = 0;
        return valor;
    } 

    //método publico para receber valores nas atividades 
    public void SetValorConquista(int i, int valor)
    {
        conquista[i-1] += valor;
    }


}
