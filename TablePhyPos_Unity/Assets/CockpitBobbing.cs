using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitBobbing : MonoBehaviour
{
    [SerializeField] Transform leftStep;
    [SerializeField] Transform rightStep;
    [SerializeField] float bobbingIntensity = 2f;
    [SerializeField] PlayerControl player;

    float heightStep = 0;
    float timeStep = 0;
    Transform originPos;
    float defaultPosY = 0;
    // Start is called before the first frame update
    void Start()
    {
        originPos = leftStep.transform;
        defaultPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        timeStep += Time.deltaTime;
        if(player.isWalking)
        {
            heightStep = bobbingIntensity*Mathf.Sin(timeStep);
        }
     //   heightStep = (heightStep + (90.0f / 650.0f)) % 1.0f; 
      //  float heightStep = (Mathf.Abs(leftStep.transform.position.y - rightStep.transform.position.y));
       // float heightStep = (Mathf.Abs(leftStep.transform.position.y - originPos.transform.position.y));
        transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + heightStep * bobbingIntensity, transform.localPosition.z);
       // SensorManager.Instance().SendWalkSensation(heightStep);

    }
}
