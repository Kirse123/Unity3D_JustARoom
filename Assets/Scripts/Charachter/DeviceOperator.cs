using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{
    public float radius = 1.5f;     //range for interction with object

    private void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            //get the closiest objects in range of "raduis"
            Collider[] hitColliders = Physics.OverlapSphere(
                transform.position,
                radius);
            //for each object in range call method "Operate"
            foreach (Collider hitCollider in hitColliders)
            {
                Vector3 direction = hitCollider.transform.position - transform.position;
                if (Vector3.Dot(transform.forward, direction) > 0.5f)
                {
                    hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
