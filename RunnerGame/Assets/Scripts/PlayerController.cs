using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    public float jumpForce;
    public float gravityModifier;
    private bool _isOnGround = true;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
        {
            Debug.Log("RB is null");
        }

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            _isOnGround = false;
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isOnGround = true;
    }
}
