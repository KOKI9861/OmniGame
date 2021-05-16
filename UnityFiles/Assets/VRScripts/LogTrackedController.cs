using UnityEngine;
using System.Collections;

public class LogTrackedController : MonoBehaviour
{
    SteamVR_TrackedController trackedController;

    void Start()
    {
        trackedController = gameObject.GetComponent<SteamVR_TrackedController>();

        if (trackedController == null)
        {
            trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
        }

        trackedController.MenuButtonClicked += new ClickedEventHandler(DoMenuButtonClicked);
        trackedController.MenuButtonUnclicked += new ClickedEventHandler(DoMenuButtonUnClicked);
        trackedController.TriggerClicked += new ClickedEventHandler(DoTriggerClicked);
        trackedController.TriggerUnclicked += new ClickedEventHandler(DoTriggerUnclicked);
        trackedController.SteamClicked += new ClickedEventHandler(DoSteamClicked);
        trackedController.PadClicked += new ClickedEventHandler(DoPadClicked);
        trackedController.PadUnclicked += new ClickedEventHandler(DoPadClicked);
        trackedController.PadTouched += new ClickedEventHandler(DoPadTouched);
        trackedController.PadUntouched += new ClickedEventHandler(DoPadTouched);
        trackedController.Gripped += new ClickedEventHandler(DoGripped);
        trackedController.Ungripped += new ClickedEventHandler(DoUngripped);
    }

    public void DoMenuButtonClicked(object sender, ClickedEventArgs e)
    {
        Debug.Log("DoMenuButtonClicked "+e);
    }

    public void DoMenuButtonUnClicked(object sender, ClickedEventArgs e)
    {
        Debug.Log("DoMenuButtonUnClicked "+e);
    }

    public void DoTriggerClicked(object sender, ClickedEventArgs e)
    {
        Debug.Log("DoTriggerClicked "+e);
    }

    public void DoTriggerUnclicked(object sender, ClickedEventArgs e)
    {
        Debug.Log("DoTriggerUnclicked "+e);
    }

    public void DoSteamClicked(object sender, ClickedEventArgs e)
    {
        Debug.Log("DoSteamClicked " + e);
    }

    public void DoPadClicked(object sender, ClickedEventArgs e)
    {
        Debug.Log("DoPadClicked " + e);
    }

    public void DoPadUnclicked(object sender, ClickedEventArgs e)
    {
        Debug.Log("DoPadUnclicked " + e);
    }

    public void DoPadTouched(object sender, ClickedEventArgs e)
    {
        Debug.Log("DoPadTouched " + e);
    }

    public void DoPadUntouched(object sender, ClickedEventArgs e)
    {
        Debug.Log("DoPadUntouched " + e);
    }

    public void DoGripped(object sender, ClickedEventArgs e)
    {
        Debug.Log("DoGripped "+e);
    }

    public void DoUngripped(object sender, ClickedEventArgs e)
    {
        Debug.Log("DoUngripped " + e);
    }
}