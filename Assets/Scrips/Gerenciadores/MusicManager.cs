using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public DataBase bg;
    public AudioSource audioSource;

    private AudioClip musica;

    // Start is called before the first frame update
    void Start()
    {
        //consulta banco de dados para retornar o nome da musica
        string query = bg.QueryString("nome", "Musica", "escolhido", "1");

        //carrega o background e coloca na tela do gameplay
        if (query == null)//se não tiver musica escolhido a musica padrão é colocado
        {
            musica = (AudioClip)(Resources.Load("Audio/" + "fineless"));
        }
        else//caso tenha o resource busca
        {
            musica = (AudioClip)(Resources.Load("Audio/" + query));
        }

        audioSource.clip = musica;
        audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        audioSource.volume = SomMusica.bgm;
    }

}
