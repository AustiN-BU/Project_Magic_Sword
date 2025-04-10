/*****************************************************************************
// File Name : PauseMenu.cs
// Author : Austin Nelson
// Creation Date : April 3, 2025
//
// Brief Description : This is the Code for the Pause menu.
*****************************************************************************/
using Cinemachine;
using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    [SerializeField] public NPCConversation teammateConvo;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    } 


    // Update is called once per frame
   public void OnPause()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

   public void Resume()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.GetComponent<CharacterController>().enabled = true;
        CinemachineFreeLook camera = FindObjectOfType<CinemachineFreeLook>();
        camera.GetComponent<CinemachineFreeLook>().enabled = true;
        Boss boss = FindObjectOfType<Boss>();
        boss.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void Pause()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.GetComponent<CharacterController>().enabled = false;
        CinemachineFreeLook camera = FindObjectOfType<CinemachineFreeLook>();
        camera.GetComponent<CinemachineFreeLook>().enabled = false;
        Boss boss = FindObjectOfType<Boss>();
        boss.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void Teammate()
    {
        pauseMenuUI.SetActive(false);
        Debug.Log(message: "TeammateTalk");
        ConversationManager.Instance.StartConversation(teammateConvo);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnQuit()
    {
        Application.Quit();
        print("Game Closed.");
    }

}
