using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class FrameTool : MonoBehaviour, IInputClickHandler {
    public GameObject frameMenu;

    public void OnInputClicked(InputClickedEventData eventData) {
        BeginEdit();
    }

    private void BeginEdit() {
        frameMenu.SetActive(true);
    }

    private void DoneEdit() {
    }
}