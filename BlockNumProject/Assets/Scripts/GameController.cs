using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Common;

[RequireComponent(typeof(InputFieldEX), typeof(Text), typeof(AudioSource))]

public class GameController : MonoBehaviour
{
    [SerializeField, HeaderAttribute("InputField")]
    private InputFieldEX m_inputField;

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

    [SerializeField, HeaderAttribute("SceneController Prefab"), Space(5)]
    private SceneController m_sceneController = null;

    private CountDown m_countDown = null;
    private bool m_correctFlag;
    private bool m_incorrectFlag;

    public void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_countDown = GameObject.Find(Define.COUNT_DOWN_PREFAB).GetComponent<CountDown>();

        m_correctFlag = false;
        m_incorrectFlag = false;

        m_correctAnswer.gameObject.SetActive(false);
        m_incorrectAnswer.gameObject.SetActive(false);
    }

    public void Start()
    {
        m_inputField.ActivateInputField();
        m_inputField.onEndEdit.AddListener((arg) => { CheckAnswer(); });
        
    }
 
    public void Update()
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
        if (string.IsNullOrEmpty(m_inputField.text))
        {
            m_inputField.ActivateInputField();
            return;
        }

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