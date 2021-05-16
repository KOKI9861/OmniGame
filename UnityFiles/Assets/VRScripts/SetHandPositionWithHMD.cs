using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHandPositionWithHMD : MonoBehaviour
{
    public Transform body;
    public Transform handRight;
    public Transform handLeft;

    public Transform controllerRight;
    public Transform controllerLeft;
    public Transform hmd;
    public Transform omni;

    ControllerSettings controllerSettings;

    void Start() {
        controllerSettings = Resources.Load<ControllerSettings>("ControllerSettings");        
    }

    void Update() {
        handRight.localRotation = controllerRight.rotation;// * Quaternion.Inverse(controllerSettings.centerRot);
        handLeft.localRotation = controllerLeft.rotation;// * Quaternion.Inverse(controllerSettings.centerRot);
        body.rotation = hmd.rotation*Quaternion.Euler(0, -90, 0);//new Quaternion(hmd.rotation.x,hmd.rotation.y,hmd.rotation.z,hmd.rotation.w);// * Quaternion.Inverse(controllerSettings.centerRot);
        body.position = new Vector3(hmd.position.x, hmd.position.y, hmd.position.z);
        handRight.localPosition = controllerRight.position - controllerSettings.centerPos;// + hmd.position;
        handLeft.localPosition = controllerLeft.position - controllerSettings.centerPos;// + hmd.position;
        Debug.Log("Debug");
        Debug.Log(body.position+":"+body.rotation);
        Debug.Log(controllerRight.position+":"+controllerRight.localPosition);
        Debug.Log(handRight.position+":"+handRight.localPosition);
        Debug.Log(controllerRight.rotation+":"+controllerRight.localRotation);
        Debug.Log(handRight.rotation+":"+handRight.localRotation);
    }

    public void UpdateSetting() {
        controllerSettings = Resources.Load<ControllerSettings>("ControllerSettings");
    }
}
