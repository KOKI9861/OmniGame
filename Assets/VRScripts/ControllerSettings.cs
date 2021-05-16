using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create ControllerSettings")]
public class ControllerSettings : ScriptableObject {
	public Vector3 centerPos;
	public Quaternion centerRot;
	public Quaternion hmdRot;
}