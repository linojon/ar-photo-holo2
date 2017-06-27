using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class PictureTool : MonoBehaviour, IInputClickHandler {
    public PictureCommand command;

    protected PictureController picture;

    void Start() {
        picture = GetComponentInParent<PictureController>();
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        picture.Execute(command);
    }
}
