using UnityEngine;
using UnityEngine.SceneManagement;

public class continue2 : MonoBehaviour
{
    // This method will be triggered when the Start button is clicked
    public void StartGame()
    {
        // Ensure "Chuong1" matches exactly with the scene name in Build Settings
        SceneManager.LoadScene("S1.2");
    }
}