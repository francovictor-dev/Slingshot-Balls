using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalPontos : MonoBehaviour
{
    public LifeMecanism calculoVida;
    //fila para pegar valores dos pontos das bolas em contato
    private Queue<int> ptBola = new Queue<int>();

    private int totalPontos;
    private int ptBonus;
    private int resultado; 

    private Text pontuacaoText;

    //variavel para manipular script de conquista
    private ConquestManager conqManager;

    // Start is called before the first frame update
    void Start()
    {
        totalPontos = 0;
        resultado = 0;
        //buscando o objeto de Text onde mostrará a pontuacao
        //pontuacaoText = GameObject.Find("Canvas/Pontos").GetComponent<Text>();
        pontuacaoText = GetComponent<Text>();

        //localizar e adquirir o script de conquista
        conqManager = GameObject.Find("ConquestManager").GetComponent<ConquestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //se a fila chegar em 2 instancias ele multiplicará as duas variaveis dentro da fila e logo depois
        //resetará a fila
        if(ptBola.Count == 2)
        {
            ptBonus = GameObject.Find("Canvas/Bonus").GetComponent<Bonus>().GetPtBonus();
            //totalPontos += ptBola.ToArray()[0] * (ptBola.ToArray()[1] + ptBonus);

            //recebe nos parametros os pontos das bolas colididos
            CalcularResultado(ptBola.ToArray()[0], ptBola.ToArray()[1], ptBonus);

            //deletando as variaveis na array
            ptBola.Dequeue();
            ptBola.Dequeue();
            
            //recebe o calculo total dos pontos adiquiridos na colisão
            totalPontos += MostrarResultado();

            //conquista 1
            conqManager.SetValorConquista(1, MostrarResultado());
            //conquista 5
            conqManager.SetValorConquista(5, MostrarResultado());
           
            calculoVida.SetPtsColisaoBola(1);
            
            //conquista 6
            if (ptBonus == 20)
            { 
                conqManager.SetValorConquista(6, 1);
            } 
        }
        else if(ptBola.Count == 3)
        {
            ptBonus = GameObject.Find("Canvas/Bonus").GetComponent<Bonus>().GetPtBonus();
            //totalPontos += ptBola.ToArray()[0] * (ptBola.ToArray()[1] + ptBonus);

            //recebe nos parametros os pontos das bolas colididos
            CalcularResultado(ptBola.ToArray()[0], ptBola.ToArray()[1], ptBola.ToArray()[2], ptBonus);

            //deletando as variaveis na array
            ptBola.Dequeue();
            ptBola.Dequeue();
            ptBola.Dequeue();

            //recebe o calculo total dos pontos adiquiridos na colisão
            totalPontos += MostrarResultado();

            //conquista 1
            conqManager.SetValorConquista(1, MostrarResultado());
            //conquista 5
            conqManager.SetValorConquista(5, MostrarResultado());

            calculoVida.SetPtsColisaoBola(1);

            //conquista 6
            if (ptBonus == 20)
            {
                conqManager.SetValorConquista(6, 1);
            }
        }
        else if (ptBola.Count == 4)
        {
            ptBonus = GameObject.Find("Canvas/Bonus").GetComponent<Bonus>().GetPtBonus();
            //totalPontos += ptBola.ToArray()[0] * (ptBola.ToArray()[1] + ptBonus);

            //recebe nos parametros os pontos das bolas colididos
            CalcularResultado(ptBola.ToArray()[0], ptBola.ToArray()[1], ptBola.ToArray()[2], ptBola.ToArray()[3], ptBonus);

            //deletando as variaveis na array
            ptBola.Dequeue();
            ptBola.Dequeue();
            ptBola.Dequeue();
            ptBola.Dequeue();

            //recebe o calculo total dos pontos adiquiridos na colisão
            totalPontos += MostrarResultado();

            //conquista 1
            conqManager.SetValorConquista(1, MostrarResultado());
            //conquista 5
            conqManager.SetValorConquista(5, MostrarResultado());

            calculoVida.SetPtsColisaoBola(1);

            //conquista 6
            if (ptBonus == 20)
            {
                conqManager.SetValorConquista(6, 1);
            }
        }

        //totalPontos será convertido em Strings para poder ser mostrado na tela
        pontuacaoText.text = totalPontos.ToString();
        //conquista 7
        if(totalPontos >= 3000)
        {
            conqManager.SetValorConquista(7, 1);
        }
    }

    public void AddPtBola(int pt)
    {
        ptBola.Enqueue(pt);
    }

    private void CalcularResultado(int num1, int num2, int bonus)
    {
        resultado = num1 * (num2 + bonus);
    }

    private void CalcularResultado(int num1, int num2, int num3, int bonus)
    {
        resultado = num1 * (num2 + num3 + bonus);
    }

    private void CalcularResultado(int num1, int num2, int num3, int num4, int bonus)
    {
        resultado = num1 * (num2 + num3 + num4 + bonus);
    }

    public int MostrarResultado()
    {
        return resultado;
    }

    public int MostrarPontos()
    {
        return totalPontos;
    }

    public void ResetarPontos()
    {
        totalPontos = 0;
    }

    public void SkyRocketPoints(int points)
    {
        this.totalPontos += points;
        conqManager.SetValorConquista(14, 1);
    }

    public void AdInterstitialPoint(int points)
    {
        this.totalPontos += points;
    }
}
