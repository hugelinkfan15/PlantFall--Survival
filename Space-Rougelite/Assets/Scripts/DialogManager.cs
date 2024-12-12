using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Import Scene Management

public class DialogManager : MonoBehaviour
{
    public TMP_Text textbox;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    // Set references in the Inspector
    public GameObject continueButton;
    public GameObject dialogPanel;

    // Optional: Specify the name of the next scene in the Inspector
    public string nextSceneName;

    void OnEnable()
    {
        index = 0; // Ensure index starts at 0 when the dialog is enabled
        continueButton.SetActive(false);
        StartCoroutine(Type());
        
    }

    IEnumerator Type()
    {
        textbox.text = "";
        foreach (char letter in sentences[index])
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueButton.SetActive(true);
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textbox.text = "";
            StartCoroutine(Type());
        }
        else
        {
            // Final dialog reached
            textbox.text = "";
            dialogPanel.SetActive(false);
           

            // Load the next scene
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // Option 1: Using the scene name specified in the Inspector
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            // Option 2: Load the next scene based on build index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    } 
}
