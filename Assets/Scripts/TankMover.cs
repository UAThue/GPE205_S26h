using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankMover : Mover
{
    private Rigidbody rb;
    private TankPawn owner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // Get the owner
        owner = GetComponent<TankPawn>();

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

    public override void Seek (Vector3 target, float moveSpeed, float turnSpeed)
    {
        // Rotate a little towards the target
        Vector3 vectorToTarget = target - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);

        // Move forward
        Move(transform.forward, moveSpeed);
    }

    public override void Move(Vector3 moveDirection, float moveSpeed)
    {
        // Find a vector that is "move speed" in "move direction"
        Vector3 moveVector = (moveDirection.normalized * (moveSpeed * Time.deltaTime));
        // Move to "our current position plus that vector" 
        rb.MovePosition(rb.position + moveVector);
        // Make Noise
        if (owner != null)
        {
            owner.noiseMaker.MakeNoise(owner.moveVolume);
        }
    }

    public override void Turn (float turnDirection, float turnSpeed)
    {
        // Rotate based on parameters passed in
        transform.Rotate(0, (turnDirection * (turnSpeed * Time.deltaTime)), 0);
    }
}
