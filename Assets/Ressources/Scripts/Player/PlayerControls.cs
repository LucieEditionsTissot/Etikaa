using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forwardForce = 0f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] Camera cam;

    //mouse sensitivity
    [SerializeField] float mouseSensitivity = 1f;
    private bool spacePressed;

    private void Update()
    {
        if(Time.frameCount < 10){
            return;
        }
        //ZQSD player controls
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, mouseX * mouseSensitivity, 0);
        
        float nextCamRotation = cam.transform.localRotation.eulerAngles.x + (-mouseY * Time.deltaTime * mouseSensitivity);
        if((nextCamRotation < 80 && nextCamRotation > 0) || (nextCamRotation > 280 && nextCamRotation < 360))
            cam.transform.RotateAround(cam.transform.right, -mouseY * Time.deltaTime * mouseSensitivity);

        if(cam.transform.localRotation.eulerAngles.x > 80 && cam.transform.localRotation.eulerAngles.x < 180)
            cam.transform.localRotation = Quaternion.Euler(80, cam.transform.localRotation.eulerAngles.y, cam.transform.localRotation.eulerAngles.z);
        else if(cam.transform.localRotation.eulerAngles.x < 280 && cam.transform.localRotation.eulerAngles.x > 80)
            cam.transform.localRotation = Quaternion.Euler(280, cam.transform.localRotation.eulerAngles.y, cam.transform.localRotation.eulerAngles.z);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 direction = cam.transform.TransformDirection(movement);
        direction.y = 0.0f;

        transform.GetComponent<Rigidbody>().AddForce(direction * forwardForce * Time.deltaTime, ForceMode.VelocityChange);

        //Jump
        if (spacePressed)
        {
            Debug.Log("Jump");
            rb.AddForce(jumpForce * Vector3.up, ForceMode.VelocityChange);
        }
    }
}