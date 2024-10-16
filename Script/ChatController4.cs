using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // Thêm thư viện để dùng UI Image
using TMPro;

public class ChatController4 : MonoBehaviour
{
    // Các biến public để gán từ Unity Editor
    public TextMeshProUGUI chatText;        // Text (TMP) để hiển thị hội thoại
    public AudioSource typingSound;         // Âm thanh gõ chữ
    public float typingSpeed = 0.05f;       // Tốc độ gõ chữ

    // Các biến để hiển thị hình ảnh nhân vật
    public Image characterLeftImage;        // Ảnh của nhân vật bên trái
    public Image characterRightImage;       // Ảnh của nhân vật bên phải
    public Sprite character1Sprite;         // Sprite cho nhân vật 1
    public Sprite character2Sprite;         // Sprite cho nhân vật 2

    // Nội dung hội thoại
    private string[] conversation = {
        "Chị Lan:*Bỗng có chuông điện, chị Lan quay đi trả lời điện thoại",
        "Quỳnh: Sợ hãi đứng nép vào một góc",
        "Chị Lan: Dạ vâng em hiểu rồi! Để em đưa nó vào. *Chị Lan cúp máy*",
        "Quỳnh;...",
        "Chị Lan: Đi vào đây! Nhanh!",
        "Quỳnh: ...",
        "Quỳnh:*Chị Lan, đưa quỳnh vào một phòng Karaoke, mở một chai rượu rót vào hai cốc*",
        "Chị Lan: Bài học đầu tiên của mày là phải biết uống rượu ",
        "Quỳnh: Chị ơi, em không làm được đâu",
        "Chị Lan: Đừng có nói nhiều! Uống nhanh!",
        " ",
    };

    private int conversationIndex = 0;      // Chỉ số câu hội thoại hiện tại

    // Khởi động hiển thị hội thoại
    private void Start()
    {
        StartCoroutine(TypeConversation());
    }

    // Hàm hiển thị hội thoại từng chữ
    private IEnumerator TypeConversation()
    {
        while (conversationIndex < conversation.Length)
        {
            string currentText = conversation[conversationIndex];

            // Hiển thị hình ảnh nhân vật tương ứng
            if (conversationIndex % 2 == 0) // Nhân vật 1 nói
            {
                characterLeftImage.gameObject.SetActive(true);
                characterLeftImage.sprite = character1Sprite;
                characterRightImage.gameObject.SetActive(false);  // Ẩn hình nhân vật 2
            }
            else // Nhân vật 2 nói
            {
                characterRightImage.gameObject.SetActive(true);
                characterLeftImage.gameObject.SetActive(false);  // Ẩn hình nhân vật 1
                characterRightImage.sprite = character2Sprite;
            }

            // Gọi hàm hiển thị từng ký tự
            yield return StartCoroutine(TypeText(currentText));

            // Đợi trước khi chuyển đến hội thoại tiếp theo
            yield return new WaitForSeconds(1.5f);

            // Tăng chỉ số để chuyển đến đoạn hội thoại kế tiếp
            conversationIndex++;
        }
        FindObjectOfType<ChoiceController3>().ShowChoices();
    }

    // Hiệu ứng gõ từng ký tự
    private IEnumerator TypeText(string text)
    {
        chatText.text = "";  // Xóa nội dung cũ
        typingSound.Play();  // Phát âm thanh khi bắt đầu gõ

        foreach (char letter in text.ToCharArray())
        {
            chatText.text += letter;  // Thêm từng ký tự vào Text
            yield return new WaitForSeconds(typingSpeed);  // Chờ một chút giữa mỗi ký tự
        }

        typingSound.Stop();  // Dừng âm thanh sau khi gõ xong
    }
}
