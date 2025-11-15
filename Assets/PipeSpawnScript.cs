using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    // Set this high (e.g., 12) in the Inspector for off-screen spawning
    public float spawnXPosition = 12f; 
    // Set this low (e.g., 4) in the Inspector to keep pipes on screen
    public float heightOffset = 3; 
    
    private float timer = 0;
 
    void Start()
    {
        // Removed: spawnPipe(); The Update() loop handles the first spawn after 2 seconds.
    }
 
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }
 
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
 
        // Use the fixed spawnXPosition for consistent spawning location
        Instantiate(pipe, new Vector3(spawnXPosition, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}