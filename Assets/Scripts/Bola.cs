using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidade;

    Rigidbody2D r;

    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        
        //starta a bolinha numa direçao e angulo random
        r.velocity = new Vector2(Random.Range(-5, 5), velocidade);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        r = GetComponent<Rigidbody2D>();
        r.velocity = r.velocity.normalized * velocidade;

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
    }

}
