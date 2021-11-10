using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdiomaItens : MonoBehaviour
{
    public Idioma idioma;
    public Text record;
    public Text pontos;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        if (idioma.GetIdioma() == "English")
        {
            pontos.text = "Points";
            record.text = "Record";
        }
        else if (idioma.GetIdioma() == "Portuguese")
        {
            pontos.text = "Pontos";
            record.text = "Recorde";
        }
        else if (idioma.GetIdioma() == "Spanish")
        {
            pontos.text = "Puntos";
            record.text = "Registro";
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
