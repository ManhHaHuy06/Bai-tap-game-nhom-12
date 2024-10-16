using UnityEngine;
using UnityEngine.Video;

public class PlayVideoOnStart : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
    }
}