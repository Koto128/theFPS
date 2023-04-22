using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Camera fpsCam;
    public float damage = 100;
    public ParticleSystem thunder;
    public Transform launcher;
    public float Pow;
    
    Vector3 targetPos;

    private void start()
    {
        transform.GetComponent<Rigidbody>().isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            shoot();
        }
    
    }


    private void shoot()
    {
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = null;//trident ke chere dai 

        //center of the screen theke akta ray instantiaate kore
        Ray ray = fpsCam.ViewportPointToRay(fpsCam.GetComponent<Transform>().position);
        //colider hit ta register kore 
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.point);
            targetPos = hit.point;//target register 
        }
        Vector3 Direction = targetPos - launcher.position;// trident ar direction vector 

        transform.forward = Direction.normalized;
        transform.GetComponent<Rigidbody>().AddForce(Direction.normalized * Pow, ForceMode.Impulse);// Force diche
       
    }
}

