using UnityEngine;

public class KickedSFX : MonoBehaviour
{
    // Reference to the AudioSource component for the kick sound effect
    private AudioSource kickedSFX;

    void Start()
    {
        // Find the AudioSource with the name "Kicked SFX"
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (var audioSource in audioSources)
        {
            if (audioSource.gameObject.name == "Kicked SFX")
            {
                kickedSFX = audioSource;
                break;
            }
        }

        // Log error if not found
        if (kickedSFX == null)
        {
            Debug.LogError("No AudioSource named 'Kicked SFX' found on the Ball GameObject.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play the kick sound effect if the AudioSource is available
            if (kickedSFX != null)
            {
                kickedSFX.Play();
            }
        }
    }
}
