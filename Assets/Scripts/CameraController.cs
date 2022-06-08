using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private LayerMask _obstacleMask;
    [SerializeField]
    private float _height = 1.6f;
    [SerializeField]
    private float _radius = .5f;
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
    void Awake()
    {
        _camera = Camera.main;
        Locator.ProvideCameraController(this);
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
        direction = direction.normalized;

        if (direction.sqrMagnitude > 0)
        {
            var ray = new Ray(_camRB.transform.position, direction);
            Debug.DrawRay(ray.origin, ray.direction, Color.cyan);
            var distanceToMove = speed * Time.deltaTime;
            Vector3 newPosition = ray.GetPoint(distanceToMove);
            _camRB.MovePosition(newPosition);
        }

        Debug.DrawLine(heightPos, heightPos + forward, Color.red);
        Debug.DrawLine(heightPos, heightPos + right, Color.blue);
    }
}
