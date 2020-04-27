using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 10;
    public float walkSpeed = 5;
    float speed = 10;
    public float rotSpeed = 2;
    public Rigidbody rb;
    Animator m_Animator;
    public Transform cam;
    public float camMax = 45;
    public float camMin = 0;
    float camX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Run"))
        {
            speed = runSpeed;
            m_Animator.SetFloat("speed", 2);
        }
        else
        {
            speed = walkSpeed;
            m_Animator.SetFloat("speed", 1);
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            m_Animator.SetBool("walking", true);
        }
        else
        {
            m_Animator.SetBool("walking", false);
        }
        rb.MovePosition(transform.position + transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))) * Time.fixedDeltaTime * speed);
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotSpeed, 0, Space.Self);
        camX = cam.rotation.x + Input.GetAxis("Mouse Y");
        camX = Input.GetAxis("Mouse Y");
        //Debug.Log(cam.transform.rotation.eulerAngles.x);
        if (camX < 0 && ((cam.transform.rotation.eulerAngles.x < 30) || (cam.transform.rotation.eulerAngles.x > 300))) //look down
        {

            cam.Rotate(-1 * camX * rotSpeed, 0, 0, Space.Self);
        }
        else if (camX > 0 && (cam.transform.rotation.eulerAngles.x > 330 || cam.transform.rotation.eulerAngles.x < 50)) // look up
        {
            cam.Rotate(-1*camX * rotSpeed, 0, 0, Space.Self);
        }

    }

    
}
