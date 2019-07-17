using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField, HeaderAttribute("InputField")]
    private InputField _inputField;

    [SerializeField, HeaderAttribute("Text Data"), Space(5)]
    private Text _text;

    [SerializeField]
    private Text _countDownText;

    [SerializeField]
    private Text _answerText;

    [SerializeField,HeaderAttribute("Image Data"), Space(5)]
    private Image _correctAnswer;
    [SerializeField]
    private Image _incorrectAnswer;
    [SerializeField]
    private Image _gameOver;

    [SerializeField, HeaderAttribute("Button Data"), Space(5)]
    private Button _retry;
    [SerializeField]
    private Button _stageSelect;

    [SerializeField,Range(1,15),HeaderAttribute("Stage Number"), TooltipAttribute("ステージのナンバーを入力する"),Space(5)]
    private int _stageNum;

    [SerializeField, Range(3.0f, 10.0f), HeaderAttribute("Limited Time"), TooltipAttribute("ステージの制限時間を入力する"), Space(5)]
    private float _countTime = 5.0f;

    // Count for scene transition.
    private int _count = 60;

    private bool _correctFlag = false;
    private bool _incorrectFlag = false;

    private int _seconds = 0;

    void Start()
    {
        // GetComponent.
        _inputField = _inputField.GetComponent<InputField>();
        _text = _text.GetComponent<Text>();
        _answerText = _answerText.GetComponent<Text>();
        _countDownText = _countDownText.GetComponent<Text>();

        _correctAnswer.gameObject.SetActive(false);
        _incorrectAnswer.gameObject.SetActive(false);
        _retry.gameObject.SetActive(false);
        _stageSelect.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(false);
    }

    void Update()
    {
        // Count Down.
        if (_countTime > 0)
        {
            _countTime -= Time.deltaTime;
            _seconds = (int)_countTime;
            _countDownText.text = _seconds.ToString();
        }

        // Correct answer.
        {
            if (_correctFlag)
                _count--;

            if (_count < 0)
                SceneManager.LoadScene("StageSelectScene");
        }

        // Incorrect answer.
        if (_incorrectFlag)
        {
            _retry.gameObject.SetActive(true);
            _stageSelect.gameObject.SetActive(true);
        }

       // Game over.
       if(_seconds <= 0)
        {
            _gameOver.gameObject.SetActive(true);
            _retry.gameObject.SetActive(true);
            _stageSelect.gameObject.SetActive(true);
        }
    }

    public void InputText()
    {
        // _inputField reflect.
        _text.text = _inputField.text;
    }

    public void CheckAnswer()
    {
        // Judge an input value.
        if (_inputField.text == _answerText.text)
        {
            _correctAnswer.gameObject.SetActive(true);

            _correctFlag = true;
        }
        else
        {
            _incorrectAnswer.gameObject.SetActive(true);

            _incorrectFlag = true;
        }
    }

    public void SelectRetry()
    {
        SceneManager.LoadScene("Stage" + _stageNum + "Scene");
    }

    public void ReturnStageSelect()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}