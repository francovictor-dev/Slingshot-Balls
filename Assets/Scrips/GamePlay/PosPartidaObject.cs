using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosPartidaObject : MonoBehaviour
{
    public Text pontosTxt;
    public Text pontosBdTxt;
    public DataBase bd;
    public TotalPontos totalPontos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        //mostra os pontos finais
        pontosTxt.text = totalPontos.MostrarPontos().ToString();
        pontosBdTxt.text = bd.QueryInt("pontos").ToString();
    }

}
