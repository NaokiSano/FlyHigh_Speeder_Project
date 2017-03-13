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
        SceneBeginFade();
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
        m_FadeColor = new Color(255, 255, 255, 1);
        m_Fade.ChangeSpeed(m_FadeSpeed);
        m_Fade.FadeOutStart();
    }

    /// <summary>
    ///  アクティブならアルファ値をセット
    /// </summary>
    void SetAlpha()
    {
        if (!m_IsActive) return;
        m_FadeColor.a = m_Fade.GetAlpha();
        m_WhiteImage.color = m_FadeColor;
        m_Fade.IsFadeChange(false);
    }
}
