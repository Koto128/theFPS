using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public LayerMask playerMask;
    public float jumpStrenght;
    public float speed;
    public float speedLimit;
    public GameObject player;
    public Camera fpsCam;
    public float sensitivity;
    public float sensitivity1;
    public float jumpPower;
    public float jumpLimit;
    public GameObject trident;


    bool jump;
    float leftright;
    float frontback;
    float mouseYY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKey(KeyCode.LeftShift) && speed < speedLimit)
        {
            speed = speed + 0.5f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            speed = 8;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x,0.5f, transform.localScale.z);
        }
        if (Input.GetKey(KeyCode.LeftControl) == false)
        {
            transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
        }

        leftright = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(1, 0, 0) * speed * leftright * Time.deltaTime);

        frontback = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, 1) * speed * frontback * Time.deltaTime);

        //camera rotation
        float MouseX = Input.GetAxis("Mouse X") * sensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * sensitivity1;

        mouseYY -= MouseY;
        mouseYY = Mathf.Clamp(mouseYY, -90, 90);

        fpsCam.transform.localRotation = Quaternion.Euler(mouseYY, 0f, 0f);

        transform.Rotate(new Vector3(0, 1, 0) * MouseX * Time.deltaTime);
        //end

    }

    private void FixedUpdate()
    {
        if (jump && jumpPower > 0) 
        {   
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpStrenght, ForceMode.Impulse);
            jumpPower = jumpPower-1;
            jump = false;
        }
         if (jump && jumpPower == 0)
         {
             Collider[] hitInfo = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.01f, playerMask);
             if (hitInfo.Length != 0)
             {
                 GetComponent<Rigidbody>().AddForce(Vector3.up * jumpStrenght, ForceMode.Impulse);
                jump = false; 
             }
         }
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ground")
        {
            if (jumpPower < jumpLimit)
            {
                jumpPower = 2;
            }
            
        }
    }
}
