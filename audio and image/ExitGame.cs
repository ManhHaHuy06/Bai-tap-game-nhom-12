using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Hàm này sẽ được gọi khi nhấn nút thoát
    public void QuitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();  // Thoát khỏi trò chơi
    }
}
