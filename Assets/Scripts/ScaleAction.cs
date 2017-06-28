using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class ScaleAction : MonoBehaviour {
    private PictureController picture;
    private Vector3 originaButtonScale;

    private GestureRecognizer gestureRecognizer;

    private Vector3 startGazeDirection;
    private Vector3 startScale;

    void Start() {
        picture = GetComponentInParent<PictureController>();
        originaButtonScale = transform.localScale;

        gestureRecognizer = new GestureRecognizer();
        gestureRecognizer.SetRecognizableGestures(GestureSettings.ManipulationTranslate);

        gestureRecognizer.ManipulationStartedEvent += ScalingStartedEvent;
        gestureRecognizer.ManipulationUpdatedEvent += ScalingUpdatedEvent;
        gestureRecognizer.ManipulationCompletedEvent += ScalingCompletedEvent;
        gestureRecognizer.ManipulationCanceledEvent += ScalingCanceledEvent;


    }

    public void BeginEdit() {
        transform.localScale = originaButtonScale * 2.5f;
        gestureRecognizer.StartCapturingGestures();

    }

    public void DoneEdit() {
        transform.localScale = originaButtonScale;
        gestureRecognizer.StopCapturingGestures();

    }

    private void OnDestroy() {
        gestureRecognizer.StopCapturingGestures();

        gestureRecognizer.ManipulationStartedEvent -= ScalingStartedEvent;
        gestureRecognizer.ManipulationUpdatedEvent -= ScalingUpdatedEvent;
        gestureRecognizer.ManipulationCompletedEvent -= ScalingCompletedEvent;
        gestureRecognizer.ManipulationCanceledEvent -= ScalingCanceledEvent;

    }


    private void ScalingStartedEvent(InteractionSourceKind source, Vector3 position, Ray ray) {
        startGazeDirection = Camera.main.transform.forward;
        startScale = picture.framedImage.transform.localScale;
    }

    private void ScalingUpdatedEvent(InteractionSourceKind source, Vector3 position, Ray ray) {
        Debug.Log("position: " + position + " ray: " + ray);
        float angle = AngleSigned(startGazeDirection, Camera.main.transform.forward, Vector3.up);
        float scale = 1.0f + angle * 0.1f;
        picture.framedImage.transform.localScale = startScale * scale;
    }

    private void ScalingCompletedEvent(InteractionSourceKind source, Vector3 position, Ray ray) {
        Debug.Log("completed event");
        DoneEdit();
    }

    private void ScalingCanceledEvent(InteractionSourceKind source, Vector3 position, Ray ray) {
        Debug.Log("canceled event");
        DoneEdit();
    }

    // Determine the signed angle between two vectors, with normal 'n' as the rotation axis
    private float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n) {
        return Mathf.Atan2(
            Vector3.Dot(n, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
    }
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using HoloToolkit.Unity.InputModule;
//using HoloToolkit.Unity.SpatialMapping;
//using System;

//public class ScaleTool : MonoBehaviour, IInputClickHandler { // IManipulationHandler {

//    private PictureController picture;
//    private bool isEditing = false;
//    private Vector3 startGazeDirection;
//    private Vector3 startScale;

//    private Vector3 buttonStartPosition;

//    void Start() {
//        picture = GetComponentInParent<PictureController>();
//    }


//    public void OnInputClicked(InputClickedEventData eventData) {


//        if (!isEditing) {
//            buttonStartPosition = transform.position;
//            startGazeDirection = Camera.main.transform.forward;
//            startScale = picture.framedImage.transform.localScale;
//            isEditing = true;
//        } else {
//            isEditing = false;
//            transform.position = buttonStartPosition;
//        }

//    }

//    void Update() {
//        if (isEditing) {
//            Vector3 headPosition = Camera.main.transform.position;
//            Vector3 gazeDirection = Camera.main.transform.forward;
//            int layerMask = 1 << SpatialMappingManager.Instance.PhysicsLayer;
//            RaycastHit hitInfo;
//            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 30.0f, layerMask)) {
//                transform.position = hitInfo.point; //move button

//                float angle = AngleSigned(startGazeDirection, Camera.main.transform.forward, Vector3.up);
//                float scale = 1.0f + angle * 0.1f;
//                picture.framedImage.transform.localScale = startScale * scale;
//            }
//        }
//    }
//            //public void OnManipulationStarted(ManipulationEventData eventData) {
//            //    startGazeDirection = Camera.main.transform.forward;
//            //    startScale = picture.framedImage.transform.localScale;
//            //    isEditing = true;
//            //}

//            //public void OnManipulationUpdated(ManipulationEventData eventData) {
//            //    if (isEditing) {
//            //        float angle = AngleSigned(startGazeDirection, Camera.main.transform.forward, Vector3.up);
//            //        float scale = 1.0f + angle * 0.1f;
//            //        picture.framedImage.transform.localScale = startScale * scale;

//            //        Vector3 delta = eventData.CumulativeDelta;
//            //        Debug.Log(delta);
//            //        //float angle = AngleSigned(Vector3.forward, delta, Vector3.up);
//            //        //float scale = 1.0f + angle * 0.1f;
//            //        //picture.framedImage.transform.localScale = startScale * scale;
//            //    }
//            //}

//            //public void OnManipulationCompleted(ManipulationEventData eventData) {
//            //    Debug.Log("OnManimputionCompleted");
//            //    isEditing = false;
//            //}

//            //public void OnManipulationCanceled(ManipulationEventData eventData) {
//            //    Debug.Log("OnManimputionCanceled");
//            //    isEditing = false;
//            //}




//    /// Determine the signed angle between two vectors, with normal 'n' as the rotation axis
//    private float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n) {
//        return Mathf.Atan2(
//            Vector3.Dot(n, Vector3.Cross(v1, v2)),
//            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
//    }


//}
