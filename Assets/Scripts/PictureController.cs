using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureController : MonoBehaviour {
    public GameObject toolbar;
    public Transform frameSpawnPoint;

    private Renderer imageRenderer;

    private Vector3 startPosition;
    private Vector3 startScale;
    private Quaternion startRotation;
    private Texture startTexture;
    private GameObject startFrame;

    void Start() {
        Transform image = gameObject.transform.Find("Image");
        if (image != null) {
            imageRenderer = image.gameObject.GetComponent<Renderer>();
        } else {
            Debug.Log("PictureController does not have child Image object");
        }
        // find toolbar?
    }

    public void SetTexture(Texture texture) {
        imageRenderer.material.mainTexture = texture;
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

    // SetPosition

    public void BeginEdit() {
        startPosition = transform.localPosition;
        startScale = transform.localScale;
        startRotation = transform.localRotation;
        startTexture = imageRenderer.material.mainTexture;
        startFrame = Instantiate(GetCurrentFrame());
        startFrame.SetActive(false);

        toolbar.SetActive(true);
    }

    public void DoneEdit() {
        Destroy(startFrame);
        toolbar.SetActive(false);
    }

    public void CancelEdit() {
        transform.localPosition = startPosition;
        transform.localScale = startScale;
        transform.localRotation = startRotation;
        imageRenderer.material.mainTexture = startTexture;
        CreateFrame(startFrame);

        toolbar.SetActive(false);
    }

    private GameObject GetCurrentFrame() {
        Transform currentFrame = frameSpawnPoint.GetChild(0);
        if (currentFrame != null) {
            return currentFrame.gameObject;
        }
        return null;
    }
}
