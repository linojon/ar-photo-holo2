using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ImageTool : MonoBehaviour, IInputClickHandler {
    public GameObject imageMenu;

    public void OnInputClicked(InputClickedEventData eventData) {
        BeginEdit();
    }

    private void BeginEdit() {
        imageMenu.SetActive(true);
    }

    private void DoneEdit() {
    }
}
