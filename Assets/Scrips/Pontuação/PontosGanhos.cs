using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontosGanhos : MonoBehaviour
{
    private Text pontosText;
    private int pontos;
    private float diferenca;
    private bool colisao;
    // Start is called before the first frame update
    void Start()
    {
        colisao = false;
        pontosText = GetComponent<Text>();
        pontosText.color = new Color(1, 0.7302845f, 0, 0);
        diferenca = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Transparencia();
        //busca o calculo geral no script TotalPontos para se apresentar como texto
        pontos = GameObject.Find("Canvas/Pontos").GetComponent<TotalPontos>().MostrarResultado();
        pontosText.text = "+" + pontos.ToString();
    }

    //método para o texto ficar transparente ao decorrer do tempo
    private void Transparencia()
    {
        //se a colisao for verdade então o valor no texto será apresentado
        if(colisao == true)
        {
            pontosText.color = new Color(1, 0.7302845f, 0, 1);
            diferenca = 0;
            colisao = false;
        }
        //depois do texto aparecer totalmente, a visibilidade do texto vai se perdendo até ficar totalmente transparente
        if(pontosText.color != new Color(1, 0.7302845f, 0, 0))
        {
            //variavel para medir o nivel de transparencia do texto
            diferenca += 0.005f;
            pontosText.color = new Color(1, 0.7302845f, 0, 1 - diferenca);
        }
        

    }

    //método para buscar o valor da colisao no script Pontuacao
    public void VerificarColisao(bool colisao)
    {
        this.colisao = colisao;
    }


}
