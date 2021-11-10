using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Vidas : MonoBehaviour
{
    public GameObject vida;
    public ParticleSystem explosao;
    private Text vidaText;
    private AudioSource somColisao;
    private AudioSource somExplosao;
    private GerarBolas gameOver;
    private int duracaoVida;
    // Start is called before the first frame update
    void Start()
    {
        vidaText = GameObject.Find("Canvas/Vida/Quant").GetComponent<Text>();
        gameOver = GameObject.Find("Main Camera").GetComponent<GerarBolas>();
        somExplosao = GameObject.Find("SoundsManager/CoracaoExplosao").GetComponent<AudioSource>();
        somColisao = GameObject.Find("SoundsManager/CoracaoColisao").GetComponent<AudioSource>();

        duracaoVida = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.GetGameOver())
        {
            Destroy(vida);
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Contains("Bola"))
        {
            duracaoVida -= 1;
            //se.clip = Resources.Load<AudioClip>("FxSong/FxSong01");
            if(duracaoVida != 0)
            {
                somColisao.Play();
            }
            else
            {
                somExplosao.Play();
                Instantiate(explosao, transform.position, transform.rotation);
                Destroy(vida);
                vidaText.text = (Int32.Parse(vidaText.text) + 1).ToString();
            }
            
        }
        if (coll.gameObject.tag == "Limite")
        {
            Destroy(vida);
        }
    }
}
