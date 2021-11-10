using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdiomaStaff : MonoBehaviour
{
    public Idioma idioma;
    public GameObject en;
    public GameObject es;
    public GameObject br;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        if(idioma.GetIdioma() == "English")
        {
            en.SetActive(true);
            es.SetActive(false);
            br.SetActive(false);
        }
        else if (idioma.GetIdioma() == "Portuguese")
        {
            en.SetActive(false);
            es.SetActive(false);
            br.SetActive(true);
        }
        else if(idioma.GetIdioma() == "Spanish")
        {
            en.SetActive(false);
            es.SetActive(true);
            br.SetActive(false);
        }
    }
}
