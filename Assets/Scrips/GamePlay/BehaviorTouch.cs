using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BehaviorTouch : MonoBehaviour
{
    public GameObject puxador;
    public GameObject seta;
    //usado quando a bola for vermelha
    public GameObject seta2;
    public GerarBolas gameOver;

    private Vector2 touchPosicao;
    private Vector2 offset;
    private Vector2 direcao;
    private Vector2 direcaoSeta;
    private RaycastHit2D bola;
    private bool colisao;
    private int valorDirecaoBolaPreta;

    int index;
    bool ativador = true;
    float time = 2;
    // Start is called before the first frame update
    void Start()
    {
        seta.SetActive(false);
        seta2.SetActive(false);
        puxador.SetActive(false);
        colisao = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.GetGameOver())
        {
            seta.SetActive(false);
            seta2.SetActive(false);
            puxador.SetActive(false);
            colisao = false;
        }

        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        transform.position = worldPoint;
        if (Input.GetMouseButtonDown(0))
        {
            TouchDown(hit);

        }
        if (Input.GetMouseButton(0))
        {
            TouchDrag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            TouchUp();

        }
    }

    void TouchDown(RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            if (hit.collider.tag.Contains("Bola") && hit.collider.tag != "BolaColorida")
            {

                // Debug.Log(hit.collider.name);
                //toda vez que o jogador tocar na bola a variavel vai enviar um valor para a variavel na classe Bonus
                //GameObject.Find("Canvas/Bonus").GetComponent<Bonus>().SetTouchLimiteBola(1);
                GameObject.Find("Canvas/Bonus").GetComponent<Bonus>().SetTouchLimiteBola(1);
                bola = hit;

            }

        }
    }

    void TouchDrag()
    {
        
            if (bola.collider != null)
            {
                //congela movimento da bola
                bola.rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

                //ativando o puxador
                puxador.SetActive(true);

                //Touch touch = Input.GetTouch(0);
                //posicao do mouse recebe posicao do mouse convertido para o mundo do jogo
                //touchPosicao = Camera.main.ScreenToWorldPoint(
                //   new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z)
                //    );
                touchPosicao = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                //offset é o deslocamento inicial do mouse com o proximo movimento do mouse
                offset = touchPosicao - bola.point;
                //o metodo cria uma direcao com o calculo do deslocamento do mouse
                direcao = Vector2.ClampMagnitude(offset, 1.1f);
                direcaoSeta = Vector2.ClampMagnitude(offset, 0.8f);

                //se o mouse se movimentar o puxador aparecerá e ficará na mesma posisão do mouse
                MostrarPuxador(puxador.transform, bola.rigidbody, direcao);
                //se o mouse se movimentar a seta aparecerá com direção oposta do mouse
                MostrarSeta(seta, seta2, bola.rigidbody, direcaoSeta);
                //método para a seta piscar quando estiver no carregamento máximo do puxador
                PiscarSeta(direcaoSeta, seta.GetComponent<SpriteRenderer>());

           
        }
        if (colisao)
        {
            puxador.SetActive(false);
            seta.SetActive(false);
            seta2.SetActive(false);
            colisao = false;
        }
    }

    void TouchUp()
    {
        if (bola.collider != null)
        {
            bola.rigidbody.constraints = RigidbodyConstraints2D.None;

            //quando mouse tirar o botao do touch o puxador sera removido e a bola podera de movimentar livremente novamente
            puxador.SetActive(false);

            //método para lançar a bola 
            LancarBola(bola.rigidbody);

            //System.Windows.Forms.Cursor.Position  = transform.position.x;
            seta.SetActive(false);
            seta2.SetActive(false);

            bola = new RaycastHit2D();

        }

    }

    public void ColisaoBolas(bool colisao){
        this.colisao = colisao;
    }

    void MostrarPuxador(Transform puxador, Rigidbody2D bola, Vector2 dir)
    {
        //if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        //{
            //puxador se movimenta decorrente com a posicao do mouse
            puxador.position = new Vector2(bola.position.x + dir.x, bola.position.y + dir.y);
        //}
    }

    void MostrarSeta(GameObject seta, GameObject seta2, Rigidbody2D bola, Vector2 dirSeta)
    {
       // if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
       // {
            //se for bola vermelha
            if (bola.gameObject.tag == "BolaVermelha")
            {

                Vector2[] novaDirecao = {
                //310 50
                    Quaternion.Euler(0, 0, 300) * dirSeta,
                    Quaternion.Euler(0, 0, 60) * dirSeta
                };

                //seta se movimenta decorrente com a posicao do mouse, e com um angulo adicional
                seta.transform.position = new Vector2(
                    bola.position.x + (-1 * novaDirecao[1].x),
                    bola.position.y + (-1 * novaDirecao[1].y)
                    );

                //seta2 se movimenta decorrente com a posicao do mouse, e com um angulo adicional
                seta2.transform.position = new Vector2(
                    bola.position.x + (-1 * novaDirecao[0].x),
                    bola.position.y + (-1 * novaDirecao[0].y)
                    );

                //seta aparece
                seta.SetActive(true);
                seta2.SetActive(true);
                //30 330
                //direcao da seta 
                seta.transform.up = Quaternion.Euler(0, 0, 40) * -dirSeta;

                //direcao da seta2
                seta2.transform.up = Quaternion.Euler(0, 0, 320) * -dirSeta;

            }
            else if (bola.gameObject.tag == "BolaPreta")
            {
            /*
            Vector2[] novaDirecao = {
                Quaternion.Euler(0, 0, 300) * dirSeta, //seta2
                Quaternion.Euler(0, 0, 60) * dirSeta //seta1
            };

            //direcao da seta 
            seta.transform.up = Quaternion.Euler(0, 0, 40) * -dirSeta;

            //direcao da seta2
            seta2.transform.up = Quaternion.Euler(0, 0, 320) * -dirSeta;

            //seta se movimenta decorrente com a posicao do mouse, e com um angulo adicional
            seta.transform.position = new Vector2(
                    bola.position.x + (-1 * novaDirecao[1].x),
                    bola.position.y + (-1 * novaDirecao[1].y)
                    );

            //seta2 se movimenta decorrente com a posicao do mouse, e com um angulo adicional
            seta2.transform.position = new Vector2(
                bola.position.x + (-1 * novaDirecao[0].x),
                bola.position.y + (-1 * novaDirecao[0].y)
                );

            //seta aparece
            seta.SetActive(true);
            seta2.SetActive(true);

            */
            
            Vector2[] novaDirecao = {
                    Quaternion.Euler(0, 0, 360) * dirSeta, //seta2
                    Quaternion.Euler(0, 0, 340) * dirSeta, //seta2
                    Quaternion.Euler(0, 0, 320) * dirSeta, //seta2
                    Quaternion.Euler(0, 0, 300) * dirSeta, //seta2
                    Quaternion.Euler(0, 0, 60) * dirSeta, //seta1
                    Quaternion.Euler(0, 0, 40) * dirSeta, //seta1
                    Quaternion.Euler(0, 0, 20) * dirSeta //seta1
                };

            time += Time.deltaTime;

            index = UnityEngine.Random.Range(0, 7);

            if (ativador == true)
            {
                
                if (index == 0)
                {
                    //direcao 360 - 0
                    seta.transform.up = Quaternion.Euler(0, 0, 360) * -dirSeta;
                    SetDirecaoSetaBolaPreta(360);
                }
                else if(index == 1)
                {
                    //direcao 340 - 1
                    seta.transform.up = Quaternion.Euler(0, 0, 340) * -dirSeta;
                    SetDirecaoSetaBolaPreta(340);
                }
                else if (index == 2)
                {
                    //direcao 320 - 2
                    seta.transform.up = Quaternion.Euler(0, 0, 320) * -dirSeta;
                    SetDirecaoSetaBolaPreta(320);
                }
                else if (index == 3)
                {
                    //direcao 300 - 3
                    seta.transform.up = Quaternion.Euler(0, 0, 300) * -dirSeta;
                    SetDirecaoSetaBolaPreta(300);
                }
                else if (index == 4)
                {
                    //direcao 60 - 4
                    seta.transform.up = Quaternion.Euler(0, 0, 60) * -dirSeta;
                    SetDirecaoSetaBolaPreta(60);
                }
                else if (index == 5)
                {
                    //direcao 40 - 5
                    seta.transform.up = Quaternion.Euler(0, 0, 40) * -dirSeta;
                    SetDirecaoSetaBolaPreta(40);
                }
                else if (index == 6)
                {
                    //direcao 20 - 6
                    seta.transform.up = Quaternion.Euler(0, 0, 20) * -dirSeta;
                    SetDirecaoSetaBolaPreta(20);
                }

                //seta se movimenta decorrente com a posicao do mouse, e com um angulo adicional
                
                //ativador = false;
                time = 0;
            }


            seta.transform.position = new Vector2(
                        bola.position.x + (-1 * novaDirecao[index].x),
                        bola.position.y + (-1 * novaDirecao[index].y)
                        );
            seta.SetActive(true);


        }
            else
            {
                //seta se movimenta decorrente com a posicao do mouse
                seta.transform.position = new Vector2(
                    bola.position.x + (-1 * dirSeta.x),
                    bola.position.y + (-1 * dirSeta.y)
                    );

                //seta aparece
                seta.SetActive(true);
                //direcao da seta 
                seta.transform.up = -dirSeta;
            }

        //}
    }

    void PiscarSeta(Vector2 setaDirecao, SpriteRenderer setaCor)
    {

        if (setaDirecao.magnitude > 0.68f)
        {
            //o Random vai fazer variar da cor amarela e vermelha
            setaCor.color = new Color(1, UnityEngine.Random.Range(0f, 1f), 0, 1f);
            //quando a bola for vermelha
            seta2.GetComponent<SpriteRenderer>().color = new Color(1, UnityEngine.Random.Range(0f, 1f), 0, 1f);
        }
        else
        {
            //cor da seta muda de branco para vermelho conforma o puxador é mais puxado
            setaCor.color = new Color(1f, 1f - setaDirecao.magnitude, 1f - setaDirecao.magnitude, 1f);
            //quando a bola for vermelha
            seta2.GetComponent<SpriteRenderer>().color =
                new Color(1f, 1f - setaDirecao.magnitude, 1f - setaDirecao.magnitude, 1f);
        }
    }

    void LancarBola(Rigidbody2D bola)
    {
        switch (bola.gameObject.tag)
        {
            case "BolaVermelha":

                //GameObject bolaClone = Instantiate(this.bola.collider.gameObject,
                //    new Vector2(bola.position.x + 0.6f, bola.position.y), bola.transform.rotation);

                GameObject bolaClone = Instantiate(this.bola.collider.gameObject,
                    seta2.transform.position, bola.transform.rotation);

                //bola.position = new Vector2(bola.position.x + -0.6f, bola.position.y);

                bola.position = seta.transform.position;

                Vector2[] novaDirecao = {
                    //340 20
                    Quaternion.Euler(0, 0, 340) * direcao,
                    Quaternion.Euler(0, 0, 20) * direcao
                };

                bolaClone.GetComponent<Rigidbody2D>().AddForce(-1 * novaDirecao[0] * 900f);
                bola.AddForce(-1 * novaDirecao[1] * 900f);

                break;
            case "BolaAzul":
                bola.AddForce(-1 * direcao * 2500f);
                break;
            case "BolaRoxa":
                bola.AddForce(-1 * direcao * 1200f);
                break;
            case "BolaLaranja":
                bola.AddForce(-1 * direcao * 500f);
                break;
            case "BolaBranca":
                bola.AddForce(-1 * direcao * 1100f);
                break;
            case "BolaPreta":
                //Vector2 direcaoAleatorio = Quaternion.Euler(0, 0, Random.Range(120, 240)) * direcao;
                //bola.AddForce(direcaoAleatorio * 2500f);
                Vector2 direcaoAleatorio = Quaternion.Euler(0, 0, GetDirecaoSetaBolaPreta()) * -direcao;
                bola.AddForce(direcaoAleatorio * 2500f);
                break;
            default:
                bola.AddForce(-1 * direcao * 1050f);
                break;

        }
    }

    private void SetDirecaoSetaBolaPreta(int valor)
    {
        this.valorDirecaoBolaPreta = valor;
    }

    private int GetDirecaoSetaBolaPreta()
    {
        return valorDirecaoBolaPreta;
    }
}
