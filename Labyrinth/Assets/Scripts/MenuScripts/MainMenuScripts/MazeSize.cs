using UnityEngine;
using UnityEngine.UI;

public class MazeSizeDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public InputField widthInput;
    public InputField heightInput;

    private void Start()
    {
        dialogBox.SetActive(false);
    }

    public void ShowDialog()
    {
        dialogBox.SetActive(true);
    }

    public void OnConfirmButtonClicked()
    {
        // Get the width and height values from the input fields
        int width = int.Parse(widthInput.text);
        int height = int.Parse(heightInput.text);

        GenerateMaze(width, height);

        dialogBox.SetActive(false);
    }

    public void OnCancelButtonClicked()
    {
        dialogBox.SetActive(false);
    }

    private void GenerateMaze(int width, int height)
    {
        // TODO: CALL MAZEPARAMS.SETSIZE() HERE
    }
}
