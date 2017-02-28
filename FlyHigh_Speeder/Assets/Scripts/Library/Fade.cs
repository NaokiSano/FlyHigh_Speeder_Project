using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour{

    // デフォルトアルファ値
    [SerializeField]
    private float m_DefaultAlpha;

    // フェードのスピード
    private float m_Speed;
    // アルファ値
    private float m_Alpha;

    //フェードインしているか？
    private bool m_IsFadeIn;
    //フェードアウトしているか？
    private bool m_IsFadeOut;

    // フェードを利用した点滅系処理用フラグ
    private bool m_ChangeFade;

    void Start()
    {
        m_Alpha = m_DefaultAlpha;

        m_ChangeFade = true;
    }

    void Update()
    {
        FadeIn();
        FadeOut();
    }

    // フェードイン
    private void FadeIn()
    {
        if (!m_IsFadeIn) return;

        /* アルファ値を増やしていく */
        float plus = m_Speed / Time.deltaTime;
        m_Alpha += plus;
        m_Alpha = Clamp.ClampFloat(m_Alpha, 0, 1);

        /* 点滅有効なら、フェードイン後にフェードアウトへ */
        if (!m_ChangeFade) return;

        if (m_Alpha >= 1)
        {
            FadeOutStart();
        }
    }

    // フェードアウト
    private void FadeOut()
    {
        if (!m_IsFadeOut) return;

        /* アルファ値を減らしていく */
        float minus =  m_Speed / Time.deltaTime;
        m_Alpha -= minus;
        m_Alpha = Clamp.ClampFloat(m_Alpha, 0, 1);

        /* 点滅有効なら、フェードアウト後にフェードインへ */
        if (!m_ChangeFade) return;

        if(m_Alpha <= 0)
        {
            FadeInStart();
        }
    }

    /// <summary>
    ///  フェードインスタート
    /// </summary>
    public void FadeInStart()
    {
        m_IsFadeIn = true;
        m_IsFadeOut = false;
    }

    /// <summary>
    ///  フェードアウトスタート
    /// </summary>
    public void FadeOutStart()
    {
        m_IsFadeIn = false;
        m_IsFadeOut = true;
    }

    /// <summary>
    ///  フェード速度変更
    /// </summary>
    /// <param name="_speed">スピード</param>
    public void ChangeSpeed(float _speed)
    {
        m_Speed = _speed;
    }

    /// <summary>
    ///  点滅っぽくするか
    /// </summary>
    /// <param name="_isActive"></param>
    public void IsFadeChange(bool _isActive)
    {
        m_ChangeFade = _isActive;
    }

    /// <summary>
    ///  アルファ値取得
    /// </summary>
    /// <returns></returns>
    public float GetAlpha()
    {
        return m_Alpha;
    }

    /// <summary>
    ///  ストップしてリセット
    /// </summary>
    public void StopAndReset()
    {
        m_IsFadeIn = false;
        m_IsFadeOut = false;
        m_Alpha = m_DefaultAlpha;
    }
}
