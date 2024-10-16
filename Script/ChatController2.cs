using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // Thêm thư viện để dùng UI Image
using TMPro;

public class ChatController2 : MonoBehaviour
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
        "Captain Snowball: Hello puppy!",
        "Max: Captain Snowball! How can i help you, sir?",
        "Captain Snowball: Hmm.. Good. My little lissy, she lost her favourite car.",
        "Max: Oh no! Really! Have you found it?",
        "Captain Snowball: Well! That's exactly why i'm here! The last time i saw her playing with it was here!",
        "Max: What! How... How could it be! i swear i didn't do anything!",
        "Captain Snowball: It's okay! I trust you... for now.",
        "Max: As you mentioned it, i remember we did playing with that car, oh no...Oh no. This is bad",
        "Captain Snowball; What's it boy? Tell me",
        "Max: I think she might have dropped it to the BASEMENT!",
        "Captain Snowball: Dear lord, lead me there quickly!",
        "Max: Right this way captain! Oh, but you have to slove a quiz in order to get in there",
        "Captain Snowball: Pieces of cake!",
        "Max: The question is: x^5.e^(x^2).sin(x^3); You need to evaluate its 50th derivative at the point where x equals 0",
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
        FindObjectOfType<ChoiceController2>().ShowChoices();
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
