using UnityEngine;
using System.Collections;
using Valve.VR;

public class MainController : MonoBehaviour
{
    public SteamVR_TrackedObject Controller;
    public SteamVR_Controller.Device device { get; set; } 
    
    private SteamVR_TrackedController trackedController;

    public bool triggerPressed = false;
    public bool menuPressed = false;
    public bool gripPressed = false;

    public bool do_getTrigger;
    public bool do_log;

    public ActionObject actionObject;

    // Use this for initialization
    private void Start() {
        if (!Controller) Controller = this.GetComponent<SteamVR_TrackedObject>();

        InitTrackedController();
        device = SteamVR_Controller.Input((int)Controller.index);

        //StartCoroutine("PulseIntervalOneSecond");
    }

    private void InitTrackedController() {
        trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
    }

    private IEnumerator PulseIntervalOneSecond() {
        while (true) {
            Debug.Log(this.name + " pulse");
            device.TriggerHapticPulse(2000);
            yield return new WaitForSeconds(1.0f);
        }
    }

    protected void Update()
    {
        if (device != null)
        {
            if (do_getTrigger) ControllerFunction();
        }
        else if (Controller)
        {
            device = SteamVR_Controller.Input((int)Controller.index);
        }
    }

    private void ControllerFunction(){
        // トリガ系
        //if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)){
        //    TriggerTouchDown();
        //}else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)){
        //    TriggerPressDown();
        //}else 
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)){
            TriggerShallowTouch();
        }else if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger)){
            TriggerDeepTouch();
        }else if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)){
            TriggerUnClicked();
        }

        // スティック系
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad)){ // スティックをクリックしている時に出る
            PadClicked();
        }else if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)){ // スティックを離した(クリックをやめた)瞬間に出る
            PadUnClicked();
        }

        // タッチパッド系
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad)){ // タッチパッドを触った瞬間に出る
            TouchpadTouchDown();
        }else if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)){ // タッチパッドを触っている時に出る
            TouchpadTouching();
        }else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad)){ // タッチパッドを離した瞬間に出る
            TouchpadTouchUp();
        }

        // メニューボタン系
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)){
            MenuButtonClicked();
        }else if (device.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu)){
            MenuButtonUnClicked();
        }

        // グリップボタン系
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip)){
            GripButtonClicked();
        }else if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip)){
            GripButtonUnClicked();
        }
    }

    // トリガ系
    protected void TriggerTouchDown()
    {
        SetAction(this.name, "trigger_shallow:" + device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
        if (do_log) Debug.Log(this.name + " トリガーを浅く引いた:" + device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
    }
    protected void TriggerPressDown()
    {
        SetAction(this.name, "trigger_deep:" + device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
        if (do_log) Debug.Log(this.name + " トリガーを深く引いた:" + device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
    }
    protected void TriggerShallowTouch()
    {
        SetAction(this.name, "trigger_onshallow:" + device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
        if (do_log) Debug.Log(this.name + " トリガーを浅く引いている:" + device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
    }
    protected void TriggerDeepTouch()
    {
        SetAction(this.name, "trigger_ondeep:" + device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
        if (do_log) Debug.Log(this.name + " トリガーを深く引いている:" + device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
    }
    protected void TriggerUnClicked()
    {
        SetAction(this.name, "trigger_off");
        if (do_log) Debug.Log(this.name + " トリガーを離した:" + device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
    }

    // スティック系
    protected void PadClicked()
    {
        var position = device.GetAxis();
        SetAction(this.name, "stick_on:" + position.x + ":" + position.y);
        if (do_log) Debug.Log(this.name + " タッチパッドをクリックしている: " + "x: " + position.x + " y: " + position.y);
    }
    protected void PadUnClicked()
    {
        SetAction(this.name, "stick_off");
        if (do_log) Debug.Log(this.name + " タッチパッドをクリックして離した");
    }

    // タッチパッド系
    protected void TouchpadTouchDown()
    {
        SetAction(this.name, "touch_down");
        if (do_log) Debug.Log(this.name + " タッチパッドに触った");
    }
    protected void TouchpadTouchUp()
    {
        SetAction(this.name, "touch_off");
        if (do_log) Debug.Log(this.name + " タッチパッドを離した");
    }
    protected void TouchpadTouching()
    {
        var position = device.GetAxis();
        SetAction(this.name, "touch_on:" + position.x + ":" + position.y);
        if (do_log) Debug.Log(this.name + " タッチパッドに触っている: " + "x: " + position.x + " y: " + position.y);
    }

    // グリップボタン系
    protected void GripButtonClicked()
    {
        SetAction(this.name, "glip_on");
        if (do_log) Debug.Log(this.name + " グリップボタンをクリックした");
    }
    protected void GripButtonUnClicked()
    {
        SetAction(this.name, "glip_off");
        if (do_log) Debug.Log(this.name + " グリップボタンを離した");
    }

    // メニューボタン系
    protected void MenuButtonClicked()
    {
        SetAction(this.name, "menu_on");
        if (do_log) Debug.Log(this.name + " メニューボタンをクリックした");
    }
    protected void MenuButtonUnClicked()
    {
        SetAction(this.name, "menu_off");
        if (do_log) Debug.Log(this.name + " メニューボタンを離した");
    }

    protected void SetAction(string name, string action){
        // controllerDataCollecter.SetActionEvent(name+":"+action);
        actionObject.DoAction((name+":"+action).Split(':'), this.transform);
    }
}