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

    // フェードがアクティブ状態か
    bool m_IsActive;

    void Awake()
    {
        m_Fade = this.GetComponent<Fade>();
    }

	void Start ()
    {
        m_Fade.IsFadeChange(false);
        m_Fade.FadeOutStart();
    }

	void Update ()
    {
        Debug.Log(m_Fade.GetAlpha());
        SetAlpha();
	}

    /// <summary>
    ///  シーン開始時の演出
    /// </summary>
    void SceneBeginFade()
    {
        m_IsActive = true;
        m_FadeColor = new Color(255, 255, 255, 255);
        m_Fade.IsFadeChange(false);
        m_Fade.ChangeSpeed(m_FadeSpeed);
        m_Fade.FadeOutStart();
    }

    /// <summary>
    ///  アクティブならアルファ値をセット
    /// </summary>
    void SetAlpha()
    {
        if (!m_IsActive && m_FadeColor.a >= 1) return;

        m_FadeColor.a = m_Fade.GetAlpha();
        m_WhiteImage.color = m_FadeColor;
    }
}
