using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    public float jumpForce;
    public float gravityModifier;
    private bool _isOnGround = true;
    public bool gameOver = false;
    private Animator _animator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
        {
            Debug.Log("RB is null");
        }

        _animator = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !gameOver)
        {
            _rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            _isOnGround = false;
            _animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!!");
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
    }
}
