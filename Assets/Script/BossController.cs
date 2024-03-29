using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float scrollDistance = 5f;  // Adjust this value to the distance you want to scroll

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(BossMove());
        }
    }

    public IEnumerator BossMove()
    {
        float distanceScrolled = 0f;

        while (distanceScrolled < scrollDistance)
        {
            transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
            distanceScrolled += scrollSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
