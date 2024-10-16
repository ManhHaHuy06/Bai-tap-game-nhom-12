using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue1 : MonoBehaviour
{
    // This method will be triggered when the Continue button is clicked
    public void StartGame()
    {
        // Ensure "Chuong1" matches exactly with the scene name in Build Settings
        SceneManager.LoadScene("S1.1");
    }
}
