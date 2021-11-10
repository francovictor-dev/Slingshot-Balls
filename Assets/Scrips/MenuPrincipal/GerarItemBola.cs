using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerarItemBola : MonoBehaviour
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
        CriarItens("Bola");
    }

    void OnDisable()
    {
        //laço para destroir a variavel de referencia da lista de bolas
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
        //vetor com o tamanho da quantidade de registros de Bolas
        x = new int[bd.QueryInt("count(id)", tabela)];
        //variavel é usado para referenciar todos os objetos lista de bolas
        obj = new GameObject[x.Length];
        for (i = 0; i < x.Length; i++)
        {
            //index utilizado para a consulta bd
            int index = i + 1;
            //query para adiquirir o nome dos bolas
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

            GameObject sprite = (GameObject)GameObject.Instantiate
                (Resources.Load("Bola/" + query));

            obj[i].transform.Find("Imagem").GetComponent<Unity.VectorGraphics.SVGImage>().sprite = 
                sprite.GetComponent<SpriteRenderer>().sprite;
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
