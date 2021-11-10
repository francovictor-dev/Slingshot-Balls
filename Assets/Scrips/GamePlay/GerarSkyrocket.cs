using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarSkyrocket : MonoBehaviour
{
    public GameObject skyRocket;
    public GerarBolas gameOver;
    public Bonus bonus;

    private float timer = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (gameOver.GetGameOver())
        {

        }
        else
        {
            if (timer > 5f && bonus.GetPtBonus() >= 18)
            {
                print("Pronto");
                //instanciar a bola
                GameObject r = GameObject.Instantiate(skyRocket, new Vector2(Random.Range(-2f, 2f), 6.5f), skyRocket.transform.rotation);
                //rotação da bola
                r.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
                timer = 0;
            }
        }
    }
}
