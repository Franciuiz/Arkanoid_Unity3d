using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandom : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] listaEfeitos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "paleta")
        {
            //var pos = new Vector3(x, y, 0);

            int sorteiaEfeitos = Random.Range(0, listaEfeitos.Length);

            if(sorteiaEfeitos == 0)
            {
                GameObject bola = GameObject.FindGameObjectWithTag("bola");

                bola.GetComponent<Rigidbody2D>();

                //bola.velocity = bola.velocity.normalized * velocidade;

                //r = GetComponent<Rigidbody2D>();
                //r.velocity = r.velocity.normalized * velocidade;
            }
            
        }
    }
}
