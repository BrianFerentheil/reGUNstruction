using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    private GameObject parti;
    private bool hit = false;


    public void DoTheParticle(GameObject particle)
    {
        if (!hit)
        {
            parti = Instantiate(particle, transform.position, transform.rotation);
            Rigidbody rB = parti.AddComponent<Rigidbody>();
            rB.drag = 1.5f;
            hit = true;
        }
    }

    private void Update()
    {
        if (parti != null)
        {
            parti.transform.position = gameObject.transform.position;
        }
    }

    public IEnumerator DestroyMe()
    {
        if (!gameObject.name.Contains("Wall"))
        {
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(DestroyParti());
            Destroy(gameObject);
        }
    }

    public IEnumerator DestroyParti()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(parti.gameObject);
    }

    public int CallScore()
    {
        int newScore = score;
        score = 0;
        return newScore;
    }
}
