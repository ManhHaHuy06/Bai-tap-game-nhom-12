using UnityEngine;
using UnityEngine.SceneManagement;

public class Playagain : MonoBehaviour
{
    // This method will be triggered when the Start button is clicked
    public void StartGame()
    {
        Debug.Log("Button pressed!");
        SceneManager.LoadScene("Menu");
    }
}