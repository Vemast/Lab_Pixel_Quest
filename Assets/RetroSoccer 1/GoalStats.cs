using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using static Structs;

public class GoalStats : MonoBehaviour
{

    public int currentGoals1 = 0;   // How many goals has the player collected 
    public int currentGoals2 = 0;
    private Rigidbody2D rigidbody2D; // Controls player speed 
    private const string goalTag1 = "Goal1";
    private const string goalTag2 = "Goal2";
    public TextMeshProUGUI goalText1;    // Update the text showing goals collected 
    public TextMeshProUGUI goalText2;
    public AudioSource goalSFX;   // Goal pick up sound effect 
    public Transform respawnPoint; // Keeps track of where the player we respawn at 

    void Start()
    {
        // Connect to the rigidbody 
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Updates the UI to show the proper values of the level 
        goalText1.text = "Player 1: " + currentGoals1;
        goalText2.text = "Player 2: " + currentGoals2;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            // goal tag, dicates what happens after player touches goals 
            case goalTag1:
                {
                    // Plays Sound Effect 
                    //goalSFX.Play();
                    // Increase the value of goals by 1
                    currentGoals1++;
                    // Updates the UI 
                    goalText1.text = "Player 1: " + currentGoals1;
                    transform.position = respawnPoint.position;
                    rigidbody2D.velocity = Vector3.zero;
                    break;
                }
            case goalTag2:
                {
                    // Plays Sound Effect 
                    //goalSFX.Play();
                    // Increase the value of goals by 1
                    currentGoals2++;
                    // Updates the UI 
                    goalText2.text = "Player 2: " + currentGoals2;
                    transform.position = respawnPoint.position;
                    rigidbody2D.velocity = Vector3.zero;
                    break;
                }
            
        }
        if (currentGoals1 == 3 || currentGoals2 == 3)
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            // Reload that level 
            SceneManager.LoadScene(currentLevel);
        }
    }
}
