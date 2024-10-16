using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro; // Thêm dòng này để sử dụng TextMeshPro

public class SceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Video player component
    public TextMeshProUGUI chapterTitle; // TextMeshPro component for the chapter title
    public float titleDisplayTime = 1f; // Time to display the title
    public float videoDisplayTime = 68f; // Time video will play
    private void Start()
    {
        StartCoroutine(PlayScene());
    }

    private IEnumerator PlayScene()
    {
        // Hiển thị tiêu đề chương
        chapterTitle.gameObject.SetActive(true);
        yield return new WaitForSeconds(titleDisplayTime);

        // Biến mất tiêu đề
        chapterTitle.gameObject.SetActive(false);

        // Chuyển dần vào video
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.Play();

        
    }

}
