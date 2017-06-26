using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class DeleteTool : MonoBehaviour, IInputClickHandler {
    public GameObject picture;

    public void OnInputClicked(InputClickedEventData eventData) {
        Destroy(picture);
    }
}
