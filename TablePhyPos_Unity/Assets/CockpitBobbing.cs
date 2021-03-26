using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitBobbing : MonoBehaviour
{
    [SerializeField] Transform leftStep;
    [SerializeField] Transform rightStep;
    [SerializeField] float bobbingIntensity = 0.5f;

    float defaultPosY = 0;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        float heightStep = (Mathf.Abs(leftStep.transform.position.y - rightStep.transform.position.y));
        transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(heightStep) * bobbingIntensity, transform.localPosition.z);
    }
}
