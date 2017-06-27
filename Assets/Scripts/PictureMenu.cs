using UnityEngine;

public abstract class PictureMenu : MonoBehaviour {
    public ClickableObject[] clickableObjects;

    protected PictureController picture;
    protected GameObject toolbar;

    void Start() {
        SubscribeClickableObjects();
    }

    void OnEnable() {
        Debug.Log("PictureMenu: OnEnable");
        picture = GetComponentInParent<PictureController>();
        toolbar = picture.GetToolbar();
        toolbar.SetActive(false);
        BeginEdit();
    }

    public abstract void BeginEdit();

    public abstract void ObjectClicked(GameObject clickedGameObject);

    public void DoneEdit() {
        Debug.Log("PictureMenu: DoneEdit");
        toolbar.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SubscribeClickableObjects() {
        for (int i = 0; i < clickableObjects.Length; i++) {
            clickableObjects[i].OnClickableObjectClicked.AddListener(ObjectClicked);
        }
    }

}
