using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulaCor : MonoBehaviour
{
    private ParticleSystem particula;
    // Start is called before the first frame update
    void Start()
    {
        particula = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //buscar o background gerado 
        GameObject background = GameObject.Find("BackgroundManager").GetComponent<BackgroundManager>().Background();
        //manipular a particula
        var part = particula.main;
        //buscar o children do background para a cor da particula seja a 
        // mesma da children (paredes do background)
        part.startColor = 
            background.transform.Find("ParedeEsquerda").gameObject.GetComponent<SpriteRenderer>().color;
            
    }
}
