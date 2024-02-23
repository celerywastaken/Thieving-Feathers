using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] Animator transitionAnim;   // Reference to the transition Animator
   

    public void StartGame() // Method to start the game
    {
        StartCoroutine(LoadScene());            // Start the coroutine to load the next scene
        DontDestroyOnLoad(this.gameObject);    // Don't destroy the GameManager when loading a new scene
    }

   public  IEnumerator LoadScene()  // Coroutine to load the next scene with transition animation
    {
        transitionAnim.SetTrigger("End");           // Trigger the "End" animation transition
        yield return new WaitForSeconds(2);        // Wait for 2 seconds
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);   // Load the next scene in the build index sequence
        transitionAnim.SetTrigger("Start");      // Trigger the "Start" animation transition
    }

    public void QuitGame()   // Method to quit the game
    {
        Application.Quit();
    }
}
