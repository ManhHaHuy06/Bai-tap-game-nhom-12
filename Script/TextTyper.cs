using System.Collections;
using TMPro; // Đảm bảo bạn đã cài đặt TextMeshPro
using UnityEngine;

public class TextTyper : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Kéo đối tượng TextMeshPro vào đây trong Inspector
    public string fullText; // Chuỗi văn bản đầy đủ
    public float typingSpeed = 0.05f; // Thời gian giữa mỗi ký tự

    private void Start()
    {
        // Bắt đầu coroutine để đánh chữ
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        textMeshPro.text = ""; // Bắt đầu với một chuỗi trống

        foreach (char letter in fullText.ToCharArray())
        {
            textMeshPro.text += letter; // Thêm từng ký tự
            yield return new WaitForSeconds(typingSpeed); // Chờ một khoảng thời gian
        }
    }
}
