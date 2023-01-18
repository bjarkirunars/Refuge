using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] explosions;
    private float waitTime = 2.0f;
    private float timer = 0.0f;

    void Start()
    {}

    void Update()
    {
        timer += Time.deltaTime;
        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            // Remove the recorded 2 seconds.
            timer = timer - waitTime;
            explosions[Random.Range(1, 5)].Play();
        }
    }
}