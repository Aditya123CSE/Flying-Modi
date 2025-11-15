using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Assigned in Inspector (Drag Rigidbody 2D here)
    public Rigidbody2D myRigidbody;
    public float flapStrength = 8f;
    
    // Found via Tag in Start()
    public LogicScript logic; 
    public bool birdIsAlive = true;

    public float topBoundary = 11f;    // 1 unit above the screen top (Y=10)
    public float bottomBoundary = -11f; // 1 unit below the screen bottom (Y=-10)
 // Add public variables for the sound files
    public AudioClip flapSound;
    public AudioClip hitSound; 
    
    // Private reference to the AudioSource component
    public AudioSource audioSource;
    void Start()
    {
        // Finds the object with Tag="Logic" and gets its script
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0) && birdIsAlive)
        {
            // Reset velocity and apply upward strength for consistent flap
            myRigidbody.velocity = Vector2.up * flapStrength;
            if (audioSource != null && flapSound != null)
            {
                audioSource.PlayOneShot(flapSound);
            }
        }
        checkBoundaries();
    }
 
 void checkBoundaries()
    {
        float birdY = transform.position.y;
        
        // If the bird flies higher than the top boundary OR lower than the bottom boundary
        if (birdY > topBoundary || birdY < bottomBoundary)
        {
            if (birdIsAlive)
            {
                birdIsAlive = false;
                logic.gameOver();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // CRITICAL: Play the hit sound immediately upon collision
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
        // Game Over on hitting any solid object
        logic.gameOver();
        birdIsAlive = false;
    }
}