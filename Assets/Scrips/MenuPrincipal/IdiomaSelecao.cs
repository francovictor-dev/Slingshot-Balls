using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdiomaSelecao : MonoBehaviour
{
    public Dropdown idioma;
    public DataBase db;
    public Idioma lingua;
    // Start is called before the first frame update
    void Start()
    {
        idioma.value = db.QueryInt("id", "Idioma", "escolhido", "1") - 1;
        idioma.onValueChanged.AddListener(delegate
        {
            MudarIdioma(idioma);
        });
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    public void MudarIdioma(Dropdown dropdown)
    {
        if (dropdown.value == 0)
        {
            string query = db.QueryString("lingua", "Idioma", "escolhido", "1");
            db.UpdateBd("Idioma", "escolhido", "0", "lingua", query);
            db.UpdateBd("Idioma", "escolhido", "1", "lingua", "English");
            lingua.SetIdioma("English");
        }
        else if (dropdown.value == 1)
        {
            string query = db.QueryString("lingua", "Idioma", "escolhido", "1");
            db.UpdateBd("Idioma", "escolhido", "0", "lingua", query);
            db.UpdateBd("Idioma", "escolhido", "1", "lingua", "Portuguese");
            lingua.SetIdioma("Portuguese");
        }
        else if (dropdown.value == 2)
        {
            string query = db.QueryString("lingua", "Idioma", "escolhido", "1");
            db.UpdateBd("Idioma", "escolhido", "0", "lingua", query);
            db.UpdateBd("Idioma", "escolhido", "1", "lingua", "Spanish");
            lingua.SetIdioma("Spanish");
        }
    }
    
}
