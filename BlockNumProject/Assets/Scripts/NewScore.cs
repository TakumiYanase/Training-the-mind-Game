using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class NewScore : MonoBehaviour
{
    [Serializable]
    public struct RankingData
    {
        public int first;
        public int second;
        public int third;
        public int newScore;
    }

    private int m_newScore = 0;
    private Text m_text = null;

    const string SAVE_FILE_PATH = "Ranking.txt";

    void Start()
    {
        // フォルダからロード
        var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        var data = JsonUtility.FromJson<RankingData>(json);

        m_newScore = data.newScore;

        m_text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_text.text = m_newScore.ToString();
    }
}
