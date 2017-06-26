using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class DoneTool : MonoBehaviour, IInputClickHandler {
    public PictureController picture;

    public void OnInputClicked(InputClickedEventData eventData) {
        picture.DoneEdit();
    }
}
