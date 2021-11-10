using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFundoBotoes : MonoBehaviour
{
    private Unity.VectorGraphics.SVGImage imagem;
    private GameObject janelaBackground;
    private DataBase bd;
    private GerarItemFundo gif;

    public Text nome;
    public GameObject item;
    public Text botaoEscolher;
    // Start is called before the first frame update

    void Start()
    {
        //variavel para receber o objeto inativo da janela de background 
        janelaBackground = GameObject.Find("Canvas").transform.Find("JanelaBackground").gameObject;
        //encontrar Object que tenha o script de Banco de Dados
        bd = GameObject.Find("DataBaseManager").GetComponent<DataBase>();
        //variavel para ter acesso a script GerarItem
        gif = GameObject.Find("Canvas/PainelItem/Itens/Fundos/Lista").GetComponent<GerarItemFundo>();
    }

    public void Selecionar()
    {
        //vetor x para consultar a quantidade de background o jogador tem habilitado
        int[] x = new int[bd.QueryInt("count(id)", "Background")];
        //laço com a quantidade maximo da variavel x
        for(int i = 0; i < x.Length; i++)
        {
            //update para todos os background para o campo 'escolhido' ser do estado 0, ou seja
            //não escolhido
            bd.UpdateBd("Background", "escolhido", "0", "id", (i+1).ToString());
        }
        //com esse update escolha somente um background coerente ao botao apertado
        bd.UpdateBd("Background", "escolhido", "1", "nome", nome.GetComponent<Text>().text);

        string escolhidoNome = nome.GetComponent<Text>().text;
        gif.ResetarTabela(escolhidoNome, true);
    }

    public void MostrarJanelaBackground()
    {
        //definir janela como ativo
        janelaBackground.SetActive(true);
        //variavel para receber o componente de Sprite da imagem
        imagem = GameObject.Find("Canvas/JanelaBackground/ImageSprite").GetComponent<Unity.VectorGraphics.SVGImage>();
        //buscando o objeto a partir do nome do item escolhido 
        GameObject sprite = (GameObject) GameObject.Instantiate
            (Resources.Load("Imagem/" + nome.GetComponent<Text>().text));

        //Sprite da imagem receber o sprite referente ao item escolhido para ser visto
        imagem.sprite = sprite.GetComponent<SpriteRenderer>().sprite;
    }
}
