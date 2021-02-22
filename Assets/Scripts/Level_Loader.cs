using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    // Update is called once per frame
    public string sceneToLoad;
    public static string prevScene = "";
    public static string currentScene = "";

    public virtual void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            prevScene = currentScene;
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        //Play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
