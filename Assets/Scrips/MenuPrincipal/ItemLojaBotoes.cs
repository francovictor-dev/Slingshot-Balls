using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLojaBotoes : MonoBehaviour
{
   

    public GameObject tocar;
    public GameObject parar;
    public Text pontos;
    public Text nome;
    public Text valor;
    public GameObject botaoComprar;
    public enum TipoItem { musica, background, sprite }
    [Header("Valor do tipo do item")]
    public TipoItem tipoItem;

    private Unity.VectorGraphics.SVGImage imagem;
    public GameObject janelaBackground;
    public DataBase bd;
    public AudioSource audioSource;
    private AudioClip song;
    private float time;
    //private bool contemLista = false;
    private string valorInicial;
    private string tabela = "";
    private string query = "";

    //int i = 0;
    //int j = 0;

    void Start()
    {
        valorInicial = valor.text;
        //variavel para receber o objeto inativo da janela de background 
        //janelaBackground = GameObject.Find("Canvas").transform.Find("JanelaBackground").gameObject;
        //buscar na hierarquia da scene o gameObject MenuSong e usar o componente AudioSource
        //audioSource = GameObject.Find("MenuSong").GetComponent<AudioSource>();
        //Variavel song recebe a musica dentro da pasta Resource/Audio
        song = Resources.Load<AudioClip>("Audio/" + nome.GetComponent<Text>().text);
        //encontrar Object que tenha o script de Banco de Dados
        //bd = GameObject.Find("DataBaseManager").GetComponent<DataBase>();
        //
    }

    void OnEnable()
    {
        //AtualizarPontos();
        VerificarItem();
    }

    void Update()
    {
        
        if (query != null)
        {
            valor.text = "ok";
        }
        else
        {
            valor.text = valorInicial;
        }
       
    }

    private void AtualizarPontos()
    {
        pontos.text = bd.QueryInt("pontos").ToString();
    }

    private void VerificarItem()
    {
        
        if (tipoItem == TipoItem.background)
        {
            query = bd.QueryString("nome", "Background", "nome", nome.GetComponent<Text>().text);
            tabela = "Background";
        }
        else if (tipoItem == TipoItem.musica)
        {
            query = bd.QueryString("nome", "Musica", "nome", nome.GetComponent<Text>().text);
            tabela = "Musica";
        }
        else if (tipoItem == TipoItem.sprite)
        {
            query = bd.QueryString("nome", "Bola", "nome", nome.GetComponent<Text>().text);
            tabela = "Bola";
        }
        /*
        if (tipoItem == TipoItem.musica) //musica
        {
            int[] x = new int[bd.QueryInt("count(id)", "Musica")];
            string[] vetor = new string[bd.QueryInt("count(id)", "Musica")];
            tabela = "Musica";
            if(i < x.Length)
            {
                vetor[i] = bd.QueryString("nome", "Musica", "id", (i + 1).ToString());
                i++;
            }

            if(j < x.Length)
            {
                if (nome.text == vetor[j])
                {
                    contemLista = true;
                }
                j++;
            }
        }
        else if (tipoItem == TipoItem.background) //background
        {
            int[] x = new int[bd.QueryInt("count(id)", "Background")];
            string[] vetor = new string[bd.QueryInt("count(id)", "Background")];
            tabela = "Background";
            if (i < x.Length)
            {
                vetor[i] = bd.QueryString("nome", "Background", "id", (i + 1).ToString());
                i++;
            }

            if (j < x.Length)
            {
                if (nome.text == vetor[j])
                {
                    contemLista = true;
                }
                j++;
            }
        }

        else if (tipoItem == TipoItem.sprite) //sprite
        {
            int[] x = new int[bd.QueryInt("count(id)", "Bola")];
            string[] vetor = new string[bd.QueryInt("count(id)", "Bola")];
            tabela = "Bola";
            if (i < x.Length)
            {
                vetor[i] = bd.QueryString("nome", "Bola", "id", (i + 1).ToString());
                i++;
            }

            if (j < x.Length)
            {
                if (nome.text == vetor[j])
                {
                    contemLista = true;
                }
                j++;
            }
        }
        */
    }

    public void Tocar()
    {
        //guarda o tempo que a musica é executado
        time = audioSource.time;
        //volta desde inicio o tempo da musica a seguir
        audioSource.time = 0;
        //AudioSource recebe a musica escolhida
        audioSource.clip = song;
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

    public void MostrarJanelaBackground()
    {
        //definir janela como ativo
        janelaBackground.SetActive(true);
        //variavel para receber o componente de Sprite da imagem
        imagem = GameObject.Find("Canvas/JanelaBackground/ImageSprite").GetComponent<Unity.VectorGraphics.SVGImage>();
        //buscando o objeto a partir do nome do item escolhido 
        GameObject sprite = (GameObject)GameObject.Instantiate
            (Resources.Load("Imagem/" + nome.GetComponent<Text>().text));

        //Sprite da imagem receber o sprite referente ao item escolhido para ser visto
        imagem.sprite = sprite.GetComponent<SpriteRenderer>().sprite;
    }

    public void Comprar()
    {

        int pontos = bd.QueryInt("pontos", "Player");
        int valorCompra = valor.text == "ok" ? 0 : int.Parse(valor.text);

        if (pontos >= valorCompra)
        {

            if (query == null)
            {
                bd.InsertBd(tabela, nome.text);
                int novoValorPontos = pontos - valorCompra;
                bd.UpdateBd(novoValorPontos);
                query = bd.QueryString("nome", tabela, "nome", nome.GetComponent<Text>().text);
                AtualizarPontos();
                //contemLista = true;
            }
        }
        else
        {

        }
    }
}
