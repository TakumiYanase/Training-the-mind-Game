using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InputField), typeof(Text), typeof(AudioSource))]

public class GameController : MonoBehaviour
{
    [SerializeField, HeaderAttribute("InputField")]
    private InputField m_inputField;

    [SerializeField, HeaderAttribute("Text Data"), Space(5)]
    private Text m_text;

    [SerializeField]
    private Text m_answerText;

    [SerializeField, HeaderAttribute("Image Data"), Space(5)]
    private Image m_correctAnswer = null;
    [SerializeField]
    private Image m_incorrectAnswer = null;

    [SerializeField, HeaderAttribute("SE Data"), Space(5)]
    private AudioClip m_correctSE = null;
    [SerializeField]
    private AudioClip m_incorrectSE = null;

    private AudioSource m_audioSource = null;

    private bool m_correctFlag = false;
    private bool m_incorrectFlag = false;

    [SerializeField, HeaderAttribute("SceneController Prefab"), Space(5)]
    private SceneController m_sceneController = null;

    private CountDown m_countDown = null;

    void Start()
    {
        m_inputField = m_inputField.GetComponent<InputField>();
        m_inputField.ActivateInputField();
        m_text = m_text.GetComponent<Text>();
        m_answerText = m_answerText.GetComponent<Text>();
        m_audioSource = GetComponent<AudioSource>();
        m_countDown = GameObject.Find("CountDown(Clone)").GetComponent<CountDown>();

        m_correctAnswer.gameObject.SetActive(false);
        m_incorrectAnswer.gameObject.SetActive(false);
    }

    void Update()
    {
        if (m_correctFlag)
            StartCoroutine(this.DelayMethod(1.0f, NextStage));

        if(m_incorrectFlag)
            StartCoroutine(this.DelayMethod(1.0f, NextStage));
    }

    public void InputText()
    {
        m_text.text = m_inputField.text;
    }

    public void CheckAnswer()
    {
        // 判定
        if (m_inputField.text == m_answerText.text)
        {
            m_correctAnswer.gameObject.SetActive(true);
            m_audioSource.PlayOneShot(m_correctSE);
            m_correctFlag = true;
            m_countDown.AddScore();
        }
        else
        {
            m_incorrectAnswer.gameObject.SetActive(true);
            m_audioSource.PlayOneShot(m_incorrectSE);
            m_incorrectFlag = true;
        }
    }

    public void NextStage()
    {
        // ランダムにステージ遷移
        SceneController sceneContoroller = m_sceneController.GetComponent<SceneController>();
        sceneContoroller.RandomStage();
    }
}