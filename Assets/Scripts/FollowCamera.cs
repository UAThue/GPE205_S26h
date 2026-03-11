using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move to "offset" units above the target
        transform.position = target.transform.position + new Vector3(0, offset, 0);
        // Look at the target
        transform.LookAt(target.position);        
    }
}
