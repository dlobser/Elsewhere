using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPrewarmRoomCrystalGlow : TriggerPrewarm
{

    public LightingControlController ctrl;

    public Vector3 brightnessChange;
    Vector3 initialBrightness;

    public bool red;
    public bool green;
    public bool blue;

    void Awake() {
        initialBrightness = ctrl.brightness;
    }
   
    public override void Animate(float t)
    {
        if (red) {
            ctrl.brightness = new Vector3(Vector3.Lerp(initialBrightness,brightnessChange,t).x, ctrl.brightness.y, ctrl.brightness.z);
        }
        if (green) {
            ctrl.brightness = new Vector3(ctrl.brightness.x, Vector3.Lerp(initialBrightness, brightnessChange, t).y, ctrl.brightness.z);
        }
        if (blue) {
            ctrl.brightness = new Vector3(ctrl.brightness.x, ctrl.brightness.y, Vector3.Lerp(initialBrightness, brightnessChange, t).z);
        }
    }
	public override void Reset()
	{
        if (red) {
            ctrl.brightness = new Vector3(initialBrightness.x, ctrl.brightness.y, ctrl.brightness.z);
        }
        if (green) {
            ctrl.brightness = new Vector3(ctrl.brightness.x, initialBrightness.y, ctrl.brightness.z);
        }
        if (blue) {
            ctrl.brightness = new Vector3(ctrl.brightness.x, ctrl.brightness.y, initialBrightness.z);
        }

    }



}
