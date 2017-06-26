using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class FrameMenu : MonoBehaviour {
    public GameObject picture;
    public GameObject toolbar;
    private bool isEditing = false;

    public ClickableObject[] FrameClickableObjects;

    private PictureController pictureController;

    private void Start() {
        pictureController = picture.GetComponent<PictureController>();
        if (pictureController == null) {
            Debug.Log("ImageMenu: Picture require PictureController component");
        }
    }

    void OnEnable() {
        Debug.Log("FrameMenu: OnEnable");
        BeginEdit();
    }

    public void BeginEdit() {
        SubscribeClickableObjects();
        toolbar.SetActive(false);
    }

    public void DoneEdit() {
        Debug.Log("FrameMenu: DoneEdit");
        toolbar.SetActive(true);
        gameObject.SetActive(false);
        // remove listeners ImageClickableObjects ??
    }

    private void SubscribeClickableObjects() {
        for (int i = 0; i < FrameClickableObjects.Length; i++) {
            FrameClickableObjects[i].OnClickableObjectClicked.AddListener(ObjectClicked);
        }
    }

    void ObjectClicked(GameObject clickedGameObject) {
        pictureController.SetFrame(clickedGameObject);
        DoneEdit(); // close menu when one pic is picked
    }
}

