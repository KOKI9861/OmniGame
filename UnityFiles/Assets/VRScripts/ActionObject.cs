using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionObject : MonoBehaviour
{

    protected Vector3 velocity;
    protected Vector3 angulerVelocity;

    public bool do_log=false;

    // Use this for initialization
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update(){
    }

    // action = {controllerName, actionName, x, y}, transform = controller's transform
    public void DoAction(string[] action, Transform transform){
        if(do_log) Debug.Log(this.name + " | " + string.Join(", ", action));
        switch (action[1])
        {
            case "trigger_onshallow": // 2
                TriggerTouchDown(float.Parse(action[2]), action[0], transform);
                break;
            case "trigger_ondeep": // 2
                TriggerPressDown(float.Parse(action[2]), action[0], transform);
                break;
            case "trigger_off":
                TriggerUnClicked(action[0], transform);
                break;
            case "trigger_deep": // 2
                TriggerClicked(float.Parse(action[2]), action[0], transform);
                break;
            case "trigger_shallow": // 2
                TriggerTouch(float.Parse(action[2]), action[0], transform);
                break;

            case "glip_on":
                GripButtonClicked(action[0], transform);
                break;
            case "glip_off":
                GripButtonUnClicked(action[0], transform);
                break;

            case "menu_on":
                MenuButtonClicked(action[0], transform);
                break;
            case "menu_off":
                MenuButtonUnClicked(action[0], transform);
                break;

            case "stick_on": // 3
                StickPadClicked(float.Parse(action[2]), float.Parse(action[3]), action[0], transform);
                break;
            case "stick_off":
                StickPadUnClicked(action[0], transform);
                break;

            case "touch_on": // 3
                TouchpadTouch(float.Parse(action[2]), float.Parse(action[3]), action[0], transform);
                break;
            case "touch_off":
                TouchpadTouchUp(action[0], transform);
                break;
            case "touch_down":
                TouchpadTouchDown(action[0], transform);
                break;
            default:
                break;
        }
    }

    // args = {controllerName, controllerTransform}
    // トリガ系
    protected virtual void TriggerTouchDown(float x, params object[] args){
        if (do_log) Debug.Log(this.name + " トリガーを浅く引いた:" + x);
    }
    protected virtual void TriggerPressDown(float x, params object[] args){
        if (do_log) Debug.Log(this.name + " トリガーを深く引いた:" + x);
    }
    protected virtual void TriggerUnClicked(params object[] args){
        if (do_log) Debug.Log(this.name + " トリガーを離した:");
    }
    protected virtual void TriggerClicked(float x, params object[] args){
        if (do_log) Debug.Log(this.name + " トリガーを深く引いている:" + x);
    }
    protected virtual void TriggerTouch(float x, params object[] args){
        if (do_log) Debug.Log(this.name + " トリガーを浅く引いている:" + x);
    }

    // スティック系
    protected virtual void StickPadClicked(float x, float y, params object[] args){
        if (do_log) Debug.Log(this.name + " タッチパッドをクリックしている: " + "x: " + x + " y: " + y);
    }
    protected virtual void StickPadUnClicked(params object[] args){
        if (do_log) Debug.Log(this.name + " タッチパッドをクリックして離した");
    }

    // タッチパッド系
    protected virtual void TouchpadTouchUp(params object[] args){
        if (do_log) Debug.Log(this.name + " タッチパッドを離した");
    }
    protected virtual void TouchpadTouch(float x, float y, params object[] args){
        if (do_log) Debug.Log(this.name + " タッチパッドに触っている: " + "x: " + x + " y: " + y);
    }
    protected virtual void TouchpadTouchDown(params object[] args){
        if (do_log) Debug.Log(this.name + " タッチパッドに触った");
    }

    // グリップボタン系
    protected virtual void GripButtonClicked(params object[] args){
        if (do_log) Debug.Log(this.name + " グリップボタンをクリックした");
    }
    protected virtual void GripButtonUnClicked(params object[] args){
        if (do_log) Debug.Log(this.name + " グリップボタンを離した");
    }

    // メニューボタン系
    protected virtual void MenuButtonClicked(params object[] args){
        if (do_log) Debug.Log(this.name + " メニューボタンをクリックした");
    }
    protected virtual void MenuButtonUnClicked(params object[] args){
        if (do_log) Debug.Log(this.name + " メニューボタンを離した");
    }



    public virtual void SetPosition(GameObject trackedObject)
    {
        this.transform.position = trackedObject.transform.position;
        this.transform.rotation = trackedObject.transform.rotation;

        // this.velocity = trackedObject.velocity;
        // this.angulerVelocity = trackedObject.angulerVelocity;
    }
    public virtual void SetPosition(Vector3 pos, Quaternion rot)
    {
        this.transform.position = pos;
        this.transform.rotation = rot;
    }
    public virtual void SetVelocity(Vector3 velocity, Vector3 angulerVelocity)
    {
        this.velocity = velocity;
        this.angulerVelocity = angulerVelocity;
    }
}