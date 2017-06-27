using UnityEngine;

public class ImageMenu : PictureMenu {

    public Texture[] ImageTextures;
    [SerializeField]
    private ClickableObject nextButton;
    [SerializeField]
    private ClickableObject previousButton;

    //The items per page is calculated by the number of images shown at start.
    private int indexOffset;

    public override void BeginEdit() {
        UpdateImages();
    }

    public void SubscribeClickableObjects() {
        base.SubscribeClickableObjects();
        previousButton.OnObjectClicked.AddListener(PreviousPage);
        nextButton.OnObjectClicked.AddListener(NextPage);
    }

    public override void ObjectClicked(GameObject clickedGameObject) {
        Texture texture = clickedGameObject.GetComponent<Renderer>().material.mainTexture;
        picture.SetTexture(texture);
        DoneEdit(); // close ImageMenu when one pic is picked
    }


    private void UpdateImages() {
        for (int i = 0; i < clickableObjects.Length; i++) {
            //Sets the texture for the images based on index
            clickableObjects[i].GetComponent<Renderer>().material.mainTexture = ImageTextures[i + indexOffset];
        }
    }

    private void NextPage() {
        if ((indexOffset + clickableObjects.Length) < ImageTextures.Length) {
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
