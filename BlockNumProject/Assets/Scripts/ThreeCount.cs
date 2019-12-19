using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThreeCount : MonoBehaviour
{
    [SerializeField]
    private Image m_go = null;
    [SerializeField]
    private Image m_one = null;
    [SerializeField]
    private Image m_two = null;
    [SerializeField]
    private Image m_three = null;

    [SerializeField]
    private SceneController m_sceneController = null;

    public void Start()
    {
        m_go.gameObject.SetActive(false);
        m_one.gameObject.SetActive(false);
        m_two.gameObject.SetActive(false);
        m_three.gameObject.SetActive(true);

        StartCoroutine(this.DelayMethod(1.0f, CountThree));
        StartCoroutine(this.DelayMethod(2.0f, CountTwo));
        StartCoroutine(this.DelayMethod(3.0f, CountOne));
        StartCoroutine(this.DelayMethod(4.0f, CountGo));
    }

    #region CountDown

    private void CountGo()
    {
        // Prefab を取得
        GameObject countDown = (GameObject)Resources.Load("Prefabs/CountDown");
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
    }

    private void CountTwo()
    {
        m_two.gameObject.SetActive(false);
        m_one.gameObject.SetActive(true);
    }

    private void CountThree()
    {
        m_three.gameObject.SetActive(false);
        m_two.gameObject.SetActive(true);
    }
    #endregion
}
