using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public DataBase bg;
    private GameObject background;

    void Start()
    {
        //consulta banco de dados para retornar o nome do background
        string query = bg.QueryString("nome", "Background", "escolhido", "1");
        //carrega o background e coloca na tela do gameplay 
        if (query == null)//se não tiver background escolhido o background padrão é colocado
        {
            background = (GameObject)GameObject.Instantiate(Resources.Load("Background/padrao", typeof(GameObject)),
            Vector3.zero, Quaternion.identity);
        }
        else//caso tenha o resource busca
        {
            background = (GameObject)GameObject.Instantiate(Resources.Load("Background/"+query, typeof(GameObject)),
            Vector3.zero, Quaternion.identity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Background()
    {
        return background;
    }
}
