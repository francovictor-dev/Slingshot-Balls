using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMusicaBotoes : MonoBehaviour
{
    public GameObject tocar;
    public GameObject parar;
    public Text nome;
    public Text botaoEscolher;

    private GerarItemMusica gim;
    private AudioSource audioSource;
    private float time;
    private DataBase bd;

    void Awake()
    {
        //buscar na hierarquia da scene o gameObject MenuSong e usar o componente AudioSource
        audioSource = GameObject.Find("MenuSong").GetComponent<AudioSource>();
        //encontrar Object que tenha o script de Banco de Dados
        bd = GameObject.Find("DataBaseManager").GetComponent<DataBase>();
        //variavel para ter acesso a script GerarItem
        gim = GameObject.Find("Canvas/PainelItem/Itens/Musicas/Lista").GetComponent<GerarItemMusica>();
    }

    public void Tocar()
    {
        //print();
        //guarda o tempo que a musica é executado
        time = audioSource.time;
        //volta desde inicio o tempo da musica a seguir
        audioSource.time = 0;
        //AudioSource recebe a musica escolhida
        //Variavel song recebe a musica dentro da pasta Resource/Audio
        audioSource.clip =  Resources.Load<AudioClip>("Audio/" + nome.GetComponent<Text>().text);
        //Toca a musica
        audioSource.Play();
        //troca de icone de play/parar
        tocar.SetActive(false);
        parar.SetActive(true);
    }

    public void Parar()
    {
        //parar a musica atual
        audioSource.Stop();
        //procura a musica de fundo do Menu
        audioSource.clip = Resources.Load<AudioClip>("Audio/MenuTheme");
        //retorna no tempo que parou quando foi interrompido
        audioSource.time = time;
        //playa musica de Menu de onde parou
        audioSource.Play();
        //troca de icone parar/play
        tocar.SetActive(true);
        parar.SetActive(false);
    }

    public void Selecionar()
    {
        //vetor x para consultar a quantidade de Musicas o jogador tem habilitado
        int[] x = new int[bd.QueryInt("count(id)", "Musica")];
        //laço com a quantidade maximo da variavel x
        for (int i = 0; i < x.Length; i++)
        {
            //update para todos os background para o campo 'escolhido' ser do estado 0, ou seja
            //não escolhido
            bd.UpdateBd("Musica", "escolhido", "0", "id", (i + 1).ToString());
        }
        //com esse update escolha somente uma musica coerente ao botao apertado
        bd.UpdateBd("Musica", "escolhido", "1", "nome", nome.GetComponent<Text>().text);
        string escolhidoNome = nome.GetComponent<Text>().text;
        gim.ResetarTabela(escolhidoNome, true);
    }
}
