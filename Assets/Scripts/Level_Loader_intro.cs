using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader_intro : MonoBehaviour
{
    public Animator transition;
    public TextBoxManager TextBox;
    public float transitionTime = 1f;

    // Update is called once per frame

    public string sceneToLoad;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) &&  !TextBox.isActive)
        {
            LoadNextLevel();
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
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
