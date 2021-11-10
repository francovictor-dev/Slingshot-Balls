using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    public DataBase bg;

    private GameObject spriteBall;
    // Start is called before the first frame update
    void Start()
    {
        //consulta banco de dados para retornar o nome do sprite da bola
        string query = bg.QueryString("nome", "Bola", "escolhido", "1");
        //carrega sprite da bola e coloca na tela do gameplay 
        if (query == null)//se não sprite escolhido o padrão é colocado
        {
            //gerar o sprite da bola e jogado longe do gameplay
            spriteBall = (GameObject)GameObject.Instantiate(Resources.Load("Bola/padrao"),
                new Vector2(200, 200), Quaternion.identity);
        }
        else//caso tenha o resource busca
        {
            //gerar o sprite da bola e jogado longe do gameplay
            spriteBall = (GameObject)GameObject.Instantiate(Resources.Load("Bola/" + query),
                new Vector2(200, 200), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public GameObject SpriteBall()
    {
        return spriteBall;
    }
}
