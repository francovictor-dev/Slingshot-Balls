using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    private Text bonus;
    private Text pontuacao;

    private int ptBola;
    //private int ptBonus;

    //private bool colisao;

    //variavel que vai receber o bonus necessario para o calculo de Vida
    private LifeMecanism lifeCalc;
    // Start is called before the first frame update
    void Start()
    {
        //puxando script de LifeMecanism
        lifeCalc = GameObject.Find("LifeMecanism").GetComponent<LifeMecanism>();
        //ptBola recebe valor da variavel #pontos da bola atual
        ptBola = GetComponent<BolaPontuacao>().pontos;
        //pontuacao.text = pontuacao.GetComponent<TotalPontos>().totalPontos.ToString();
        pontuacao = GameObject.Find("Canvas/Pontos").GetComponent<Text>();
        bonus = GameObject.Find("Canvas/Bonus").GetComponent<Text>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Limite" && coll.gameObject.tag != "Lateral" && coll.gameObject.tag != "Teto" && coll.gameObject.tag != "Coracao" && coll.gameObject.tag != "SkyRocket")
        {
           
            //SetColisao adiciona 1 na quantidade total de colisoes terao no script Shake
            GameObject.Find("Main Camera").GetComponent<Shake>().SetColisao(1);

            //ptColl = coll.gameObject.GetComponent<BolaPontuacao>().pontos;

            pontuacao.GetComponent<TotalPontos>().AddPtBola(ptBola);

            //pontuacao.text = pontuacao.GetComponent<TotalPontos>().totalPontos.ToString();

            GameObject.Find("Canvas/PontosGanhos").GetComponent<PontosGanhos>().VerificarColisao(true);

            //quando tiver colisao entre bolas será ativado variavel de colisao fazendo com que o bonus se extender
            GameObject.Find("Canvas/Bonus").GetComponent<Bonus>().SetColisaoBolas(true);

            //quando tiver colisao entre bolas será ativado variavel de colisao na classe BehaviorTouch
            GameObject.Find("TouchManager").GetComponent<BehaviorTouch>().ColisaoBolas(true);

        } else if (coll.gameObject.tag == "Lateral")
        {
            bonus.GetComponent<Bonus>().AddPtBonus(2);
            lifeCalc.SetPtsColisaoParede(1);
        }
       

    }

}
