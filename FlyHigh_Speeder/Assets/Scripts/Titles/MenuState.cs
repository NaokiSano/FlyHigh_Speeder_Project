using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
///  メニュー状態の処理
/// </summary>
public class MenuState : MonoBehaviour {

    [SerializeField, Header("フェードアウトの白画像")]
    Image m_WhiteSprite;
    Color m_FadeColor;

    // 参照
    CameraZoomIn m_CameraZoomIn;
    TitleManager m_TitleManager;
    Fade m_Fade;
    ButtonSystem m_ButtonSystem;

    // フェードアウトフラグ
    bool m_IsFade;
    bool m_IsNext;

    void Awake()
    {
        // 参照
        m_TitleManager = this.GetComponent<TitleManager>();
        m_CameraZoomIn = this.GetComponent<CameraZoomIn>();
        m_Fade = this.GetComponent<Fade>();
        m_ButtonSystem = this.GetComponent<ButtonSystem>();
    }

    void Start ()
    {
        // 白状態
        m_FadeColor = new Color(255, 255, 255, 0);
  
        m_IsFade = false;
        m_IsNext = false;
	}

	void Update ()
    {
        m_ButtonSystem.ButtonUpdate();
        FadeIn();
    }
    
    /// <summary>
    ///  フェードアウト
    /// </summary>
    void FadeIn()
    {
        if (!m_IsFade) return;
        /* アルファ値をゲット、それをスプライトにセット */
        m_FadeColor.a = m_Fade.GetAlpha();
        m_WhiteSprite.color = m_FadeColor;
        if (m_FadeColor.a >= 1)
        {
            m_IsNext = true;
            /* 画像のフェードイン完了後、シーン遷移 */
            //SceneManager.LoadScene("GamePlay");
        }

        // フェードアウトが終了していない場合は遷移しない
        if (!m_IsNext) return;

        /* ボタン番号に対応するシーンに飛ぶ */
        if (IsSelectScene() == 0) SceneManager.LoadScene("GamePlay");
        else if (IsSelectScene() == 1) SceneManager.LoadScene("Credit");
    }

    /// <summary>
    ///  シーン遷移開始
    /// </summary>
    public void StartScene()
    {
        m_CameraZoomIn.ZoomInStart();
        FadeOutMenu();
    }

    /// <summary>
    ///  ボタン番号によるシーンの決定
    /// </summary>
    int IsSelectScene()
    {
        return m_ButtonSystem.GetNowSelectButton();
    }

    /// <summary>
    ///  フェードアウト開始
    /// </summary>
    void FadeOutMenu()
    {
        m_IsFade = true;
        m_Fade.SetDefaultAlpha(0);
        m_Fade.ResetAlpha();
        m_Fade.IsFadeChange(false);
        m_Fade.ChangeSpeed(0.0004f);
        m_Fade.FadeInStart();
    }

    /// <summary>
    ///  ゲーム終了
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
