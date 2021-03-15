using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField]bool isGrounded = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground") && !isGrounded)
        {
            isGrounded = true;
            SensorManager.Instance().SendWalkSensation();
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
