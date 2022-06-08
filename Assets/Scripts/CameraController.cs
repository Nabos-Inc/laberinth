using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private float _height = 1.6f;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _sprintMultiplier;
    
    [SerializeField]
    private Rigidbody _camRB;
    [SerializeField]
    private CapsuleCollider _camCol;

    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var speed = _speed;
        var heightPos = transform.position + Vector3.up * _height;
        if (Input.GetButton("Fire3"))
            speed *= _sprintMultiplier;

        var forward = _camera.transform.forward;
        forward = new Vector3(forward.x, 0, forward.z);
        var right = _camera.transform.right;
        right = new Vector3(right.x, 0, right.z);
        
        var direction = (Input.GetAxis("Vertical") * forward.normalized) + (Input.GetAxis("Horizontal") * right.normalized);
        var newPosition = _camRB.position += speed * direction.normalized * Time.deltaTime;

        var ray = new Ray(_camRB.transform.position, direction.normalized);
        var distanceToMove = Vector3.Distance(_camRB.position, newPosition);
        RaycastHit rh;

        if (Physics.Raycast(ray, out rh) && rh.distance < distanceToMove)
        {

        }

       
        _camRB.MovePosition(newPosition);

        Debug.DrawLine(heightPos, heightPos + forward, Color.red);
        Debug.DrawLine(heightPos, heightPos + right, Color.blue);
        Debug.DrawLine(heightPos, heightPos + direction.normalized, Color.cyan);
    }
}
