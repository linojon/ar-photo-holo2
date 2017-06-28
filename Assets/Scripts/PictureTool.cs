using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class PictureTool : MonoBehaviour, IInputClickHandler {
    public PictureCommand command;

    protected PictureController picture;
    protected Animator animator;

    void Start() {
        picture = GetComponentInParent<PictureController>();
        animator = GetComponent<Animator>();
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        if (animator != null) {
            animator.SetTrigger("Click");
        }
        picture.Execute(command);
    }
}
