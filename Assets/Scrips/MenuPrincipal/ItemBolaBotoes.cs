using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBolaBotoes : MonoBehaviour
{
    public Text botaoEscolher;
    public Text nome;
    public Unity.VectorGraphics.SVGImage imagem;

    private DataBase bd;
    private GerarItemBola gib;

    // Start is called before the first frame update
    void Awake()
    {
        //encontrar Object que tenha o script de Banco de Dados
        bd = GameObject.Find("DataBaseManager").GetComponent<DataBase>();
        //variavel para ter acesso a script GerarItem
        gib = GameObject.Find("Canvas/PainelItem/Itens/Bolas/Lista").GetComponent<GerarItemBola>();
    }
    // Update is called once per frame
    /*
    void Update()
    {
        //ao aparecer a painel dos itens o codigo buscará 
        //na pasta Resource o objeto respectivamente ao nome do objeto
        //e pega o sprite do objeto para ser usado no item
        GameObject sprite = (GameObject)GameObject.Instantiate
           (Resources.Load("Bola/" + nome.GetComponent<Text>().text));

        imagem.sprite = sprite.GetComponent<SpriteRenderer>().sprite;
        
    }
    */

    public void Selecionar()
    {
        //vetor x para consultar a quantidade de bola o jogador tem habilitado
        int[] x = new int[bd.QueryInt("count(id)", "Bola")];
        //laço com a quantidade maximo da variavel x
        for (int i = 0; i < x.Length; i++)
        {
            //update para todos as bolas para o campo 'escolhido' ser do estado 0, ou seja
            //não escolhido
            bd.UpdateBd("Bola", "escolhido", "0", "id", (i + 1).ToString());
        }
        //com esse update escolha somente uma bola coerente ao botao apertado
        bd.UpdateBd("Bola", "escolhido", "1", "nome", nome.GetComponent<Text>().text);
        string escolhidoNome = nome.GetComponent<Text>().text;
        gib.ResetarTabela(escolhidoNome, true);
    }
}
