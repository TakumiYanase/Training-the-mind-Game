using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Common;

[RequireComponent(typeof(AudioSource))]

public class ThreeCount : MonoBehaviour
{
    [SerializeField, HeaderAttribute("Image Dara")]
    private Image m_go = null;
    [SerializeField]
    private Image m_one = null;
    [SerializeField]
    private Image m_two = null;
    [SerializeField]
    private Image m_three = null;

    [SerializeField]
    private SceneController m_sceneController = null;

    [SerializeField, HeaderAttribute("SE Data"), Space(5)]
    private AudioClip m_goSE = null;
    [SerializeField]
    private AudioClip m_threeCountSE = null;
    private AudioSource m_audioSource = null;

    public void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();

        m_go.gameObject.SetActive(false);
        m_one.gameObject.SetActive(false);
        m_two.gameObject.SetActive(false);
        m_three.gameObject.SetActive(true);

        m_audioSource.PlayOneShot(m_threeCountSE);

        StartCoroutine(this.DelayMethod(1.0f, CountThree));
        StartCoroutine(this.DelayMethod(2.0f, CountTwo));
        StartCoroutine(this.DelayMethod(3.0f, CountOne));
        StartCoroutine(this.DelayMethod(4.0f, CountGo));
    }

    #region CountDown

    private void CountGo()
    {
        // Prefab を取得
        GameObject countDown = (GameObject)Resources.Load(Define.PREFAB_PATH);
        // Prefab からインスタンス化
        var obj = Instantiate(countDown);
        if (obj != null) DontDestroyOnLoad(obj);

        // ランダムにステージ遷移
        SceneController sceneContoroller = m_sceneController.GetComponent<SceneController>();
        sceneContoroller.RandomStage();
    }

    private void CountOne()
    {
        m_one.gameObject.SetActive(false);
        m_go.gameObject.SetActive(true);
        m_audioSource.PlayOneShot(m_goSE);
    }

    private void CountTwo()
    {
        m_two.gameObject.SetActive(false);
        m_one.gameObject.SetActive(true);
        m_audioSource.PlayOneShot(m_threeCountSE);
    }

    private void CountThree()
    {
        m_three.gameObject.SetActive(false);
        m_two.gameObject.SetActive(true);
        m_audioSource.PlayOneShot(m_threeCountSE);
    }
    #endregion
}
