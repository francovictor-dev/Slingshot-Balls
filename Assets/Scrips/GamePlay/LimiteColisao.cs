using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LimiteColisao : MonoBehaviour
{
    public GameObject particula;
    private AudioSource se;
    public Text vidas;
    public Text pontos;

    List<string> vidaExtra = new List<string>();

    int chave;
    // Start is called before the first frame update
    void Start()
    {
        //inicio da probabilidade da vida Extra
        vidaExtra.Add("nao");
        vidaExtra.Add("nao");
        vidaExtra.Add("nao");
        vidaExtra.Add("sim");
        //chave inicial de vida extra
        chave = 1;

        vidas = GameObject.Find("Canvas/Vida/Quant").GetComponent<Text>();
        pontos = GameObject.Find("Canvas/Pontos").GetComponent<Text>();

        se = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        int pontosint = Int32.Parse(pontos.text);

        if(vidas.text != "0")
        {
            if (pontosint >= 1500 && pontosint < 3000 && chave == 1)
            {
                vidaExtra.Add("sim");
                chave++;
            }
            else if (pontosint >= 3000 && pontosint < 4500 && chave == 2)
            {
                vidaExtra.Add("sim");
                chave++;
            }
            else if (pontosint >= 4500 && pontosint < 6000 && chave == 3)
            {
                vidaExtra.Add("sim");
                chave++;
            }
            else if (pontosint >= 6000 && pontosint < 7500 && chave == 4)
            {
                vidaExtra.Add("sim");
                chave++;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Contains("Bola"))
        {
            
            se.Play();
            Instantiate(
                particula,
                new Vector2(coll.transform.position.x, this.transform.position.y),
                Quaternion.identity
                );
            //admob system
            if (vidas.text == "0")
            {

                int res = UnityEngine.Random.Range(0, vidaExtra.Count);

                if(vidaExtra[res] == "sim")
                {
                    chave = 1;
                    vidaExtra.Clear();
                    vidaExtra.Add("nao");
                    vidaExtra.Add("nao");
                    vidaExtra.Add("nao");
                    vidaExtra.Add("sim");
                    AdmobGamePlay.extraVida = true;
                }
                else
                {
                    chave = 1;
                    vidaExtra.Clear();
                    vidaExtra.Add("nao");
                    vidaExtra.Add("nao");
                    vidaExtra.Add("nao");
                    vidaExtra.Add("sim");
                    AdmobManager.instance.GameOver++;
                }
                
                
            }

        }
        
    }
}
