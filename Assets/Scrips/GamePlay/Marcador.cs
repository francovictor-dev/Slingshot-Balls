using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marcador : MonoBehaviour
{
    public GameObject marcadorObject;
    public GameObject bola;

    private GameObject marcador;

    // Start is called before the first frame update
    void Start()
    {
        marcador = GameObject.Instantiate(marcadorObject, new Vector3(0, 6, 0), Quaternion.identity);
        marcador.transform.Rotate(new Vector3(0, 0, 90));
        marcador.GetComponent<SpriteRenderer>().color = bola.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (bola.transform.position.y > 6.5) 
        {
            marcador.SetActive(true);
        }
        else
        {
            marcador.SetActive(false);
        }
        if (marcador)
        {
            marcador.transform.position = new Vector3(bola.transform.position.x, 6, 0);
        }
    }

    public GameObject MarcadorObject()
    {
        return marcador;
    }
}
