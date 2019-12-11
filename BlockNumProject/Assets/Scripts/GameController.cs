using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InputField), typeof(Text), typeof(AudioSource))]

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

    [SerializeField]
    private Image _rankS;
    [SerializeField]
    private Image _rankA;
    [SerializeField]
    private Image _rankB;

    [SerializeField, HeaderAttribute("Button Data"), Space(5)]
    private Button _retry;
    [SerializeField]
    private Button _stageSelect;
    [SerializeField]
    private Button _nextStage;

    [SerializeField,HeaderAttribute("SE Data"), Space(5)]
    private AudioClip _correctSE;
    [SerializeField]
    private AudioClip _incorrectSE;
    [SerializeField]
    private AudioClip _gameOverSE;

    private AudioSource _audioSource;

    [SerializeField,Range(1,25),HeaderAttribute("Stage Number"), TooltipAttribute("ステージのナンバーを入力する"),Space(5)]
    private int _stageNum;

    [SerializeField, Range(3.0f, 99.0f), HeaderAttribute("Limited Time"), TooltipAttribute("ステージの制限時間を入力する"), Space(5)]
    private float _countTime = 5.0f;

    private bool _correctFlag = false;
    private bool _incorrectFlag = false;
    private bool _gameOverFlag = false;

    private int _seconds = 99;

    void Start()
    {
        // GetComponent.
        _inputField = _inputField.GetComponent<InputField>();
        _text = _text.GetComponent<Text>();
        _answerText = _answerText.GetComponent<Text>();
        _countDownText = _countDownText.GetComponent<Text>();
        _audioSource = GetComponent<AudioSource>();

        _correctAnswer.gameObject.SetActive(false);
        _incorrectAnswer.gameObject.SetActive(false);
        _retry.gameObject.SetActive(false);
        _stageSelect.gameObject.SetActive(false);
        _nextStage.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(false);
        _rankS.gameObject.SetActive(false);
        _rankA.gameObject.SetActive(false);
        _rankB.gameObject.SetActive(false);
    }

    void Update()
    {
        // Count Down.
        {
            if (_countTime > 0)
            {
                _countTime -= Time.deltaTime;

                if (!_correctFlag && !_incorrectFlag && !_gameOverFlag)
                {
                    _seconds = (int)_countTime;
                }

                _countDownText.text = _seconds.ToString();
            }
        }
            // Correct answer.
            {
                if (_correctFlag)
            {
                _stageSelect.gameObject.SetActive(true);

                // Check time and display score rank.
                CheckTime(_seconds);

                if (_stageNum != 15)
                    _nextStage.gameObject.SetActive(true);
            }
        }

        // Incorrect answer.
        if (_incorrectFlag)
        {
            _retry.gameObject.SetActive(true);
            _stageSelect.gameObject.SetActive(true);
        }

        if (_seconds <= 0)
            _gameOverFlag = true;

        // Game over.
        if (_gameOverFlag && !_gameOver.gameObject.activeInHierarchy)
        {
            _audioSource.PlayOneShot(_gameOverSE);
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
            _audioSource.PlayOneShot(_correctSE);
            _correctFlag = true;
        }
        else
        {
            _incorrectAnswer.gameObject.SetActive(true);
            _audioSource.PlayOneShot(_incorrectSE);
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

    public void NextStage()
    {
        SceneManager.LoadScene("Stage" + (_stageNum + 1) + "Scene");
    }

    public void CheckTime(float seconds)
    {
        if (seconds >= 41 && seconds <= 60)
            _rankS.gameObject.SetActive(true);

        if (seconds >= 21 && seconds <= 40)
            _rankA.gameObject.SetActive(true);

        if (seconds >= 1 && seconds <= 20)
            _rankB.gameObject.SetActive(true);
    }
}