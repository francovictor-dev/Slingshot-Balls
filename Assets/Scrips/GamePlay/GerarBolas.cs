using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class GerarBolas : MonoBehaviour
{
    public GameObject bolaBranca;
    public GameObject bolaAzul;
    public GameObject bolaAmarela;
    public GameObject bolaVermelha;
    public GameObject bolaVerde;
    public GameObject bolaRoxa;
    public GameObject bolaLaranja;
    public GameObject bolaPreta;
    public GameObject bolaColorida;
    public TotalPontos totalPontos;
    //public BallManager bM;

    private float timer = 0;
    private bool gameOver;
    private int pontos;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        pontos = totalPontos.MostrarPontos();

       
    }

    // Update is called once per frame
    void Update()
    {
        pontos = totalPontos.MostrarPontos();
        if (!gameOver)
        {
            GamePlay();
        }
    }

    public void Restart()
    {
        gameOver = false;
    }

    public void GameOver()
    {
        gameOver = true;
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    private void GamePlay()
    {
        timer += Time.deltaTime;
        
        if(pontos >= 0 && pontos < 50)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = {bolaBranca};// bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
           
            // array para pegar o indice do objeto escolhido aleatoriamente  
            int i = Random.Range(0, bolas.Length);
            
            if (timer > 2.2f)
            {
                //instanciar a bola
                GameObject b = GameObject.Instantiate(bolas[i], new Vector2(Random.Range(-2f, 2f), 6.5f), bolas[i].transform.rotation);
                //rotação da bola
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }else if(pontos >= 50 && pontos < 100)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = { bolaBranca, bolaAzul };// bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
                                                          // array para pegar o indice do objeto escolhido aleatoriamente
            int i = Random.Range(0, bolas.Length);

            if (timer > 2f)
            {
                //instanciar a bola
                GameObject b = Instantiate(bolas[i], new Vector2(Random.Range(-2f, 2f), 6.5f), bolas[i].transform.rotation);
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }
        else if(pontos >= 100 && pontos < 200)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = { bolaBranca, bolaAzul, bolaVermelha };//bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
                                                          // array para pegar o indice do objeto escolhido aleatoriamente
            int i = Random.Range(0, bolas.Length);
           
            if (timer > 1.8f)
            {
                //instanciar a bola
                GameObject b = Instantiate(bolas[i], new Vector2(Random.Range(-2f, 2f), 6.5f), bolas[i].transform.rotation);
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }
        else if (pontos >= 200 && pontos < 400)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = { bolaBranca, bolaAzul, bolaVermelha, bolaVerde };// bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
                                                          // array para pegar o indice do objeto escolhido aleatoriamente
            int i = Random.Range(0, bolas.Length);
            
            if (timer > 1.6f)
            {
                //instanciar a bola
                GameObject b = Instantiate(bolas[i], new Vector2(Random.Range(-2f, 2f), 6.5f), bolas[i].transform.rotation);
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }
        else if (pontos >= 400 && pontos < 800)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = { bolaBranca, bolaAzul, bolaVermelha, bolaVerde, bolaRoxa };// bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
                                                          // array para pegar o indice do objeto escolhido aleatoriamente
            int i = Random.Range(0, bolas.Length);
            
            if (timer > 1.5f)
            {
                //instanciar a bola
                GameObject b = Instantiate(bolas[i], new Vector2(Random.Range(-2f, 2f), 6.5f), bolas[i].transform.rotation);
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }
        else if (pontos >= 800 && pontos < 1200)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = { bolaAzul, bolaVermelha, bolaVerde, bolaRoxa, bolaAmarela };// bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
                                                                                             // array para pegar o indice do objeto escolhido aleatoriamente
            int i = Random.Range(0, bolas.Length);
            
            if (timer > 1.4f)
            {
                //instanciar a bola
                GameObject b = Instantiate(bolas[i], new Vector2(Random.Range(-2f, 2f), 6.5f), bolas[i].transform.rotation);
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }
        else if (pontos >= 1200 && pontos < 1600)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = { bolaAzul, bolaVermelha, bolaVerde, bolaRoxa, bolaAmarela, bolaLaranja };// bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
                                                                                              // array para pegar o indice do objeto escolhido aleatoriamente
            int i = Random.Range(0, bolas.Length);
           
            if (timer > 1.3f)
            {
                //instanciar a bola
                GameObject b = Instantiate(bolas[i], new Vector2(Random.Range(-2f, 2f), 6.5f), bolas[i].transform.rotation);
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }
        else if (pontos >= 1600 && pontos < 2000)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = { bolaVermelha, bolaVerde, bolaRoxa, bolaAmarela, bolaLaranja, bolaPreta };// bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
                                                                                              // array para pegar o indice do objeto escolhido aleatoriamente
            int i = Random.Range(0, bolas.Length);
            
            if (timer > 1.2f)
            {
                //instanciar a bola
                GameObject b = Instantiate(bolas[i], new Vector2(Random.Range(-2f, 2f), 6.5f), bolas[i].transform.rotation);
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }
        else if (pontos >= 2000 && pontos < 2800)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = { bolaVerde, bolaRoxa, bolaAmarela, bolaLaranja, bolaPreta, bolaColorida };// bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
                                                                                              // array para pegar o indice do objeto escolhido aleatoriamente
            int i = Random.Range(0, bolas.Length);
            
            if (timer > 1.1f)
            {
                //instanciar a bola
                GameObject b = Instantiate(bolas[i], new Vector2(Random.Range(-2f, 2f), 6.5f), bolas[i].transform.rotation);
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }
        else if (pontos >= 2800 && pontos < 5600)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = { bolaBranca, bolaAzul, bolaVermelha, bolaVerde, bolaRoxa, bolaAmarela, bolaLaranja, bolaPreta, bolaColorida };// bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
                                                                                              // array para pegar o indice do objeto escolhido aleatoriamente
            int i = Random.Range(0, bolas.Length);
            
            if (timer > 1.0f)
            {
                //instanciar a bola
                GameObject b = Instantiate(bolas[i], new Vector2(Random.Range(-2f, 2f), 6.5f), bolas[i].transform.rotation);
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }
        else if (pontos >= 5600 && pontos < 10000)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = { bolaBranca, bolaAzul, bolaVermelha, bolaVerde, bolaRoxa, bolaAmarela, bolaLaranja, bolaPreta, bolaColorida };// bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
                                                                                                                                                // array para pegar o indice do objeto escolhido aleatoriamente
            int i = Random.Range(0, bolas.Length);

            if (timer > 0.9f)
            {
                //instanciar a bola
                GameObject b = Instantiate(bolas[i], new Vector2(Random.Range(-2f, 2f), 6.5f), bolas[i].transform.rotation);
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }

        else if (pontos >= 10000)
        {
            //criar um vetor que coloque todas as bolas
            GameObject[] bolas = { bolaBranca, bolaAzul, bolaVermelha, bolaVerde, bolaRoxa, bolaAmarela, bolaLaranja, bolaPreta, bolaColorida };// bolaColorida, bolaAzul, bolaAmarela, bolaVermelha, bolaVerde, bolaRoxa, bolaLaranja, bolaPreta };
                                                                                                                                                // array para pegar o indice do objeto escolhido aleatoriamente
            int i = Random.Range(0, bolas.Length);
            int i2 = Random.Range(0, bolas.Length);

            if (timer > 1f)
            {
                //instanciar a bola
                GameObject b = Instantiate(bolas[i], new Vector2(Random.Range(-2f, -0.6f), 6.5f), bolas[i].transform.rotation);
                b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                //instanciar a bola 2
                GameObject b2 = Instantiate(bolas[i2], new Vector2(Random.Range(0.6f, 2f), 6.5f), bolas[i2].transform.rotation);
                b2.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }

    }

}
