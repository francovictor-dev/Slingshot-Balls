using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRocket : MonoBehaviour
{
    public GameObject explosao;
    private GerarBolas gameOver;
    public GameObject pontos;
    private int vida = 4;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.Find("Main Camera").GetComponent<GerarBolas>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(vida == 0)
        {
            Instantiate(explosao, this.gameObject.transform.position, Quaternion.identity);
            Instantiate(pontos, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (gameOver.GetGameOver()){
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Contains("Bola") || coll.gameObject.tag.Contains("Lateral"))
        {
            vida--;
        }

        if (coll.gameObject.tag.Contains("Limite"))
        {
            Destroy(this.gameObject);
        }

    }
}
