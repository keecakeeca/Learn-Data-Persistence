using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuListeners : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_InputField _textInput;

    public void InputValueChanged(string value)
    {
        _startButton.interactable = value.Length >= 2;
    }

    public void StartGame()
    {
        PersistenceManager.Instance.SetPlayerName(_textInput.text);

        SceneManager.LoadScene("main");
    }

    private void Start()
    {
        // TODO: fetch persistence data from disk
        // and make button interactable whether player name length >= 2

        _startButton.interactable = false;
    }

}
