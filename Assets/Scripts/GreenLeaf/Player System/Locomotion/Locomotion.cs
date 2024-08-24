using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Locomotion : MonoBehaviour
{
    [Range(0f, 10f)]
    public float Speed = 1.5f;
    [Range(0f, 10f)]
    public float JumpForce = 1f;
    private Rigidbody2D _rigidbody;
    public LayerMask Ground;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && CheckGrounded())
            Jump();
        else if(Input.GetKey(KeyCode.A))
            Move(false);
        else if(Input.GetKey(KeyCode.D))
            Move(true);
    }

    private void Jump()
    {
        _rigidbody.AddForce(JumpForce * 50 * new Vector2(0,1f));
    }
    private void Move(bool isRight)
    {
        int direction = isRight? 1:-1;
        //flip character orientation
        transform.position += direction * Vector3.right * Speed * Time.deltaTime;
    }
    private bool CheckGrounded(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, Ground);
        if(hit.collider != null)
            return true;
        else 
            return false;
    }
}
