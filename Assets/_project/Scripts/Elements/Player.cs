using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;
    public Transform cameraHolder;
    private Rigidbody _rb;
    public float jumpForce;
    public float speed;
    public float maxWidth;
    private float _horizontalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator=GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        MoveXAxis();

        Jump();
        
        MoveZAxis();
        
        MoveCamera();
        
    }

    private void MoveZAxis()
    {
        transform.position+= Vector3.forward*Time.deltaTime*speed;
    }
    private void MoveCamera()
    {
        var cameraPos = transform.position;
        cameraPos.x = 0;
        cameraHolder.position = cameraPos;
    }
    private void Jump()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetTrigger("Jump");
            _rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
        }
    }

    private void MoveXAxis()
    {
        if (Input.GetMouseButton(0))
        {
            _horizontalInput += Input.GetAxis("Mouse X")/2;

            var pos = transform.position;
            pos.x = _horizontalInput;
            transform.position = pos;
            ClampPlayerPosition();
        }
    }
    private void ClampPlayerPosition()
    {
        var pos=transform.position;
        pos.x = Mathf.Clamp(pos.x, -maxWidth, maxWidth);
        transform.position=pos;
    }
}
