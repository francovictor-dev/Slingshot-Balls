using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraTempo : MonoBehaviour
{
    //barra de fundo
    public Unity.VectorGraphics.SVGImage barraBack;
    //barra de preenchimento
    public Unity.VectorGraphics.SVGImage barraFill;
    private bool bonusStart;
    private int timer;
    private int timerMax;

    // Start is called before the first frame update
    void Start()
    {
        //começa inativo
        barraFill.enabled = false;
        barraBack.enabled = false;
        timer = 0;
        timerMax = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        BeginEndBonus();
        TempoAtual();
        CorBarra();
    }

    //método para fazer a barra de tempo aparecer na tela quando o bonus se iniciar
    private void BeginEndBonus()
    {

        //busca método no script Bonus para mostrar tempo de bonus
        bonusStart = GameObject.Find("Canvas/Bonus").GetComponent<Bonus>().GetStartTime();
        //se o bonus se inicia a barra aparece na tela
        if (bonusStart == true)
        {
            barraFill.enabled = true;
            //barraBack.enabled = true;
        }
        else
        {
            barraFill.enabled = false;
            //barraBack.enabled = false;
        }
    }

    //método faz com que a barra de tempo termine quando o tempo de bonus acabe
    private void TempoAtual()
    {

        float perc;
        timer = GameObject.Find("Canvas/Bonus").GetComponent<Bonus>().GetTimer();
        //colocar GetTimerMax e colocar nessa variavel
        timerMax = GameObject.Find("Canvas/Bonus").GetComponent<Bonus>().GetTimerMax();
        if(bonusStart == true)
        {
            //calculo para pegar o percentual cujo o principal é do tempo do bonus
            perc = 100 * timer / timerMax;

            //convertendo o percenctual do tempo com o tamanho da barra de tempo
            barraFill.rectTransform.sizeDelta = new Vector2(200 - (200 * perc / 100), 44);
        }
       
    }

    //método que muda a barra de tempo
    void CorBarra()
    {
        float perc;
        if (bonusStart == true)
        {
            //colocar GetTimerMax e colocar nessa variavel
            timerMax = GameObject.Find("Canvas/Bonus").GetComponent<Bonus>().GetTimerMax();
            //calculo para pegar o percentual cujo o principal é do tempo do bonus
            perc = 100 * timer / timerMax;
            //convertendo o percentual do tempo na cor da barra
            barraFill.GetComponent<Unity.VectorGraphics.SVGImage>().color = new Color(
                1f,
                1f - (1f * perc / 100),
                0,
                1f);
        }
    }
}
