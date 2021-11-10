using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeColisao : MonoBehaviour
{
    private Animator anim;
    private AudioSource se;
    //variavel para manipular script de conquista
    private ConquestManager conqManager;
   
    public GameObject particula;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        se = this.GetComponent<AudioSource>();

        //localizar e adquirir o script de conquista
        conqManager = GameObject.Find("ConquestManager").GetComponent<ConquestManager>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag.Contains("Bola"))
        {
            se.Play();
            anim.SetTrigger("Colisao");
            Instantiate(
                particula, 
                new Vector2(this.transform.position.x, coll.transform.position.y),
                Quaternion.identity
                );
            //conquista de numero 1 e recebe 1 de valor toda vez que tenha colisão com alguma bola
            //com a parede, logo esse valor sera armazenado no script ConquestManager
            conqManager.SetValorConquista(2, 1);
        }
    }
}
