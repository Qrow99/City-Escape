using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //public Animator transition; Might try to animate a fade in later

    public float transitionTime = 1f;
    public PlayerMovement player;
    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void Deathscreen()
    {
        player.canMove = false;
        gameObject.SetActive(true);
    }
}
