using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    private bool onWall = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            onWall = true;
            StartCoroutine(DestroyTime());
        }
        else if (collision.CompareTag("Monster") && !onWall)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (onWall)
            return;

        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }

    private IEnumerator DestroyTime()
    {
        yield return new WaitForSecondsRealtime(5f);
        Destroy(this.gameObject);
    }
}
