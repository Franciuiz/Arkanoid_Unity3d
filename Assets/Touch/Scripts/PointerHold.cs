using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//componente que une os eventos PointerDown e PointerUp
public class PointerHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [System.Serializable]
    public class BoolUnityEvent : UnityEvent<bool> { }

    //evento que será chamado passando o estado (true/false) do botão
    public BoolUnityEvent OnChanged;


    //só funciona em componentes Canvas com "RaycastTarget" ativo
    public void OnPointerDown(PointerEventData eventData)
    {
        OnChanged.Invoke(true);
    }

    //só funciona em componentes Canvas com "RaycastTarget" ativo
    public void OnPointerUp(PointerEventData eventData)
    {
        OnChanged.Invoke(false);
    }
}
