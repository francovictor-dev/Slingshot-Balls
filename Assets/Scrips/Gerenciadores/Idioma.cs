using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idioma : MonoBehaviour
{
    public DataBase db;

    private string idioma;
    // Start is called before the first frame update
    void Start()
    {
        idioma = db.QueryString("lingua", "Idioma", "escolhido", "1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetIdioma(string lingua)
    {
        idioma = lingua;
    }
    public string GetIdioma()
    {
        return idioma;
    }
}
