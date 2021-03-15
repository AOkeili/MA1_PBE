using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        foreach(var device in inputDevices)
        {
            Debug.Log(device.name + "  : " + device.characteristics.ToString());
        }
    }
}
