using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AnalogStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [System.Serializable]
    public class FloatUnityEvent : UnityEvent<float> { }
    [System.Serializable]
    public class Vector2UnityEvent : UnityEvent<Vector2> { }


    public RectTransform stick;

    public float radius = 100;

    public FloatUnityEvent OnHorizontalChanged;
    public FloatUnityEvent OnVerticalChanged;
    public Vector2UnityEvent OnChanged;

    public Vector2 multiplier = new Vector2(1, 1);

    private void OnEnable()
    {
        stick.gameObject.SetActive(false);
    }

    //quando toca no componente
    public void OnPointerDown(PointerEventData eventData)
    {
        SetStickPosition(eventData.position);
        stick.gameObject.SetActive(true);
    }

    //quando começa a arrastar
    public void OnBeginDrag(PointerEventData eventData)
    {
        SetStickPosition(eventData.position);
        stick.gameObject.SetActive(true);
    }

    //cada vez que arrasta
    public void OnDrag(PointerEventData eventData)
    {
        SetStickPosition(eventData.position);
    }
    
    //quando o touch termina
    public void OnPointerUp(PointerEventData eventData)
    {
        stick.gameObject.SetActive(false);
        SetInput(new Vector2(0, 0));
    }




    void SetStickPosition(Vector2 touchPosition)
    {
        var rect = this.transform as RectTransform;
        
        //calcular posição do mouse em relação ao componente atual
        Vector2 localPoint = new Vector2();
        RectTransformUtility
            .ScreenPointToLocalPointInRectangle(
                rect, 
                touchPosition, 
                null, 
                out localPoint);
        
        //limitar a posição em relação ao raio
        if (localPoint.magnitude > radius)
            localPoint = localPoint.normalized * radius;

        //mudar posição do stick
        stick.anchoredPosition = localPoint;

        //calcular o input
        Vector2 input = new Vector2();

        //quando mais proximo do raio, maior o input
        if (localPoint != Vector2.zero)
            input = localPoint / radius;

        SetInput(input);
    }


    void SetInput(Vector2 input)
    {
        OnHorizontalChanged.Invoke(input.x * multiplier.x);
        OnVerticalChanged.Invoke(input.y * multiplier.y);
        OnChanged.Invoke(input);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
