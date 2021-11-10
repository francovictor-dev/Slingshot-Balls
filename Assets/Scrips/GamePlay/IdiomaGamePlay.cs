using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdiomaGamePlay : MonoBehaviour
{
    public Idioma idioma;
    public Text pontos;
    public Text total;
    public Text jogar;
    public Text sair;
    public Text novoRecord;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        if (idioma.GetIdioma() == "English")
        {
            pontos.text = "Points";
            total.text = "Total";
            jogar.text = "Play";
            sair.text = "Quit";
            novoRecord.text = "New Record!";
        }
        else if (idioma.GetIdioma() == "Portuguese")
        {
            pontos.text = "Pontos";
            total.text = "Total";
            jogar.text = "Jogar";
            sair.text = "Sair";
            novoRecord.text = "Novo Recorde!";
        }
        else if (idioma.GetIdioma() == "Spanish")
        {
            pontos.text = "Puntos";
            total.text = "Total";
            jogar.text = "Jugar";
            sair.text = "Salir";
            novoRecord.text = "¡Nuevo Record!";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
