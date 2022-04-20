using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float rotationSpeed;
    public float playerSpeed;
    Rigidbody rb;
    public Transform bulletDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal") * playerSpeed;

        float inputz = Input.GetAxis("Vertical") * playerSpeed;
    

        transform.position += new Vector3(inputX, 0f, inputz);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.rotation = transform.rotation * Quaternion.Euler(0, mouseX * rotationSpeed, 0);
        Camera cam = GetComponentInChildren<Camera>();
        cam.transform.localRotation = Quaternion.Euler(-mouseY, 0, 0) * cam.transform.localRotation;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HitEnemy();
        }
    }
    private void HitEnemy()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(bulletDirection.position, bulletDirection.forward, out hitInfo, 1000f))
        {
            GameObject hitEnemy = hitInfo.collider.gameObject;
            if (hitEnemy.tag == "Enemy")
            {
                Destroy(hitEnemy);

            }
        }
    }
}
