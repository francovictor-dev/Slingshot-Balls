using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainelInicialIdioma : MonoBehaviour
{
    [Header("Botões")]
    public Image btInstrucaoIdioma;
    public Image btConquistaIdioma;
    [Header("Script de Idioma")]
    public Idioma idioma;
    [Header("Imagem de Intruções")]
    public Sprite instrucaoUsImage;
    public Sprite instrucaoPtImage;
    public Sprite instrucaoEsImage;
    [Header("Imagem de Conquista")]
    public Sprite conquistaUsImage;
    public Sprite conquistaPtImage;
    public Sprite conquistaEsImage;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(idioma.GetIdioma() == "English")
        {
            btInstrucaoIdioma.sprite = instrucaoUsImage;
            btConquistaIdioma.sprite = conquistaUsImage;
            print("English");
        }
        else if(idioma.GetIdioma() == "Portuguese")
        {
            btInstrucaoIdioma.sprite = instrucaoPtImage;
            btConquistaIdioma.sprite = conquistaPtImage;
            print("Portuguese");
        }
        else if (idioma.GetIdioma() == "Spanish")
        {
            btInstrucaoIdioma.sprite = instrucaoEsImage;
            btConquistaIdioma.sprite = conquistaEsImage;
            print("Spanish");
        }
    }
}
