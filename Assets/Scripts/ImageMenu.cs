using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class ImageMenu : MonoBehaviour {
    public GameObject picture;
    public GameObject toolbar;
    private bool isEditing = false;

    public Texture[] ImageTextures;
    public ClickableObject[] ImageClickableObjects;
    [SerializeField]
    private ClickableObject nextButton;
    [SerializeField]
    private ClickableObject previousButton;

    //The items per page is calculated by the number of images shown at start.
    private int indexOffset;

    private PictureController pictureController;

    private void Start() {
        pictureController = picture.GetComponent<PictureController>();
        if (pictureController == null) {
            Debug.Log("ImageMenu: Picture require PictureController component");
        }
    }

    void OnEnable() {
        Debug.Log("ImageMenu: OnEnable");
        BeginEdit();
    }

    public void BeginEdit() {
        SubscribeClickableObjects();
        UpdateImages();
        toolbar.SetActive(false);
    }

    public void DoneEdit() {
        Debug.Log("ImageMenu: DoneEdit");
        toolbar.SetActive(true);
        gameObject.SetActive(false);
        // remove listeners ImageClickableObjects ??
    }

    private void SubscribeClickableObjects() {
        previousButton.OnObjectClicked.AddListener(PreviousPage);
        nextButton.OnObjectClicked.AddListener(NextPage);
        //confirmButton.OnObjectClicked.AddListener(ConfirmImage);

        for (int i = 0; i < ImageClickableObjects.Length; i++) {
            ImageClickableObjects[i].OnClickableObjectClicked.AddListener(ObjectClicked);
        }
    }

    void ObjectClicked(GameObject clickedGameObject) {
        Texture texture = clickedGameObject.GetComponent<Renderer>().material.mainTexture;
        pictureController.SetTexture(texture);
        DoneEdit(); // close ImageMenu when one pic is picked
    }

    private void UpdateImages() {
        for (int i = 0; i < ImageClickableObjects.Length; i++) {
            //Sets the texture for the images based on index
            ImageClickableObjects[i].GetComponent<Renderer>().material.mainTexture = ImageTextures[i + indexOffset];
        }
    }

    private void NextPage() {
        if ((indexOffset + ImageClickableObjects.Length) < ImageTextures.Length) {
            indexOffset++;
        }
        UpdateImages();
    }

    private void PreviousPage() {
        if ((indexOffset - 1) >= 0) {
            indexOffset--;
        }
        UpdateImages();
    }
}
