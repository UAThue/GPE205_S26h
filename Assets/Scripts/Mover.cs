using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Move(Vector3 moveDirection, float moveSpeed)
    {
        // TODO: Do anything that everything that moves does
    }

    // Update is called once per frame
    public virtual void Turn(float direction, float turnSpeed)
    {
        // TODO: Do anything that everything that turns does   
    }
}
