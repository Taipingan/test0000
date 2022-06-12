using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position,fwd,out hit,10))
        {
            Debug.Log("พบแล้ว"+ hit.distance);
        }
    }
}
