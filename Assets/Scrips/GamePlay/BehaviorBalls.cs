using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using System.Drawing;
using System.IO;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BehaviorBalls : MonoBehaviour
{
    public GameObject explosao;
    //float distancia = 10;
    public Rigidbody2D bolaRB;
    //public GameObject meditorForca;
    public GameObject Puxador;
    public Transform puxadorPosicao;
    //public SpriteRenderer meditorImagem;
    public GameObject bola;

    public GameObject seta;
    //usado quando a bola for vermelha
    public GameObject seta2;

    private Vector2 touchPosicao;
    private Vector2 mousePosicaoInicial;

    private Vector2 offset;
    private Vector2 direcao;
    private Vector2 direcaoSeta;

    private SpriteRenderer setaCor;

    private int contador;

    private float timer1;
    private float timer2;

    private GerarBolas gameOver;
    private GameObject ballFx;
    private DataBase bd;
    //variavel para manipular script de conquista
    private ConquestManager conqManager;
    private BallManager bM;
    private Text vidas;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //quantidade de vidas 
        vidas = GameObject.Find("Canvas/Vida/Quant").GetComponent<Text>();

        //banco de dados
        bd = GameObject.Find("BDManager").GetComponent<DataBase>();
        
        //bola = GetComponent<GameObject>().gameObject;
  
        gameOver = GameObject.Find("Main Camera").GetComponent<GerarBolas>();
        //setaCor = seta.GetComponent<SpriteRenderer>();

        //desativando o Puxador no inicio
        Puxador.SetActive(false);
        //desativando a seta no inicio
        seta.SetActive(false);
        seta2.SetActive(false);

        contador = 0;
        timer1 = 0;
        timer2 = 0;

       

        //localizar e adquirir o script de conquista
        conqManager = GameObject.Find("ConquestManager").GetComponent<ConquestManager>();
        //localizar e adquirir o script de BallManager
        bM = GameObject.Find("BallsManager").GetComponent<BallManager>();

        //mudar sprite da bola
        GetComponent<SpriteRenderer>().sprite = bM.SpriteBall().GetComponent<SpriteRenderer>().sprite;
        //buscar particula fx da bola
        ballFx = (GameObject)GameObject.Instantiate(Resources.Load("Particula/" + NomeParticula()), 
            transform.position, Quaternion.identity, transform);
        //mudar cor da particula
        //var fx = BallFx().GetComponent<ParticleSystem>().main;
        ParticleSystem.MainModule fx = BallFx().GetComponent<ParticleSystem>().main;
        fx.startColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ComportamentoBolaVerde();
        ComportamentoBolaAmarela();
    }

    void Update()
    {

        gameOver = GameObject.Find("Main Camera").GetComponent<GerarBolas>();
        GameOver(gameOver.GetGameOver());
        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;
    }
    
    void GameOver(bool gameOver)
    {
        
        if (gameOver)
        {
            Destroy(bolaRB.gameObject);
            Destroy(GetComponent<Marcador>().MarcadorObject());
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        switch(coll.gameObject.tag){
            case "BolaBranca":
                Destroy(coll.gameObject);
             
                //vale 1 de conquista a cada colisao com esta bola
                conqManager.SetValorConquista(3, 1);//<---------problema
                //troca cor da explosao
                ParticleSystem.MainModule part1 = explosao.GetComponent<ParticleSystem>().main;
                part1.startColor = coll.gameObject.GetComponent<SpriteRenderer>().color;
              
                //explosao quando a bola for destruida
                Instantiate(explosao, coll.transform.position, coll.transform.rotation);

                if (bolaRB.gameObject.tag != "BolaAzul")
                {
                    Destroy(bolaRB.gameObject);
                    Destroy(GetComponent<Marcador>().MarcadorObject());
                    //troca cor da explosao
                    var part2 = explosao.GetComponent<ParticleSystem>().main;
                    part2.startColor = this.GetComponent<SpriteRenderer>().color;
                    //explosao quando a bola for destruida
                    Instantiate(explosao, this.transform.position, this.transform.rotation);

                }
                else
                {
                    contador += 1;
                    DestruirBolaAzul();
                }
                break;
            case "BolaAzul":
                if (bolaRB.gameObject.tag != "BolaAzul") 
                    Destroy(GetComponent<Marcador>().MarcadorObject());

                contador += 1;
                DestruirBolaAzul();
                break;
            case "BolaAmarela":
                Destroy(coll.gameObject);
               
                //vale 1 de conquista a cada colisao com esta bola
                conqManager.SetValorConquista(9, 1);
                //troca cor da explosao
                var part3 = explosao.GetComponent<ParticleSystem>().main;
                part3.startColor = coll.gameObject.GetComponent<SpriteRenderer>().color;
                //explosao quando a bola for destruida
                Instantiate(explosao, coll.transform.position, coll.transform.rotation);
                if (bolaRB.gameObject.tag != "BolaAzul")
                {
                    Destroy(bolaRB.gameObject);
                    Destroy(GetComponent<Marcador>().MarcadorObject());
                    //troca cor da explosao
                    var part4 = explosao.GetComponent<ParticleSystem>().main;
                    part4.startColor = this.GetComponent<SpriteRenderer>().color;
                    //explosao quando a bola for destruida
                    Instantiate(explosao, this.transform.position, this.transform.rotation);
                }
                else
                {
                    contador += 1;
                    DestruirBolaAzul();
                }
                break;
            case "BolaVermelha":
                Destroy(coll.gameObject);
                
                //vale 1 de conquista a cada colisao com esta bola
                conqManager.SetValorConquista(8, 1);
                //troca cor da explosao
                var part5 = explosao.GetComponent<ParticleSystem>().main;
                part5.startColor = coll.gameObject.GetComponent<SpriteRenderer>().color;
                //explosao quando a bola for destruida
                Instantiate(explosao, coll.transform.position, coll.transform.rotation);
                if (bolaRB.gameObject.tag != "BolaAzul")
                {
                    Destroy(bolaRB.gameObject);
                    Destroy(GetComponent<Marcador>().MarcadorObject());
                    //troca cor da explosao
                    var part6 = explosao.GetComponent<ParticleSystem>().main;
                    part6.startColor = this.GetComponent<SpriteRenderer>().color;
                    //explosao quando a bola for destruida
                    Instantiate(explosao, this.transform.position, this.transform.rotation);
                }
                else
                {
                    contador += 1;
                    DestruirBolaAzul();
                }
                break;
            case "BolaVerde":
                Destroy(coll.gameObject);
                
                //vale 1 de conquista a cada colisao com esta bola
                conqManager.SetValorConquista(10, 1);
                //troca cor da explosao
                var part7 = explosao.GetComponent<ParticleSystem>().main;
                part7.startColor = coll.gameObject.GetComponent<SpriteRenderer>().color;
                //explosao quando a bola for destruida
                Instantiate(explosao, coll.transform.position, coll.transform.rotation);
                if (bolaRB.gameObject.tag != "BolaAzul")
                {
                    Destroy(bolaRB.gameObject);
                    Destroy(GetComponent<Marcador>().MarcadorObject());
                    //troca cor da explosao
                    var part8 = explosao.GetComponent<ParticleSystem>().main;
                    part8.startColor = this.GetComponent<SpriteRenderer>().color;
                    //explosao quando a bola for destruida
                    Instantiate(explosao, this.transform.position, this.transform.rotation);
                }
                else
                {
                    contador += 1;
                    DestruirBolaAzul();
                }
                break;
            case "BolaLaranja":
                Destroy(coll.gameObject);
           
                //vale 1 de conquista a cada colisao com esta bola
                conqManager.SetValorConquista(12, 1);
                //troca cor da explosao
                var part9 = explosao.GetComponent<ParticleSystem>().main;
                part9.startColor = coll.gameObject.GetComponent<SpriteRenderer>().color;
                //explosao quando a bola for destruida
                Instantiate(explosao, coll.transform.position, coll.transform.rotation);
                if (bolaRB.gameObject.tag != "BolaAzul")
                {
                    Destroy(bolaRB.gameObject);
                    Destroy(GetComponent<Marcador>().MarcadorObject());
                    //troca cor da explosao
                    var part10 = explosao.GetComponent<ParticleSystem>().main;
                    part10.startColor = this.GetComponent<SpriteRenderer>().color;
                    //explosao quando a bola for destruida
                    Instantiate(explosao, this.transform.position, this.transform.rotation);
                }
                else
                {
                    contador += 1;
                    DestruirBolaAzul();
                }
                break;
            case "BolaRoxa":
                Destroy(coll.gameObject);
                
                //vale 1 de conquista a cada colisao com esta bola
                conqManager.SetValorConquista(11, 1);
                //troca cor da explosao
                var part11 = explosao.GetComponent<ParticleSystem>().main;
                part11.startColor = coll.gameObject.GetComponent<SpriteRenderer>().color;
                //explosao quando a bola for destruida
                Instantiate(explosao, coll.transform.position, coll.transform.rotation);
                if (bolaRB.gameObject.tag != "BolaAzul")
                {
                    Destroy(bolaRB.gameObject);
                    Destroy(GetComponent<Marcador>().MarcadorObject());
                    //troca cor da explosao
                    var part12 = explosao.GetComponent<ParticleSystem>().main;
                    part12.startColor = this.GetComponent<SpriteRenderer>().color;
                    //explosao quando a bola for destruida
                    Instantiate(explosao, this.transform.position, this.transform.rotation);
                }
                else
                {
                    contador += 1;
                    DestruirBolaAzul();
                }
                break;
            case "BolaPreta":
                Destroy(coll.gameObject);
                
                //vale 1 de conquista a cada colisao com esta bola
                conqManager.SetValorConquista(13, 1);
                //troca cor da explosao
                var part13 = explosao.GetComponent<ParticleSystem>().main;
                part13.startColor = coll.gameObject.GetComponent<SpriteRenderer>().color;
                //explosao quando a bola for destruida
                Instantiate(explosao, coll.transform.position, coll.transform.rotation);
                if (bolaRB.gameObject.tag != "BolaAzul")
                {
                    Destroy(bolaRB.gameObject);
                    Destroy(GetComponent<Marcador>().MarcadorObject());
                    //troca cor da explosao
                    var part14 = explosao.GetComponent<ParticleSystem>().main;
                    part14.startColor = this.GetComponent<SpriteRenderer>().color;
                    //explosao quando a bola for destruida
                    Instantiate(explosao, this.transform.position, this.transform.rotation);
                }
                else
                {
                    contador += 1;
                    DestruirBolaAzul();
                }
                break;
            case "BolaColorida":
                Destroy(coll.gameObject);
                
                //troca cor da explosao
                var part15 = explosao.GetComponent<ParticleSystem>().main;
                part15.startColor = coll.gameObject.GetComponent<SpriteRenderer>().color;
                //explosao quando a bola for destruida
                Instantiate(explosao, coll.transform.position, coll.transform.rotation);
                if (bolaRB.gameObject.tag != "BolaAzul")
                {
                    Destroy(bolaRB.gameObject);
                    Destroy(GetComponent<Marcador>().MarcadorObject());
                    //troca cor da explosao
                    var part16 = explosao.GetComponent<ParticleSystem>().main;
                    part16.startColor = this.GetComponent<SpriteRenderer>().color;
                    //explosao quando a bola for destruida
                    Instantiate(explosao, this.transform.position, this.transform.rotation);
                }
                else
                {
                    contador += 1;
                    DestruirBolaAzul();
                }
                break;
            default:
                break;
        }
        //se a colisão for com a parede de limite, a bola será destruida
        if (coll.gameObject.tag == "Limite")
        {
            Destroy(bolaRB.gameObject);
            //se ma bola tocar no limite dá gameover
            //GameObject.Find("Main Camera").GetComponent<GerarBolas>().GameOver();
            //se tocar no fundo é menos 1 de vida
            vidas.text = (Int32.Parse(vidas.text)-1).ToString(); 
        }

    }

    void DestruirBolaAzul()
    {
        if (contador == 2)
        {
            Destroy(bolaRB.gameObject);
            Destroy(GetComponent<Marcador>().MarcadorObject());
            //vale 1 de conquista a cada colisao com esta bola
            conqManager.SetValorConquista(4, 1);
            //troca cor da explosao
            var teste = explosao.GetComponent<ParticleSystem>().main;
            teste.startColor = new Color(0.08125484f, 0.06407974f, 0.9056604f, 1f);
            //explosao quando a bola for destruida
            Instantiate(explosao, this.transform.position, this.transform.rotation);

            contador = 0;
        }
    }
    
    void ComportamentoBolaVerde()
    {
        
        if (timer1 > 0.65)
        {
            //se a bola for a verde
            if (bolaRB.gameObject.tag == "BolaVerde")
            {
                if (GetComponent<SpriteRenderer>().enabled == false)
                {
                    GetComponent<SpriteRenderer>().enabled = true;
                    ballFx.gameObject.SetActive(true);
                }
                else
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                    ballFx.gameObject.SetActive(false);
                }
                timer1 = 0;
            }
        }
    }
    

    
    void ComportamentoBolaAmarela()
    {
        //se for amarelo
        if (timer2 > 0.9f)
        { 
            if (bolaRB.gameObject.tag == "BolaAmarela")
            {
                float position = Random.Range(-2f, 2f);
                transform.position = new Vector2(position, transform.position.y);
                /*
                //variavel que recebe o método da distancia entre a bola e a parede esquerda
                float distParedeEsquerda = Vector2.Distance(
                    bolaRB.transform.position,
                    GameObject.Find("ParedeEsquerda").transform.position
                    );
                //variavel que recebe o método da distancia entre a bola e a parede esquerda
                float distParedeDireita = Vector2.Distance(
                    bolaRB.transform.position,
                    GameObject.Find("ParedeDireita").transform.position
                    );

                //print(distParedeEsquerda + " " + distParedeDireita);

                
                //se a distancia da parede da direita for maior da esquerda, significa que a bola se movimentará
                //para o sentido à direita, caso contrario irá para o sentido oposto
                if(distParedeDireita > distParedeEsquerda)
                {
                    transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                }
                */
                //resetando a variavel de tempo
                timer2 = 0;
            }
        }
    }

   void ComportamentoBolaPreta()
    {

    }

    private string NomeParticula()
    {
        //consulta banco de dados para retornar o nome da skin da bola
        string query = bd.QueryString("nome", "Bola", "escolhido", "1");
        string res = "";
        if(query == "padrao")
        {
            res = "BolaComunEffect";
        }
        else if(query == "poligono")
        {
            res = "PoligonoEffect"; 
        }
        else if (query == "estrela")
        {
            res = "EstrelaEffect";
        }
        else if (query == "quadrado")
        {
            res = "QuadradoEffect";
        }
        else if (query == "radiante")
        {
            res = "RadianteEffect";
        }
        else if (query == "toy")
        {
            res = "ToyEffect";

        }
        else if (query == "cross")
        {
            res = "CrossEffect";
        }
        else
        {
            res = "BolaComunEffect";
        }
        return res;
    }

    public GameObject BallFx()
    {
        return ballFx;
    }

}
