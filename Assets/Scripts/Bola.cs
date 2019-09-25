using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidade = 4;
    public GameObject paleta;

    Rigidbody2D r;

    public Text placarValor;
    public float placar = 0F;

    public Text abatesValor;
    public int abates = 0;
    public GameObject Canvas_GameOver = null;
    public GameObject Texto_Venceu = null;
    public GameObject Texto_GameOver = null;

    //ver script Gerar Alvos No Start para numero static de alvos
    private int numeroDeAlvos = 32;

    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        
        //starta a bolinha numa direçao e angulo random
        r.velocity = new Vector2(Random.Range(-5, 5), velocidade);
    }

    // Update is called once per frame
    private void Update()
    {
        CheckGanhou();
        placarValor.text = placar.ToString();
        abatesValor.text = abates.ToString();
    }

    void FixedUpdate()
    {

        r = GetComponent<Rigidbody2D>();
        r.velocity = r.velocity.normalized * velocidade;

        if (r.velocity.x == 0)
        {
            Vector2 v = r.velocity;
            v.x = Random.Range(-1, 1);
            r.velocity = v;

            Debug.Log("x é 0");
        }
        if (r.velocity.y == 0)
        {
            /*Vector2 v = r.velocity;
            v.y = Random.Range(-1, 1);
            r.velocity = v;*/

            Debug.Log("y é 0");

            r.gravityScale = 1;
            
        }
        else
        {
            r.gravityScale = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //adiciona angulos diferentes a bolinha de acordo com o lado que bater na paleta
        if(collision.gameObject.tag == "paleta")
        {
            float x = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * velocidade;
        }

        if(collision.gameObject.tag == "alvos")
        {
            abates++;
            placar += 5;
        }

    }

    void CheckGanhou()
    {
        if (abates == numeroDeAlvos)
        {
            Debug.Log("Ganhou !!!!!!");
            Canvas_GameOver.SetActive(true);
            Texto_Venceu.SetActive(true);

            //seta a bola como desabilitado
            gameObject.SetActive(false);
        }
    }

    //script bolaController lol
    public void PlacarBonus()
    {
        placar += 50;
        Debug.Log("Bonus de placar adicionado !");
    }

    public void PlacarPenalidade()
    {
        placar -= 50;
        Debug.Log("Penalidade de placar adicionado!");
    }
    public void AumentarVelocidade()
    {
        this.velocidade += 2;
        Debug.Log("Aumentou a velocidade!");
    }

    public void DiminuirVelocidade()
    {
        this.velocidade -= 2;
        Debug.Log("Diminuiu a velocidade!");
    }

    public void DefaultVelocidade()
    {
        this.velocidade = 4;
        Debug.Log("Velocidade alterada para o padrão!");
    }

    public void CongelarBola()
    {
        //Isto é gambiarra ? lol
        GetComponent<Rigidbody2D>().simulated = false;
        Invoke("Descongelar", 2);
        Debug.Log("Congelou a bola por um tempo");
    }

    void Descongelar()
    {
        GetComponent<Rigidbody2D>().simulated = true;
    }

}
