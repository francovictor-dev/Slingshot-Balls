using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPontos : MonoBehaviour
{
    public DataBase bd;
    public Text pontos;
    public Text record;
    // Start is called before the first frame update
    void OnEnable()
    {
        pontos.text = bd.QueryInt("pontos", "Player").ToString();
        record.text = bd.QueryInt("maior_pontos", "Player").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
