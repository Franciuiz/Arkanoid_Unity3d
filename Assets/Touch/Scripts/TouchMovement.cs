using GameBooster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Velocity2D))]
public class TouchMovement : MonoBehaviour
{
    //se cada direção está pressionada
    public bool left { get; set; }
    public bool right { get; set; }
    public bool up { get; set; }
    public bool down { get; set; }
    
    //velocidade desejada
    public Vector2 speed = new Vector2(5, 5);

    //componente Velocity2D
    Velocity2D vel;

    //alteraçao do script original linha 22, 35, 36 e 47 ate 56
    bool congelado = true;

    void Start()
    {
        vel = GetComponent<Velocity2D>();
    }
    
    void Update()
    {
        Vector2 input = new Vector2(0, 0);

        //true passa, false n passa
        //converte left|right em -1,0,1
        if (congelado && left && !right) input.x = -1;
        if (congelado && !left && right) input.x = 1;

        //converte down|up em -1,0,1
        if (down && !up) input.y = -1;
        if (!down && up) input.y = 1;

        //passa os valores pro Velocity
        vel.velocityX = speed.x * input.x;
        vel.velocityY = speed.y * input.y;
    }

    public void CongelarTouch()
    {
        congelado = false;
        Invoke("Descongelar", 2);
        Debug.Log("Congelou a paleta por um tempo");
    }

    void Descongelar()
    {
        congelado = true;
    }
}
