using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerarItemMusica : MonoBehaviour
{
    public GameObject item;
    public DataBase bd;
    public Transform parent;

    private string query;
    GameObject[] obj;
    int[] x;
    int i;
    bool reseta = false;

    void OnEnable()
    {
        CriarItens("Musica");
    }

    void OnDisable()
    {
        //laço para destroir a variavel de referencia da lista de musicas
        for (int i = 0; i < obj.Length; i++)
        {
            Destroy(obj[i]);
        }

    }

    void Update()
    {
        if (reseta)
            AtualizarTabela();
    }

    private void CriarItens(string tabela)
    {
        //vetor com o tamanho da quantidade de registros de musicas
        x = new int[bd.QueryInt("count(id)", tabela)];
        //variavel é usado para referenciar todos os objetos lista de  Musicas
        obj = new GameObject[x.Length];
        for (i = 0; i < x.Length; i++)
        {
            //index utilizado para a consulta bd
            int index = i + 1;
            //query para adiquirir o nome dos musicas
            string query = bd.QueryString("nome", tabela, "id", index.ToString());
            //instanciando a lista a partir da consulta de bd
            obj[i] = Instantiate(item, parent);
            //colocando o nome do objeto
            obj[i].transform.Find("Nome").GetComponent<Text>().text = query;
            //item.transform.Find("Nome").GetComponent<Text>().text = query;
            if (bd.QueryInt("escolhido", tabela, "nome", query).ToString() == "1")
            {
                obj[i].transform.Find("BotaoSelecionar/Text").GetComponent<Text>().text = "ok";
            }
            else
            {
                obj[i].transform.Find("BotaoSelecionar/Text").GetComponent<Text>().text = "Escolher";
            }
        }
    }
    public void ResetarTabela(string nomeEscolhido, bool reseta)
    {
        this.query = nomeEscolhido;
        this.reseta = reseta;
    }

    private void AtualizarTabela()
    {
        for (i = 0; i < x.Length; i++)
        {
            if (obj[i].transform.Find("Nome").GetComponent<Text>().text == query)
            {
                obj[i].transform.Find("BotaoSelecionar/Text").GetComponent<Text>().text = "OK";
            }
            else
            {
                obj[i].transform.Find("BotaoSelecionar/Text").GetComponent<Text>().text = "Escolher";
            }
        }
        reseta = false;
    }
}
