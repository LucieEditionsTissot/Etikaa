using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forwardForce = 0f;
    [SerializeField] float jumpForce = 10f;

    private bool zPressed;
    private bool sPressed;
    private bool qPressed;
    private bool dPressed;
    private bool spacePressed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rotate the player with the mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, mouseX, 0);
    }

    private void FixedUpdate()
    {
        //ZQSD player controls
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Debug.Log(moveHorizontal);
        Debug.Log(moveVertical);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0.0f;

        transform.GetComponent<Rigidbody>().AddForce(movement * forwardForce * Time.deltaTime, ForceMode.VelocityChange);

        //Jump
        if (spacePressed)
        {
            Debug.Log("Jump");
            rb.AddForce(jumpForce * Vector3.up, ForceMode.VelocityChange);
        }
    }
}