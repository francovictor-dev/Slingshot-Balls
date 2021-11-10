using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomFx : MonoBehaviour
{
    public AudioSource fx1;
    public AudioSource fx2;
    public AudioSource fx3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fx1.volume = SomMusica.som;
        fx2.volume = SomMusica.som;
        fx3.volume = SomMusica.som;
    }
}
