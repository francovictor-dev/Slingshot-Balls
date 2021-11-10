using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    public Text bonusText;

    private int ptBonus;
    
    private int timer;
    private int timerMax;

    bool startTime = false;
    bool reset = false;
    
    private int touchLimiteBola;
    private bool colisaoBolas;

    private GerarBolas gameOver;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        timerMax = 1;
        ptBonus = 0;
        touchLimiteBola = 0;
        colisaoBolas = false;
        //bonusText = GameObject.Find("Canvas/Bonus").GetComponent<Text>();
        //bonusText = this.GetComponent<Text>();
        gameOver = GameObject.Find("Main Camera").GetComponent<GerarBolas>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTimerMax(ptBonus);
        CondicaoBola();
        BeginEndBonus();
        GameOver(gameOver.GetGameOver());
        //mostrar o valor do bonus na tela
        bonusText.text = ptBonus.ToString();
    }

    void GameOver(bool gameOver)
    {
        if (gameOver)
        {
            startTime = false;
            ptBonus = 0;
            timer = 0;
        }
    }

    //método para colocar determinar o inicio e fim do bonus 
    private void BeginEndBonus()
    {
        if (startTime == true)
        {
            timer += 1;
            if (timer == timerMax)
            {
                ptBonus = 0;
                timer = 0;
                startTime = false;
            }

        }
        //a cada vez que houver reset o tempo é resetado
        if (reset == true)
        {
            timer = 0;
            reset = false;
        }
    }

    //método para definir o máximo que o tempo do bonus deve ficar na tela
    private void SetTimerMax(int ptBonus)
    {
        //a cada mudança de valor do ptBonus o tempo máximo vai diminuindo 
        switch (ptBonus)
        {
            case 2: timerMax = 420;
                break;
            case 4: timerMax = 390;
                break;
            case 6: timerMax = 360;
                break;
            case 8: timerMax = 330;
                break;
            case 10: timerMax = 300;
                break;
            case 12: timerMax = 270;
                break;
            case 14: timerMax = 240;
                break;
            case 16: timerMax = 210;
                break;
            case 18: timerMax = 180;
                break;
            case 20: timerMax = 150;
                break;
            default: timerMax = 0;
                break;
        }
    }

    //método para adicionar o bonus, e determinar o o máximo que o bonus pode ter 
    public void AddPtBonus(int ptBonus)
    {
        //máximo do bonus
        if(this.ptBonus == 20)
        {
            this.ptBonus = 20;
        }
        else
        {
            this.ptBonus += ptBonus;
        }
        
        //começa quando bonus sair do 0
        if (this.ptBonus == 2)
        {
            startTime = true;
        }
        //toda vez que o valor do bonus for modificado ocorrerá o reset de tempo do bonus
        else if(this.ptBonus > 2)
        {
            reset = true;
        }

    }
    //método controla o limite de bonus onde esse bonus sera perdido no momento em que o jogador 
    //tocar mais de uma vez na bola. E será extendido caso tenha colisao de bolas
    void CondicaoBola()
    {
        if (touchLimiteBola == 2)
        {
            ptBonus = 0;
            timer = 0;
            startTime = false;
            touchLimiteBola = 0;
        }
        //quando tiver colisao entre bolas o bonus se extenderá 
        if (colisaoBolas == true)
        {
            touchLimiteBola = 0;
            colisaoBolas = false;
        }
    }

    //métodos publicos
    public void SetTouchLimiteBola(int x)
    {
        touchLimiteBola += x;
    }

    public void SetColisaoBolas(bool colisao)
    {
        colisaoBolas = colisao;
    }

    public int GetPtBonus()
    {
        return ptBonus;
    }

    public bool GetStartTime()
    {
        return startTime;
    }

    public int GetTimer()
    {
        return timer;
    }

    public int GetTimerMax()
    {
        return timerMax;
    }
}
