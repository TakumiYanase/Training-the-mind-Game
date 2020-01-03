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

        this.StartCoroutine(CountDown());
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

    protected IEnumerator CountDown()
    {
        var wait = new WaitForSeconds(1.0f);

        var countObj = new Image[] { m_go, m_one, m_two, m_three };
        var clips = new AudioClip[] { m_goSE, m_threeCountSE, m_threeCountSE, m_threeCountSE };

        for (int i = countObj.Length - 1; i >= 0; --i)
        {
            countObj[i].gameObject.SetActive(true);
            m_audioSource.PlayOneShot(clips[i]);
            yield return wait;
            countObj[i].gameObject.SetActive(false);
        }

        m_go.gameObject.SetActive(true);
        CountGo();
    }
    #endregion
}
