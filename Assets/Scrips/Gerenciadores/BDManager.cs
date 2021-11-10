using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDManager : MonoBehaviour
{
    public GerarBolas gameOver;
    public static bool evento = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        evento = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.GetGameOver())
        {
            if (evento)
            {
                GetComponent<BDPontos>().enabled = false;
            }
            else
            {
                GetComponent<BDPontos>().enabled = true;
            }
            
        }
        else
        {
            GetComponent<BDPontos>().enabled = false;
        }
    }
}
