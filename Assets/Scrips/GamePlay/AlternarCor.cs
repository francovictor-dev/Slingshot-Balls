using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternarCor : MonoBehaviour
{
    private SpriteRenderer bolaCor;
    float timer = 0;
    bool desativarCores = false;
    bool gerarBola = false;

    public GameObject BolaAmarela;
    public GameObject BolaAzul;
    public GameObject BolaVermelha;
    public GameObject BolaVerde;
    public GameObject BolaRoxa;
    public GameObject BolaLaranja;
    public GameObject BolaPreta;

    private Color amarelo;
    private Color azul;
    private Color vermelho;
    private Color verde;
    private Color roxo;
    private Color laranja;
    private Color preto;

    

    // Start is called before the first frame update
    void Start()
    {
        bolaCor = GetComponent<SpriteRenderer>();

        amarelo = new Color(1, 0.9645196f, 0, 1);
        azul = new Color(0.08125484f, 0.06407974f, 0.9056604f, 1);
        vermelho = new Color(0.990566f, 0.07943219f, 0.07943219f, 1);
        verde = new Color(0, 1, 0.0450387f, 1);
        roxo = new Color(0.863897f, 0, 0.8773585f, 1);
        laranja = new Color(1, 0.4651551f, 0, 1);
        preto = new Color(0.1415094f, 0.1415094f, 0.1415094f, 1);

        
    }

    // Update is called once per frame
    void Update()
    {
        ClickedInBall();

        timer += Time.deltaTime;

        Color[] cor = { amarelo, azul, vermelho, laranja, verde, roxo, preto };


        if (desativarCores == false)
        {
            if (timer > 0.6f)
            {
                int i = Random.Range(0, cor.Length);

                bolaCor.color = cor[i];
                timer = 0;

               
            }
        }

        if(gerarBola == true)
        {
            GerarBola(cor);
            Destroy(bolaCor.gameObject);
        }
        

    }

    void ClickedInBall()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag == "BolaColorida")
                {
                    CancelarCores();
                    AtivarGeradorDeBola();
                }

            }
        }
        
    }

    void CancelarCores()
    {
        desativarCores = true;
    }

    void AtivarGeradorDeBola()
    {
        gerarBola = true;
    }

    void GerarBola(Color[] cor)
    {
        //amarelo
        if(bolaCor.color == cor[0])
        {
            Instantiate(
                   BolaAmarela.gameObject, bolaCor.gameObject.transform.position, bolaCor.gameObject.transform.rotation);
        }
        //azul
        else if (bolaCor.color == cor[1])
        {
            Instantiate(
                   BolaAzul.gameObject, bolaCor.gameObject.transform.position, bolaCor.gameObject.transform.rotation);
        }
        //vermelho
        if (bolaCor.color == cor[2])
        {
            Instantiate(
                   BolaVermelha.gameObject, bolaCor.gameObject.transform.position, bolaCor.gameObject.transform.rotation);
        }
        //laranja
        if (bolaCor.color == cor[3])
        {
            Instantiate(
                   BolaLaranja.gameObject, bolaCor.gameObject.transform.position, bolaCor.gameObject.transform.rotation);
        }
        //verde
        if (bolaCor.color == cor[4])
        {
            Instantiate(
                   BolaVerde.gameObject, bolaCor.gameObject.transform.position, bolaCor.gameObject.transform.rotation);
        }
        //roxo
        if (bolaCor.color == cor[5])
        {
            Instantiate(
                   BolaRoxa.gameObject, bolaCor.gameObject.transform.position, bolaCor.gameObject.transform.rotation);
        }
        //preto
        if (bolaCor.color == cor[6])
        {
            Instantiate(
                   BolaPreta.gameObject, bolaCor.gameObject.transform.position, bolaCor.gameObject.transform.rotation);
        }

    }
  
}
