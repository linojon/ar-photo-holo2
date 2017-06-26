using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class CancelTool : MonoBehaviour, IInputClickHandler {

    public PictureController picture;

    public void OnInputClicked(InputClickedEventData eventData) {
        picture.CancelEdit();
    }
}
