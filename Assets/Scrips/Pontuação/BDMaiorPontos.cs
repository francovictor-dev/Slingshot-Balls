using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class BDMaiorPontos : MonoBehaviour
{
    public GameObject novoRecordTxt;
    public TotalPontos totalPontos;
    public GerarBolas gameOver;
    private IDbConnection conn;
    private IDbCommand cmd;
    private IDataReader reader;
    //int novoMaiorPontos;
    int atualMaiorPontos;
    // Start is called before the first frame update
    void Awake()
    {
        Conexao();
        //PontuacaoMaiorAtual();
    }

    private void OnEnable()
    {
        PontuacaoMaiorAtual();
        if (atualMaiorPontos < totalPontos.MostrarPontos())
        {
            novoRecordTxt.gameObject.SetActive(true);
            cmd.CommandText = "UPDATE Player SET maior_pontos = " + totalPontos.MostrarPontos() + " WHERE id = 1;";
            cmd.ExecuteNonQuery();
            atualMaiorPontos = totalPontos.MostrarPontos();
        }
        else
        {
            novoRecordTxt.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.GetGameOver())
        {
            
        }
        else
        {
            
        }
    }

    void Conexao()
    {
        string path = "";
        if (Application.platform == RuntimePlatform.Android)
        {
            path = "URI=file:" + Application.persistentDataPath + "/SBDatabase.s3db"; 
        }
        else
        {
           path = "URI=file:" + Application.dataPath + "/StreamingAssets/SBDatabase.s3db"; 
        }
        conn = new SqliteConnection(path);
        cmd = conn.CreateCommand();
        conn.Open();
    }

    private void PontuacaoMaiorAtual()
    {
        cmd.CommandText = "SELECT maior_pontos FROM Player;";
        reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            atualMaiorPontos = reader.GetInt32(0);
        }
        reader.Close();
    } 
}
