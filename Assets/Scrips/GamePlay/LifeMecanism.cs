using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LifeMecanism : MonoBehaviour
{
    public GameObject vida;
    public Text vidaText;
    public GameObject barra;
    public GerarBolas gameOver;
    public TotalPontos pontos;

    private GameObject objCoracao;

    private float barraCalc;
    private RectTransform bar;
    // Start is called before the first frame update
    void Start()
    {
        barraCalc = 0f;

        bar = barra.GetComponent<RectTransform>();
        bar.localScale = new Vector3(barraCalc, 1, 1);    
    }

    // Update is called once per frame
    void Update()
    {
        if (barraCalc > 1.0f)
        {
            barraCalc = 0f;
            objCoracao = Instantiate(vida, new Vector2(UnityEngine.Random.Range(-2f, 2f), 6.5f), Quaternion.identity);
        }

        bar.transform.localScale = new Vector3(barraCalc, 1, 1);

        if (gameOver.GetGameOver())
        {
            barraCalc = 0;
        }
    }

    public void SetPtsColisaoBola(int x)
    {
        if(objCoracao != null)
        {
            //barraCalc = barraCalc + (Convert.ToSingle(x) / 50);
            //print(objCoracao);
        }
        else
        {
            barraCalc = barraCalc + (Convert.ToSingle(x) / 40);
            //print(objCoracao);
        }


    }

    public void SetPtsColisaoParede(int x)
    {
        if (objCoracao != null)
        {
            //barraCalc = barraCalc + (Convert.ToSingle(x) / 50);
            //print(objCoracao);
        }
        else
        {
            barraCalc = barraCalc + (Convert.ToSingle(x) / 40);
            //print(objCoracao);
        }
    }

}
