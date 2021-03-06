﻿using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;

public class MoveTool : MonoBehaviour, IInputClickHandler {
    private PictureController picture;

    private bool isEditing = false;

    private SpatialMappingManager spatialMapping;
    private Vector3 localOffset;
    private Vector3 originaButtonScale;

    private float upNormalThreshold = 0.9f;

    void Start() {
        picture = GetComponentInParent<PictureController>();

        spatialMapping = SpatialMappingManager.Instance;
        localOffset = transform.position - picture.transform.position;
        originaButtonScale = transform.localScale;
    }

    void Update() {
        if (isEditing) {
            Vector3 headPosition = Camera.main.transform.position;
            Vector3 gazeDirection = Camera.main.transform.forward;
            int layerMask = 1 << spatialMapping.PhysicsLayer;
            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 30.0f, layerMask)) {
                picture.transform.position = hitInfo.point - localOffset; // keep tool in gaze
                Vector3 surfaceNormal = hitInfo.normal;
                if (Mathf.Abs(surfaceNormal.y) <= (1 - upNormalThreshold)) {
                    picture.transform.rotation = Quaternion.LookRotation(-surfaceNormal, Vector3.up);
                }
            }
        }
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        Debug.Log("MoveTool: OnInputClicked");
        if (!isEditing) {
            BeginEdit();
        } else {
            DoneEdit();
        }
    }

    public void BeginEdit() {
        if (!isEditing) {
            isEditing = true;
            Debug.Log("MoveTool: drawing meshes");

            spatialMapping.DrawVisualMeshes = true;
            transform.localScale = originaButtonScale * 2.5f;
        }
    }

    public void DoneEdit() {
        if (isEditing) {
            isEditing = false;
            Debug.Log("MoveTool: not drawing meshes");

            spatialMapping.DrawVisualMeshes = false;
            transform.localScale = originaButtonScale;
        }
    }


}
