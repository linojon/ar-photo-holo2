using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ScaleTool : MonoBehaviour, IInputClickHandler {

    public void OnInputClicked(InputClickedEventData eventData) {
        Debug.Log("ScaleTool: OnInputClicked");
        GetComponent<ScaleAction>().BeginEdit();
    }
}