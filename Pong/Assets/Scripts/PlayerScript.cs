using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float minY, maxY;

    private void Start()
    {
        SetMinAndMaxX();
    }
    private void Update()
    {
        transform.position = new Vector2(transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

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
