using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    private GameObject parti;
    private bool hit = false;

    private float scaleVar;
    private float refVar = 0.1f;

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
            //Shrink object before destroy for extra effect << Broken
            //yield return new WaitForSeconds(8);
            //scaleVar = Mathf.SmoothDamp(1, 0.1f, ref refVar, 1);
            //transform.localScale = new Vector3(scaleVar, scaleVar, scaleVar);

            //Destroy Time Increased from 3 to 10 (12/11)
            yield return new WaitForSeconds(10f);
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
