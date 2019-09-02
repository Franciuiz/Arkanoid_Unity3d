using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidade;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        Vector2 v = r.velocity;
        v.x = Input.GetAxis("Horizontal") * velocidade;
        r.velocity = v;
    }
}
