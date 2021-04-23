using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField]bool isGrounded = false;
    Vector3 savePos;
   /* [SerializeField] Transform detectorRight;


     void Update()
    {
        Vector3 pos = detectorRight.position - this.transform.position;
        Debug.Log("pos " + pos);
        float vertMove = Mathf.Abs(pos.z);
        SensorManager.Instance().SendWalkSensation(vertMove);
    }*/

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(transform.position);
        if(other.CompareTag("Ground") && !isGrounded )
        {
            isGrounded = true;
            savePos = transform.position;
            SensorManager.Instance().SendWalkSensation(0.3f);
            
        } else
        {
               SensorManager.Instance().SendWalkSensation(0f);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
           SensorManager.Instance().SendWalkSensation(0f);
            Debug.Log("Exit");
        }
    }
}
