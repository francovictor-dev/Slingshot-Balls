using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SomMusica : MonoBehaviour
{
    public Slider nivelMusica;
    public Slider nivelSom;
    public AudioSource musica;
    public static float som;
    public static float bgm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        musica.volume = nivelMusica.value;
        som = nivelSom.value;
        bgm = nivelMusica.value;
    }
}
