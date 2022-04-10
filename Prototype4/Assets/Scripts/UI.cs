/*
 * Josh McGrew
 * Assignment 7 Prototype 4
 * manage ui
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text waveText;
    public Text gameText;
    public Text restartText;
    public Text helpText;
    public SpawnManager spwnMgr;
    public GameObject player;

    void Start()
    {
        //references and initialization
        spwnMgr = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        waveText.text = "Wave: 0";
        gameText.text = "";
        restartText.text = "Press 'R' to restart.";
        restartText.enabled = false;
        helpText.enabled = false;
        StartCoroutine(GameStartCoroutine());
    }

    //coroutine to display intro text until player presses space
    IEnumerator GameStartCoroutine()
    {
        spwnMgr.enabled = false;
        player.SetActive(false);
        helpText.enabled = true;
        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        helpText.enabled = false;
        player.SetActive(true);
        spwnMgr.enabled = true;
    }


    void Update()
    {
        //update text with the wave number
        waveText.text = "Wave: " + spwnMgr.waveNumber;

        //Lose game if player falls off
        if (player.transform.position.y < -10)
        {
            gameText.text = "You Lose!";
            restartText.enabled = true;
            spwnMgr.enabled = false;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        //win game if player beats wave 10
        if (spwnMgr.waveNumber == 11)
        {
            gameText.text = "You Win!";
            restartText.enabled = true;
            spwnMgr.enabled = false;
            player.SetActive(false);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
