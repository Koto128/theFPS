using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMove : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(FindObjectOfType<projectile>().player.position);
        transform.Translate(Vector3.forward * FindObjectOfType<projectile>().pace * Time.deltaTime);
        //GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * FindObjectOfType<projectile>().pace,ForceMode.Acceleration);
        //Vector3.MoveTowards(transform.position, FindObjectOfType<projectile>().player.position, FindObjectOfType<projectile>().pace *2 * Time.deltaTime);
    }
}
