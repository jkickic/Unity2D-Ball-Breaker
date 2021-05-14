using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 ballDistanceFromPaddle;
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] clips;
    [SerializeField] float randomFactor = 5f;

    public bool launched { get; set; }
    private AudioSource audioSource;
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        ballDistanceFromPaddle = transform.position - paddle1.transform.position;
        launched = false;
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {
            LockBall();
            LaunchBallOnMouseClick();
        }
    }

    private void LockBall()
    {
        transform.position = (Vector2)paddle1.transform.position + ballDistanceFromPaddle;
    }

    private void LaunchBallOnMouseClick() {
        if (Input.GetMouseButton(0)) {
            launched = true;
            rigidbody.velocity = new Vector2(Random.Range(-3, 4), 20f);
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (launched)
        {
            Vector2 velocityTweak = new Vector2(
                Random.Range(0f, randomFactor),
                Random.Range(0f, randomFactor));
            audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);

            rigidbody.velocity = rigidbody.velocity + velocityTweak;
        }
    }
}
