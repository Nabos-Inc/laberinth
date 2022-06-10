using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRaycaster : MonoBehaviour
{
    // Start is called before the first frame update

    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 1.25f))
            {
                if (hit.collider.gameObject.tag == "Door")
                {
                    Debug.Log("Closing door");
                    Door door = hit.collider.gameObject.GetComponent<Door>();
                    door.CloseDoor();
                }
            }
        }
    }

}
