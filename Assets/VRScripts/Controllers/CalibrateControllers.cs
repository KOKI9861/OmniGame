using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalibrateControllers : ActionObject
{
    Transform[] controllerTransforms = new Transform[2];
    float[] nowTrigger = new float[2]{0.0f, 0.0f};
    ControllerSettings controllerSettings;

    public bool finishCalibrate = false; 
    public GameObject centerCube;
    public Transform hmdCamera;

    public void Start() {
        controllerSettings = Resources.Load<ControllerSettings>("ControllerSettings");
        controllerSettings.centerPos = new Vector3();
        controllerSettings.centerRot = new Quaternion(0,0,0,1);
        controllerSettings.hmdRot = new Quaternion(0,0,0,1);
    }

    public void Update() {
        if (!finishCalibrate && nowTrigger[0] == 1.0f && nowTrigger[1] == 1.0f) {
            Vector3 posRight = controllerTransforms[0].position;
            Vector3 posLeft = controllerTransforms[1].position;
            Vector3 posCenter = (posRight + posLeft) * 0.5f;
            controllerSettings.centerPos = posCenter;
            posRight.y -= 1.0f;
            posLeft.y -= 1.0f;
            Vector3 normal = Vector3.Cross((posLeft - posCenter).normalized, (posRight - posCenter).normalized);
            controllerSettings.centerRot = Quaternion.LookRotation(normal);
            controllerSettings.hmdRot.y = hmdCamera.rotation.y;

            Debug.Log("Calibrated!");
            Debug.Log(controllerTransforms[0].position+":"+controllerTransforms[0].localPosition);
            Debug.Log(controllerTransforms[1].position+":"+controllerTransforms[1].localPosition);
            Debug.Log(normal);
            Debug.Log(controllerSettings.centerPos);
            Debug.Log(controllerSettings.centerRot);
            centerCube.transform.position = controllerSettings.centerPos;
            centerCube.transform.rotation = controllerSettings.centerRot;
            
            // finishCalibrate = true;
            // SceneManager.LoadScene("Menu");
        }
    }

    protected override void TriggerTouchDown(float x, params object[] args){
        if (do_log) Debug.Log(args[0] + " トリガーを浅く引いた:" + x);

        if (args[0].Equals("Controller (right)")) {
            nowTrigger[0] = x;
            controllerTransforms[0] = (Transform)args[1];
        } else if (args[0].Equals("Controller (left)")) {
            nowTrigger[1] = x;
            controllerTransforms[1] = (Transform)args[1];
        }
    }

}
