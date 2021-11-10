using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontosSkyRocket : MonoBehaviour
{
    public TextMesh texto;

    private Text pontos;
    private TotalPontos totalPontos;

    float tempo = 0f;
    List<Color> cor = new List<Color>();
    // Start is called before the first frame update
    void Start()
    {
        cor.Add(new Color32(255, 0, 0, 255));
        cor.Add(new Color32(255, 255, 0, 255));
        cor.Add(new Color32(255, 255, 255, 255));
        cor.Add(new Color32(0, 255, 0, 255));
        cor.Add(new Color32(0, 255, 255, 255));
        cor.Add(new Color32(0 , 0, 255, 255));

        totalPontos = GameObject.Find("Canvas/Pontos").GetComponent<TotalPontos>();

        pontos = GameObject.Find("Canvas/Pontos").GetComponent<Text>();

        //metodo para adicionar pontos no script de pontos totais
        totalPontos.SkyRocketPoints(500);

        //SetColisao adiciona 1 na quantidade total de colisoes terao no script Shake
        GameObject.Find("Main Camera").GetComponent<Shake>().SetColisao(2);
        //pontos.text = (totalPontos.MostrarPontos() + 500).ToString();
    }
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        tempo += Time.deltaTime;
        int rand = UnityEngine.Random.Range(0, cor.Count);

        texto.color = cor[rand];
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.003f);

        

        if (tempo > 2.3)
        {
            Destroy(this.gameObject);
        }
    }
}
