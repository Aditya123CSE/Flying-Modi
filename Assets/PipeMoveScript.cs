using UnityEngine;
 
public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
 
    void Start()
    {
        // No code needed here
    }
 
    void Update()
    {
        // CRITICAL: Move the pipe left every frame
        transform.position += Vector3.left * moveSpeed * Time.deltaTime; 

        // CRITICAL: Destroy the pipe when its X position is LESS than the dead zone (off-screen left)
        if (transform.position.x < deadZone) 
        {
            Destroy(gameObject);
        }
    }
}