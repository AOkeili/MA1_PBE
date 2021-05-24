using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{

    [SerializeField] GameObject muzzleFlash;
    [SerializeField] GameObject hitFlash;

    public float speed;
    public Vector3 startPosition;
    public float range;


    void Start()
    {
        startPosition = transform.position;
        GameObject tmpFlash = Instantiate(muzzleFlash, startPosition, Quaternion.LookRotation(transform.forward));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
        if (Vector3.Distance(startPosition, transform.position) >= range) Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {

        ContactPoint contact = collision.contacts[0];

        Quaternion hitRotation = Quaternion.FromToRotation(Vector3.up,contact.normal);
        Instantiate(this.hitFlash, contact.point, hitRotation);
        
        Destroy(this.gameObject);
    }

}
