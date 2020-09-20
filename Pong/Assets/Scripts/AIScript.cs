using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private float speed = 3.7f;

    [SerializeField]
    private float minY, maxY;

    private void Start()
    {
        SetMinAndMaxX();
    }
    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, target.position.y), step);

        if (transform.position.y < minY)
        {
            Vector3 temp = transform.position;
            temp.y = minY;
            transform.position = temp;
        }

        if (transform.position.y > maxY)
        {
            Vector3 temp = transform.position;
            temp.y = maxY;
            transform.position = temp;
        }
    }

    private void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        minY = -bounds.y + 1.6f;
        maxY = bounds.y - 1.6f;
    }
}

