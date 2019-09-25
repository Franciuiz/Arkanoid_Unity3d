using GameBooster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Velocity2D))]
public class AnalogMovement : MonoBehaviour
{
    
    public Vector2 input { get; set; }

    public float speed = 5;

    Velocity2D vel;

    void Start()
    {
        vel = GetComponent<Velocity2D>();
    }

    void Update()
    {
        vel.velocity = input * speed;
        //print(input);
    }
}
