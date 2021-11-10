using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LojaPontos : MonoBehaviour
{
    public Text pontos;
    public DataBase bd;
    // Start is called before the first frame update
    void OnEnable()
    {
        pontos.text = bd.QueryInt("pontos").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        pontos.text = bd.QueryInt("pontos").ToString();
    }
}
