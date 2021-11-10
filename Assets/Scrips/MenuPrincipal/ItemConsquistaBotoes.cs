using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemConsquistaBotoes : MonoBehaviour
{
    [Header("Objetos dentro do item")]
    public GameObject info;
    public Text descricao;
    public Text valorAtual;
    public Text valorTotal;
    public GameObject tocar;
    public GameObject parar;
    public Text nome;
    public int idConquista;
    public Text id;
    public GameObject botaoAtivar;
    public GameObject textOk;
    public enum TipoItem {musica, background, sprite}
    [Header("Valor do tipo do item")]
    public TipoItem tipoItem;

    private Unity.VectorGraphics.SVGImage imagem;
    public GameObject janelaBackground;
    public DataBase bd;
    public AudioSource audioSource;

    private AudioClip song;
    private float time;
    private int bdValor;
    private int bdRequisito;
    public Idioma idioma;

    //private bool contemLista = false;
    private string tabela = "";

    // Start is called before the first frame update
    void Awake()
    {
        //buscar script de idioma
        idioma = GameObject.Find("IdiomaManager").GetComponent<Idioma>();
        //variavel para receber o objeto inativo da janela de background 
        //janelaBackground = GameObject.Find("Canvas").transform.Find("JanelaBackground").gameObject;
        //buscar na hierarquia da scene o gameObject MenuSong e usar o componente AudioSource
        //audioSource = GameObject.Find("MenuSong").GetComponent<AudioSource>();
        //Variavel song recebe a musica dentro da pasta Resource/Audio
        song = Resources.Load<AudioClip>("Audio/" + nome.GetComponent<Text>().text);
        //encontrar Object que tenha o script de Banco de Dados
        //bd = GameObject.Find("DataBaseManager").GetComponent<DataBase>();
        //recebe valor atual da conquista
        bdValor = bd.QueryInt("valor", "Conquista", "id", id.GetComponent<Text>().text);
        //recebe o valor do requisito necessario para finalizar a conquista
        bdRequisito = bd.QueryInt("requisito", "Conquista", "id", id.GetComponent<Text>().text);
        //colcoar descricao do item baseado no banco de dados
        descricao.text = bd.QueryString("descricao", "Conquista", "id", id.GetComponent<Text>().text);
        //info informará o valor atual e o valor total da conquista
        valorAtual.text = bdValor.ToString();
        valorTotal.text = bdRequisito.ToString();

        VerificarItemConquista();
    }

    void OnEnable()
    {
        if(idioma.GetIdioma() == "English")
        {
            switch (id.text)
            {
                case "1":
                    descricao.text = "Accumulate 6000 points";
                    break;
                case "2":
                    descricao.text = "Make 200 bounces on the sides";
                    break;
                case "3":
                    descricao.text = "Pop 400 white balls";
                    break;
                case "4":
                    descricao.text = "Pop 300 blue balls";
                    break;
                case "5":
                    descricao.text = "Accumulate 60000 points";
                    break;
                case "6":
                    descricao.text = "Get 20x bonus points";
                    break;
                case "7":
                    descricao.text = "Score 3000 points in a round";
                    break;
                case "8":
                    descricao.text = "Pop 300 red balls";
                    break;
                case "9":
                    descricao.text = "Pop 250 yellow balls";
                    break;
                case "10":
                    descricao.text = "Pop 250 green balls";
                    break;
                case "11":
                    descricao.text = "Pop 200 pink balls";
                    break;
                case "12":
                    descricao.text = "Pop 200 orange balls";
                    break;
                case "13":
                    descricao.text = "Pop 100 black balls";
                    break;
                case "14":
                    descricao.text = "Pop 50 SkyRockets";
                    break;
            }
        }
        else if (idioma.GetIdioma() == "Portuguese")
        {
            switch (id.text)
            {
                case "1":
                    descricao.text = "Acumule 6000 pontos";
                    break;
                case "2":
                    descricao.text = "Faca 200 colisoes nas paredes";
                    break;
                case "3":
                    descricao.text = "Estoure 400 bolas brancas";
                    break;
                case "4":
                    descricao.text = "Estoure 300 bolas azuis";
                    break;
                case "5":
                    descricao.text = "Acumule 60000 pontos";
                    break;
                case "6":
                    descricao.text = "Faca pontos com bonus 20x";
                    break;
                case "7":
                    descricao.text = "Faca 3000 pontos em uma rodada";
                    break;
                case "8":
                    descricao.text = "Estoure 300 bolas vermelhas";
                    break;
                case "9":
                    descricao.text = "Estoure 250 bolas amarelas";
                    break;
                case "10":
                    descricao.text = "Estoure 250 bolas verdes";
                    break;
                case "11":
                    descricao.text = "Estoure 200 bolas rosas";
                    break;
                case "12":
                    descricao.text = "Estoure 200 bolas laranjas";
                    break;
                case "13":
                    descricao.text = "Estoure 100 bolas pretas";
                    break;
                case "14":
                    descricao.text = "Estoure 50 SkyRockets";
                    break;
            }
        }
        else if (idioma.GetIdioma() == "Spanish")
        {
            switch (id.text)
            {
                case "1":
                    descricao.text = "Acumule 6000 puntos";
                    break;
                case "2":
                    descricao.text = "Haga 200 colisiones en las paredes";
                    break;
                case "3":
                    descricao.text = "Destruye 400 pelotas blancas";
                    break;
                case "4":
                    descricao.text = "Destruye 300 pelotas azules";
                    break;
                case "5":
                    descricao.text = "Acumule 60000 puntos";
                    break;
                case "6":
                    descricao.text = "Obtenga puntos con un bono 20x";
                    break;
                case "7":
                    descricao.text = "Haga 3000 puntos en una ronda";
                    break;
                case "8":
                    descricao.text = "Destruye 300 pelotas rojas";
                    break;
                case "9":
                    descricao.text = "Destruye 250 pelotas amarillas";
                    break;
                case "10":
                    descricao.text = "Destruye 250 pelotas verdes";
                    break;
                case "11":
                    descricao.text = "Destruye 200 pelotas rosas";
                    break;
                case "12":
                    descricao.text = "Destruye 200 pelotas naranjas";
                    break;
                case "13":
                    descricao.text = "Destruye 100 pelotas negras";
                    break;
                case "14":
                    descricao.text = "Destruye 50 SkyRockets";
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void VerificarItemConquista()
    {
        if (bdValor >= bdRequisito)
        {
            info.SetActive(false);
            textOk.SetActive(true);

            string query = "";
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

            if(query == null)
            {
                
                bd.InsertBd(tabela, nome.GetComponent<Text>().text);
            }
            /*
            if (query == nome.GetComponent<Text>().text)
            {
                botaoAtivar.SetActive(false);
                textOk.SetActive(true);
            }
            else
            {
                botaoAtivar.SetActive(false);
                textOk.SetActive(false);
            }
            */
        }
        else
        {
            textOk.SetActive(false);
            botaoAtivar.SetActive(false);
            info.SetActive(true);
        }
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

    /*
    public void Ativar()
    {
        if (!contemLista)
        {
            bd.InsertBd(tabela, nome.text);
        }
    }
    

    /*
    private void VerificarItem()
    {
        
        if (tipoItem == TipoItem.background)
        {
            int[] x = new int[bd.QueryInt("count(id)", "Background")];
            string[] vetor = new string[bd.QueryInt("count(id)", "Background")];

            for (int i = 0; i < x.Length; i++)
            {
                vetor[i] = bd.QueryString("nome", "Background", "id", (i + 1).ToString());
            }
            for (int i = 0; i < x.Length; i++)
            {
                if (nome.text == vetor[i])
                {
                    contemLista = true;
                }
            }
         

        }
        
        }
    }
    */
}
