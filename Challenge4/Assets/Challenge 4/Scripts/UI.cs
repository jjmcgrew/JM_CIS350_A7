/*
 * Josh McGrew
 * Assignment 7 Challenge 4
 * ui manager
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text mainText;
    public Text waveText;
    public Text introText;
    public SpawnManagerX smx;
    public GameObject player;

    void Start()
    {
        //initializations
        smx = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
        mainText.text = "";
        waveText.text = "Wave: 0";
        introText.enabled = false;
        StartCoroutine(GameStartCoroutine());
    }

    //coroutine to display intro text until player presses space
    IEnumerator GameStartCoroutine()
    {
        //smx.enabled = false;
        //player.SetActive(false);
        introText.enabled = true;
        while (!Input.GetKeyDown(KeyCode.Space)) { yield return null; }
        introText.enabled = false;
        //player.SetActive(true);
        //smx.enabled = true;
    }

    void Update()
    {
        //update text with the wave number
        waveText.text = "Wave: " + smx.waveCount;

        //win game if player beats wave 10
        if (smx.waveCount == 11)
        {
            mainText.text = "You Win!\nPress R to restart.";
            //smx.enabled = false;
            //player.SetActive(false);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
