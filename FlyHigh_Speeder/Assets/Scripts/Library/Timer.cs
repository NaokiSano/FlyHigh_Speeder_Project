using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  タイマー
/// </summary>
public class Timer{

    // 今のタイム
    private float m_NowTime;

    // カウントダウン時間
    private float m_MaxTime;

    // 作動しているか
    private bool m_IsPlaying;

    // コンストラクタ
    public Timer()
    {
        Initialize();
    }

	/// <summary>
    ///  初期化
    /// </summary>
	public void Initialize ()
    {
        m_NowTime = 0f;
        m_MaxTime = 0f;
        m_IsPlaying = false;	
	}

    /// <summary>
    ///  タイマーをセット&今のタイムも初期値へ
    /// </summary>
    /// <param name="_setTime">タイマーのカウント秒数</param>
    public void SetTime(float _setTime)
    {
        m_MaxTime = _setTime;
        m_NowTime = m_MaxTime;
    }

    /// <summary>
    ///  作動開始
    /// </summary>
    public void Start()
    {
        m_IsPlaying = true;
    }

    /// <summary>
    ///  作動停止
    /// </summary>
    public void Stop()
    {
        m_IsPlaying = false;
        m_NowTime = m_MaxTime;
    }
	
    /// <summary>
    ///  更新
    /// </summary>
	void Update ()
    {
        // 開始処理がなされていなければ更新しない
        if (!m_IsPlaying) return;

        m_NowTime -= Time.deltaTime;

        // 0以下にはならない
        m_NowTime = Mathf.Max(m_NowTime, 0f);
	}

    /// <summary>
    ///  タイマーが終了したか
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        return m_NowTime <= 0f;
    }
}
