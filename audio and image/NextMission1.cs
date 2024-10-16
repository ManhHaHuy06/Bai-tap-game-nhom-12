using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMission1 : MonoBehaviour
{
    // This method will be triggered when the Start button is clicked
    public void StartGame()
    {
        // Ensure "SampleScenes" matches exactly with the scene name in Build Settings
        SceneManager.LoadScene("Mission2");
    }
}