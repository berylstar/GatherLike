using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject monster;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (transform.childCount < 3)
            {
                Instantiate(monster, transform.position, Quaternion.identity, transform);
            }

            yield return new WaitForSecondsRealtime(3f);
        }
    }
}