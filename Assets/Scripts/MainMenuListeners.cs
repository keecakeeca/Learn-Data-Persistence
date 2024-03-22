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
        PersistenceManager.Instance.CurrentName = _textInput.text;

        SceneManager.LoadScene("main");
    }

    private void Start()
    {
        _textInput.text = PersistenceManager.Instance.CurrentName;
        InputValueChanged(_textInput.text);
    }

}
