using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

using Common;

public class NewScore : MonoBehaviour
{
    private int m_newScore = 0;
    private Text m_text = null;

    public void Awake()
    {
        // フォルダからロード
        var info = new FileInfo(Application.dataPath + Define.SAVE_FILE_PATH);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        var data = JsonUtility.FromJson<ScoreUtility.RankingData>(json);

        m_newScore = data.newScore;
        m_text = this.gameObject.GetComponent<Text>();
        m_text.text = m_newScore.ToString();
    }
}
