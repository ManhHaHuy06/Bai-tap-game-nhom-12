using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoiceController2 : MonoBehaviour
{
    public Button optionButton1; // Nút lựa chọn 1
    public Button optionButton2; // Nút lựa chọn 2

    private void Start()
    {
        // Gán sự kiện cho các nút
        optionButton1.onClick.AddListener(OnOption1Selected);
        optionButton2.onClick.AddListener(OnOption2Selected);

        // Ẩn các nút ban đầu
        optionButton1.gameObject.SetActive(false);
        optionButton2.gameObject.SetActive(false);
    }

    public void ShowChoices()
    {
        // Hiện các nút lựa chọn
        optionButton1.gameObject.SetActive(true);
        optionButton2.gameObject.SetActive(true);
    }

    public void OnOption1Selected()
    {
        // Chuyển đến cảnh cho lựa chọn 1
        SceneManager.LoadScene("Ending1"); // Thay thế với tên cảnh bạn muốn
    }

    public void OnOption2Selected()
    {
        // Chuyển đến cảnh cho lựa chọn 2
        SceneManager.LoadScene("PQA2"); // Thay thế với tên cảnh bạn muốn
    }
}
