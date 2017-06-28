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
    protected Animator animator;

    void Start () {
        animator = GetComponent<Animator>();
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        if (animator != null) {
            animator.SetTrigger("Click");
        }
        OnClickableObjectClicked.Invoke(gameObject);
        OnObjectClicked.Invoke();
    }
}
