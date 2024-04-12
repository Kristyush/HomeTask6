using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Transform _colliderTransform;
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || isGrounded == false)
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime*15f);
        } else
        {
            _colliderTransform.localScale = Vector3.one;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                _rigidbody.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
            }
        }
    }

    void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (isGrounded == false)
        {
            speedMultiplier = 0.1f;
            if (_rigidbody.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0;
            }
            if (_rigidbody.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }



        _rigidbody.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);
        if (isGrounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.GetContact(i).normal, Vector3.up);
            if (angle < 45f)
            {
                isGrounded = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
