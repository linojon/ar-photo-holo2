using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureController : MonoBehaviour {
    public Transform framedImage;
    public GameObject toolbar;
    public GameObject imageMenu;
    public GameObject frameMenu;

    private Transform frameSpawnPoint;
    private Renderer imageRenderer;

    private Vector3 startPosition;
    private Vector3 startScale;
    private Quaternion startRotation;
    private Texture startTexture;
    private GameObject startFrame;

    void Start() {
        frameSpawnPoint = framedImage.Find("FrameSpawn");

        Transform image = framedImage.Find("Image");
        imageRenderer = image.gameObject.GetComponent<Renderer>();

        BeginEdit();
    }

    public void Execute(PictureCommand command) {
        switch (command) {
            case PictureCommand.ADD:
                AddPicture();
                break;

            case PictureCommand.EDIT:
                BeginEdit();
                break;

            case PictureCommand.DONE:
                DoneEdit();
                break;

            case PictureCommand.CANCEL:
                CancelEdit();
                break;

            //case PictureCommand.MOVE:
            //    break;

            case PictureCommand.SCALE:
                break;

            case PictureCommand.DELETE:
                DeletePicture();
                break;

            case PictureCommand.IMAGE:
                OpenImageMenu();
                break;

            case PictureCommand.FRAME:
                OpenFrameMenu();
                break;
        }
    }

    //----------

    private void AddPicture() {
        toolbar.SetActive(false);
        GameController.instance.CreateNewPicture();
    }

    private void BeginEdit() {
        startPosition = transform.localPosition;
        startScale = transform.localScale;
        startRotation = transform.localRotation;
        startTexture = imageRenderer.material.mainTexture;
        startFrame = Instantiate(GetCurrentFrame());
        startFrame.SetActive(false);

        toolbar.SetActive(true);
    }

    private void DoneEdit() {
        Destroy(startFrame);
        toolbar.SetActive(false);
    }

    private void CancelEdit() {
        transform.localPosition = startPosition;
        transform.localScale = startScale;
        transform.localRotation = startRotation;
        imageRenderer.material.mainTexture = startTexture;
        CreateFrame(startFrame);

        toolbar.SetActive(false);
    }

    private void DeletePicture() {
        Destroy(gameObject);
    }

    private void OpenImageMenu() {
        imageMenu.SetActive(true);
    }

    private void OpenFrameMenu() {
        frameMenu.SetActive(true);
    }

    //-----------
    public void SetTexture(Texture texture) {
        imageRenderer.material.mainTexture = texture;
        framedImage.transform.localScale = TextureToScale(texture);
    }

    public void SetFrame(GameObject frameGameObject) {
        GameObject currentFrame = GetCurrentFrame();
        if (currentFrame != null) {
            Destroy(currentFrame);
        }
        CreateFrame(frameGameObject);
    }

    //The application could be optimized by using object pooling
    private GameObject CreateFrame(GameObject frameGameObject) {
        //Creates a new gameobject with the same position and rotation as FrameSpawnPoint. It also sets the frame as a child
        //of FrameSpawnPoint. 
        GameObject newFrame = Instantiate(frameGameObject, frameSpawnPoint.position, frameSpawnPoint.rotation, frameSpawnPoint);
        newFrame.transform.localScale = Vector3.one;
        return newFrame;
    }

    private GameObject GetCurrentFrame() {
        Transform currentFrame = frameSpawnPoint.GetChild(0);
        if (currentFrame != null) {
            return currentFrame.gameObject;
        }
        return null;
    }


    private Vector3 TextureToScale(Texture texture) {
        Vector3 scale = Vector3.one;
        if (texture.width > texture.height) {
            scale.y = (texture.height * 1.0f) / texture.width;
        } else {
            scale.x = (texture.width * 1.0f) / texture.height;
        }
        return scale;
    }

}
