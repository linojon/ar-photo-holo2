using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;
using System;

public class ClickableObjectEvent : UnityEvent<GameObject> { }

public class ClickableObject : MonoBehaviour, IInputClickHandler {

    public ClickableObjectEvent OnClickableObjectClicked = new ClickableObjectEvent();
    public UnityEvent OnObjectClicked = new UnityEvent();

    void Start () {
        if (GetComponent<Collider>() == null) {
            Debug.Log("ClickableObject " + gameObject.name + " does not have a collider and the click event won't be sent");
        }
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        OnClickableObjectClicked.Invoke(gameObject);
        OnObjectClicked.Invoke();
    }
}
