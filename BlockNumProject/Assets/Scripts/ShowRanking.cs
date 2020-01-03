using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

using Common;

public class ShowRanking : MonoBehaviour
{
    [SerializeField]
    private Text[] m_scoreText = new Text[Define.RANKING_LIST_END];
    [SerializeField]
    private Text[] m_dateText = new Text[Define.RANKING_LIST_END];

    private int[] m_score = new int[Define.RANKING_LIST_END];
    private int[] m_year = new int[Define.RANKING_LIST_END];
    private int[] m_month = new int[Define.RANKING_LIST_END];
    private int[] m_day = new int[Define.RANKING_LIST_END];

    public void Awake()
    {
        // フォルダからロード
        var info = new FileInfo(Application.dataPath + Define.SAVE_FILE_PATH);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        var data = JsonUtility.FromJson<ScoreUtility.RankingData>(json);

        m_score[0] = data.first;
        m_score[1] = data.second;
        m_score[2] = data.third;

        m_year[0] = data.yearFirst;
        m_year[1] = data.yearSecond;
        m_year[2] = data.yearThird;

        m_month[0] = data.monthFirst;
        m_month[1] = data.monthSecond;
        m_month[2] = data.monthThird;

        m_day[0] = data.dayFirst;
        m_day[1] = data.daySecond;
        m_day[2] = data.dayThird;

        for (int i = 0; i < Define.RANKING_LIST_END; i++)
        {
            string date = m_year[i].ToString() + " 年\n" + m_month[i].ToString() + " 月    " + m_day[i].ToString() + " 日";
            m_scoreText[i].text = m_score[i].ToString();
            m_dateText[i].text = date;
        }
    }
}
