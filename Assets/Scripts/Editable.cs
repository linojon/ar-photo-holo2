using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Editable : MonoBehaviour, IInputClickHandler {
    public GameObject picture;
    private PictureController pictureController;

    void Start() {
        pictureController = picture.GetComponent<PictureController>();
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        BeginEdit();
    }

    private void BeginEdit() {
        pictureController.BeginEdit();
    }
}
