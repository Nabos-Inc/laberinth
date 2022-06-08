using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody _camRB;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _sprintMultiplier;

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
        if (Input.GetButton("Fire3"))
            speed *= _sprintMultiplier;

        var forward = _camera.transform.forward;
        forward = new Vector3(forward.x, 0, forward.z);
        var right = _camera.transform.right;
        right = new Vector3(right.x, 0, right.z);
        
        var direction = (Input.GetAxis("Vertical") * forward.normalized) + (Input.GetAxis("Horizontal") * right.normalized);
        var newPosition = _camRB.position += speed * direction.normalized * Time.deltaTime;
        _camRB.MovePosition(newPosition);

        Debug.DrawLine(_camera.transform.position, _camera.transform.position + forward, Color.red);
        Debug.DrawLine(_camera.transform.position, _camera.transform.position + right, Color.blue);
        Debug.DrawLine(_camera.transform.position, _camera.transform.position + direction.normalized, Color.cyan);
    }
}
