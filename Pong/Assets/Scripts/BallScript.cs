using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Rigidbody2D rb;

    private bool isLaunch = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isLaunch)
        {
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        isLaunch = true;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(x, y).normalized * speed;
    }

    public void ResetBall()
    {
        isLaunch = false;
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerGoal")
        {
            GameManager.instance.Scored(Scorer.Player);
        }
        else if (collision.tag == "AIGoal")
        {
            GameManager.instance.Scored(Scorer.AI);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.PlaySound("bounce");
    }
}
