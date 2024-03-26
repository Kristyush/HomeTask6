using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool isGrounded;
    public float MaxSpeed;
    public Transform ColliderTransform;
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || isGrounded == false)
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime*15f);
        } else
        {
            ColliderTransform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
            }
        }
    }

    void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (isGrounded == false)
        {
            speedMultiplier = 0.1f;
            if (Rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0;
            }
            if (Rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }



        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);
        if (isGrounded)
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
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
