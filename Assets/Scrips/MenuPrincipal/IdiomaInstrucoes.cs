using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdiomaInstrucoes : MonoBehaviour
{
    [Header("Painel de idiomas")]
    public GameObject br;
    public GameObject en;
    public GameObject es;
    [Header("Script de Idioma")]
    public Idioma idioma;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        if (idioma.GetIdioma() == "English")
        {
            br.SetActive(false);
            es.SetActive(false);
            en.SetActive(true);
        }
        else if (idioma.GetIdioma() == "Portuguese")
        {
            br.SetActive(true);
            es.SetActive(false);
            en.SetActive(false);
        }
        else if (idioma.GetIdioma() == "Spanish")
        {
            br.SetActive(false);
            es.SetActive(true);
            en.SetActive(false);
        }
    }
}
