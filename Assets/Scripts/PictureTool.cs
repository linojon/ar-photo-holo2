using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class PictureTool : MonoBehaviour, IInputClickHandler {
    public PictureCommand command;

    protected PictureController picture;
    protected GameObject toolbar;

    void Start() {
        picture = GetComponentInParent<PictureController>();
        toolbar = picture.GetToolbar();
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        picture.Execute(command);
    }
}
