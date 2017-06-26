using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureController : MonoBehaviour {

    private Renderer imageRenderer;

    void Start() {
        Transform image = gameObject.transform.Find("Image");
        if (image != null) {
            imageRenderer = image.gameObject.GetComponent<Renderer>();
        } else {
            Debug.Log("PictureController does not have child Image object");
        }
    }

    public void SetTexture(Texture texture) {
        imageRenderer.material.mainTexture = texture;
    }
}
