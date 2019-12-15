using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{


    public static int curLevel;

    [SerializeField] int myScene;

    public static bool sceneLoaded = false;

    bool playerClose = false;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerClose)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneLoad(myScene);
            }
        }

    }

    public void SceneLoad(int myScene)
    {
        if (sceneLoaded)
        {
            SceneManager.UnloadSceneAsync(curLevel);
            

            SceneManager.LoadScene(myScene, LoadSceneMode.Additive);
            curLevel = myScene;
        }
        else
        {
            SceneManager.LoadScene(myScene, LoadSceneMode.Additive);
            curLevel = myScene;
            sceneLoaded = true;
        }
        TheMachine.SceneChange();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerClose = false;
        }
    }
}
