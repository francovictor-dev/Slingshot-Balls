using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class BDPontos : MonoBehaviour
{
    public DataBase bd;
    public TotalPontos totalPontos;
    int somaPontos;

    // Start is called before the first frame update
    void Start()
    {
        somaPontos = 0;
    }

    void OnEnable()
    {
        somaPontos = bd.QueryInt("pontos") +  totalPontos.MostrarPontos();
        bd.UpdateBd(somaPontos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
