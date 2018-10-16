using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    // increase speed every paddle touch
    public float difficultyMultiplier = 1.1f;

    public float minXSpeed = 0.8f;
    public float maxXSpeed = 1.2f;

    public float minYSpeed = 0.8f;
    public float maxYSpeed = 1.2f;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(
            Random.Range(minXSpeed, maxXSpeed) * (Random.value > 0.5f ? -1 : 1),        // random direction of ball initialization for X axis
            Random.Range(minYSpeed, maxYSpeed) * (Random.value > 0.5f ? -1 : 1)         // random direction of ball initialization for Y axis
        );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Limit")) {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            GetComponent<AudioSource>().Play();
        } else if (collision.CompareTag("Paddle")) {
            rb.velocity = new Vector2(-rb.velocity.x * difficultyMultiplier, rb.velocity.y * difficultyMultiplier);
            GetComponent<AudioSource>().Play();
        }
    }
}
