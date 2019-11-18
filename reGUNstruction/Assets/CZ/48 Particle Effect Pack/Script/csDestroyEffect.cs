using UnityEngine;
using System.Collections;

public class csDestroyEffect : MonoBehaviour {

    float timer = 0;
    float resetTimer = 0;

    private void Start()
    {
        if (resetTimer == 0)
        {
            AEToggle(false);
        }
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.C))
        {
            Destroy(gameObject);
        }

        if(timer <= resetTimer)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Destroy(gameObject);
        }
    }

    public void AEToggle(bool toggle)
    {
        if (toggle)
        {
            resetTimer = 1.5f;
        }
        else
        {
            resetTimer = 5;
        }
    }
}
