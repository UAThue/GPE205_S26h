using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankMover : Mover
{
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody>();
        // Do what the parent class does
        base.Start();        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Move(Vector3 moveDirection, float moveSpeed)
    {
        // Find a vector that is "move speed" in "move direction"
        Vector3 moveVector = (moveDirection.normalized * (moveSpeed * Time.deltaTime));
        // Move to "our current position plus that vector" 
        rb.MovePosition(rb.position + moveVector);
    }

    public override void Turn (float turnDirection, float turnSpeed)
    {
        // Rotate based on parameters passed in
        transform.Rotate(0, (turnDirection * (turnSpeed * Time.deltaTime)), 0);
    }
}
