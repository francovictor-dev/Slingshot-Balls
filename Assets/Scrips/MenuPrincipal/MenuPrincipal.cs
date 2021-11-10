using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject painelConfiguracao;
    public GameObject painelInstrucoes;
    public GameObject painelItens;
    public GameObject painelConquistas;
    public GameObject painelShop;
    public GameObject painelCreditos;
    public GameObject painelTabela;
    public GameObject opcaoFundos;
    public GameObject opcaoMusicas;
    public GameObject opcaoEspeciais;
    public GameObject janelaBackground;
    public GameObject pontosItens;
    public GameObject recordItens;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //---------------Opções menu principal----------------------
    public void ComecarJogo(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExibirConfiguracao(bool mostrar)
    {
        painelConfiguracao.SetActive(mostrar);
    }

    public void ExibirItens(bool mostrar)
    {
        painelItens.SetActive(mostrar);
    }

    public void ExibirInstrucoes(bool mostrar)
    {
        painelInstrucoes.SetActive(mostrar);
    }

    public void ExibirConquistas(bool mostrar)
    {
        painelConquistas.SetActive(mostrar);
    }

    public void ExibirShop(bool mostrar)
    {
        painelShop.SetActive(mostrar);
    }

    public void ExibirTabela(bool mostrar)
    {
        painelTabela.SetActive(mostrar);
    }

    public void ExibirCreditos(bool mostrar)
    {
        painelCreditos.SetActive(mostrar);
    }
    //---------------Opções Itens-----------------------------
    public void ExibirFundos(bool fundos)//, bool musicas, bool especiais)
    {
        opcaoEspeciais.SetActive(false);
        opcaoMusicas.SetActive(false);
        opcaoFundos.SetActive(fundos);
    }

    public void ExibirMusicas()//, bool musicas, bool especiais)
    {
        opcaoEspeciais.SetActive(false);
        opcaoMusicas.SetActive(true);
        opcaoFundos.SetActive(false);
    }

    public void ExibirEspeciais(bool especiais)//, bool musicas, bool especiais)
    {
        opcaoEspeciais.SetActive(especiais);
        opcaoMusicas.SetActive(false);
        opcaoFundos.SetActive(false);
    }
    //---------------Janela de Background-----------------------------
    public void ExibirJanelaBackground(bool mostrar)
    {
        janelaBackground.SetActive(mostrar);
    }
}
