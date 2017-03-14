using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  ゲームプレイシーン内、フェード関係
/// </summary>
public class GameSceneFade : MonoBehaviour {

    [SerializeField, Header("フェードに使用する画像")]
    Image m_WhiteImage;
    [SerializeField, Header("フェードの速度")]
    float m_FadeSpeed;

    Color m_FadeColor;

    /* 参照 */
    Fade m_Fade;
    GamePlayManager m_GamePlayManager;

    // フェードがアクティブ状態か
    bool m_IsActive;

    // シーンの始まり時のフェードが終了したか
    bool m_IsFadeEnd;

    void Awake()
    {
        m_Fade = this.GetComponent<Fade>();
        m_GamePlayManager = this.GetComponent<GamePlayManager>();
    }

	void Start ()
    {
        // フェードイン開始
        SceneBeginFade();
        m_IsFadeEnd = true;
    }

	void Update ()
    {
        SetAlpha();
	}

    /// <summary>
    ///  シーン開始時の演出
    /// </summary>
    void SceneBeginFade()
    {
        m_IsActive = true;
        m_FadeColor = new Color(1, 1, 1, 0.9f);
        m_Fade.ChangeSpeed(m_FadeSpeed);
        m_Fade.FadeOutStart();
    }

    /// <summary>
    ///  アクティブならアルファ値をセット
    /// </summary>
    void SetAlpha()
    {
        // フェード終了で処理しない
        if (!m_IsFadeEnd) return;

        // アルファ値の限界でactiveをfalseに
        if (m_FadeColor.a <= 0)
        {
            m_IsActive = false;
        }
        // trueのままなら継続して処理
        // falseならフェードを終了する
        if (m_IsActive)
        {
            m_FadeColor.a = m_Fade.GetAlpha();
            m_WhiteImage.color = m_FadeColor;
            m_Fade.IsFadeChange(false);
        }
        else
        {
            SetFadeStatusToGM();
            m_IsFadeEnd = false;
        }
    }

    /// <summary>
    ///  シーン開始時のフェード中か
    /// </summary>
    /// <returns>処理中ならtrue</returns>
    public bool IsFadeEnd()
    {
        return m_IsFadeEnd;
    }

    /// <summary>
    ///  フェードの状況をゲームマネージャーにセット
    /// </summary>
    void SetFadeStatusToGM()
    {
        m_GamePlayManager.SetFadeStatus(m_IsFadeEnd);
    }
}
