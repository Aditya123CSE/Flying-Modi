using UnityEngine;
 
public class PipeMiddleScript : MonoBehaviour
{
    // Found via Tag in Start()
    public LogicScript logic;
 
    void Start()
    {
        // Finds the Logic Manager by Tag
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
 
    void Update()
    {
        // No code needed here
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Layer 3 is commonly used for the Player in these tutorials.
        // The collision object must be set to Layer 3 for this check to pass.
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
        }
    }
}