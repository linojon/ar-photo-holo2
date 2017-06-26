using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class AddTool : MonoBehaviour, IInputClickHandler {
    public GameObject toolbar;

    public void OnInputClicked(InputClickedEventData eventData) {
        toolbar.SetActive(false);
        GameController.instance.CreateNewPicture();
    }

}
