using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuxadorColisao : MonoBehaviour
{
    public Collider2D puxador;
    public Collider2D limite;

    public Transform seta2;

    public float mag;

    //int ang = 0;
    private Vector2 direcao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * AngleAxis: Determinar uma rotação baseado no angulo do vetor
        ang = (ang == 360) ?  ang = 1 : ang += 10 ;
        seta2.transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
        */

        /*
         * Angle: Soma a diferença de rotação entre 2 pontos
        float angle = Quaternion.Angle(transform.rotation, seta2.transform.rotation);
        Debug.Log(angle);
        */

        //print(Quaternion.Dot(transform.rotation, seta2.transform.rotation));

        /*Euler: Parecido AngleAxis mas um pouco mais simples
        * ang = (ang == 360) ? ang = 1 : ang += 10;
        transform.rotation = Quaternion.Euler(0, 0, ang);
        */
        //print(transform.rotation.eulerAngles);

        //mag = transform.position.magnitude;
        
        direcao = transform.position - seta2.position;

        /* Vector2.Angle mostra o angulo entre 2 vetores a partir de um lado (direito, cima, esquerdo e baixo)
         * 
        mag = Vector2.Angle(Vector2.up, direcao);
        print(mag);

        mag = Vector2.SignedAngle(Vector2.right, direcao);
        print(mag);
        */

        /* RotateAround faz rotacao em torno de um ponto
         * 
        transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 60), 20 * Time.deltaTime );
        */

        /* Discance pega o calculo entre 2 pontos. Diferente da diferença feito por vetores, onde
         * a diferença é feito por coordenadas
        mag = Vector2.Distance(transform.position, seta2.position);
        print(mag + " " + direcao);
        */

        // uma das maneiras de mudar angulo de vetores
        //Vector2 direcao2 = Quaternion.Euler(0, 0, 30 * 2) * direcao;
        //print(direcao2 + " " + direcao);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Puxador")
        {
            Physics2D.IgnoreCollision(limite, puxador, true);
        }
    }
}
