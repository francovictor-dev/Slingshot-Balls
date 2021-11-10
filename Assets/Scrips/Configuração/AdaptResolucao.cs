using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptResolucao : MonoBehaviour
{
    /*###############################################################################################
    Script faz com que o objeto se adapte ao tamanho da Camera por conta da Resolução do dispositivo
    ################################################################################################*/

    public GameObject obj;

    //tamanho da camera na resolução padrao de 1920x1080
    readonly float padraoHeight = 10f;
    readonly float padraoWidth = 5.625f;
    // Start is called before the first frame update
    void Start()
    {
        //com a regra de 3 o obj adapta o tamanho da camera
        float height = 2f * Camera.main.orthographicSize;
        //largura do tamanho da camera
        float width = height * Camera.main.aspect;
        
        if (obj.CompareTag("Background"))
        {
            //nova medida do obj baseado no tamanho da camera
            float resH = height * obj.transform.localScale.y / padraoHeight;

            float resW = width * obj.transform.localScale.x / padraoWidth;
            //nova medida do obj
            obj.transform.localScale = new Vector2(resW, resH);

        }else if (obj.tag.Contains("Bola"))
        {
            //nova medida do obj baseado no tamanho da camera, no entanto, somente utilizado largura nas 2 medidas do obj
            float resW = width * obj.transform.localScale.x / padraoWidth;
            //nova medida do obj
            obj.transform.localScale = new Vector2(resW, resW);
            
        }
        else if (obj.CompareTag("Coracao"))
        {
            //nova medida do obj baseado no tamanho da camera, no entanto, somente utilizado largura nas 2 medidas do obj
            float resW = width * obj.transform.localScale.x / padraoWidth;
            //nova medida do obj
            obj.transform.localScale = new Vector2(resW, resW);
        }
        else
        {
            //nova medida do obj baseado no tamanho da camera
            float resH = height * obj.transform.localScale.y / padraoHeight;

            float resW = width * obj.transform.localScale.x / padraoWidth;
            //nova medida do obj
            obj.transform.localScale = new Vector2(resW, resH);
        }

    }
}
