using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Animator shake;
    private int colisao;
    private AudioSource se;

    // Start is called before the first frame update
    void Start()
    {
        shake = GetComponent<Animator>();
        se = GetComponent<AudioSource>();
        colisao = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //quando tiver 2 colisões, ou seja entre 2 bolas, a camera entrará em shake
        if (colisao == 2)
        {
            //método random para ser utilizado para o shake ser usado aleatoriamente
            int rand = Random.Range(0, 3);
            if (rand == 0)
            {
                shake.SetTrigger("Shake");
                se.Play();
               
            }
            else if(rand == 1)
            {
                shake.SetTrigger("Shake2");
                se.Play();

            }
            else if(rand == 2)
            {
                shake.SetTrigger("Shake3");
                se.Play();

            }
            colisao = 0;
        }
    }

    public void SetColisao(int x)
    {
        this.colisao += x;
    }

}
