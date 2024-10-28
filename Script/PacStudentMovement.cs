using UnityEngine;
using System.Collections;

public class PacStudentMovement : MonoBehaviour
{
    public float speed = 1.0f; // The speed at which PacStudent moves
    public AudioClip movementSound;
    public AnimationClip walkAnimation;

    private AudioSource audioSource;
    private bool isMoving = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveClockwise());
        }
    }

    IEnumerator MoveClockwise()
    {
        isMoving = true;
        // Define the sequence of points to move around the top-left inner block
        Vector3[] points = {
            // Replace these with the actual positions of the corners
            Vector3.zero, // Starting point
            new Vector3(1, 0, 0),
            new Vector3(1, -1, 0),
            new Vector3(0, -1, 0)
        };

        for (int i = 0; i < points.Length; i++)
        {
            float journeyLength = Vector3.Distance(transform.position, points[(i + 1) % points.Length]);
            float journeyTime = journeyLength / speed;
            while (journeyTime > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, points[(i + 1) % points.Length], speed * Time.deltaTime);
                journeyTime -= Time.deltaTime;
                audioSource.clip = movementSound;
                audioSource.Play();
                // Play walk animation
            // Your code to play the walk animation
            yield return null;
        }
    }

        isMoving = false;
    }
}