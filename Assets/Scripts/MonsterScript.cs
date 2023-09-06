using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float speed;
    public int HP;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private SpriteRenderer monsterRenderer;
    [SerializeField] private Animator monsterAnimator;

    private Transform target;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        Vector3 targetVector = target.position - transform.position;

        monsterRenderer.flipX = targetVector.x < 0;

        if (targetVector.magnitude < 3f)
            rb.velocity = Vector2.zero;
        else
            rb.velocity = (speed * targetVector.normalized);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            monsterAnimator.SetTrigger("IsHit");

            HP -= 1;

            if (HP <= 0)
                StartCoroutine(Disappear());
            else
                StartCoroutine(Hit());
        }
    }

    private IEnumerator Hit()
    {
        float temp = speed;
        speed = 0f;
        monsterRenderer.color = new Color32(200, 100, 100, 255);

        yield return new WaitForSecondsRealtime(0.2f);

        speed = temp;
        monsterRenderer.color = Color.white;
    }

    private IEnumerator Disappear()
    {
        speed = 0f;
        bc.enabled = false;
        monsterRenderer.color = new Color32(255, 255, 255, 100);

        yield return new WaitForSecondsRealtime(0.5f);

        monsterRenderer.color = new Color32(255, 255, 255, 50);

        yield return new WaitForSecondsRealtime(0.5f);

        Destroy(this.gameObject);
    }
}
