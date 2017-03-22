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

    // コントローラーの状態
    bool m_IsController, m_IsAxis;
    // フェードアウトフラグ
    bool m_IsFade;

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
        // コントローラー接続状態を取得
        m_IsController = m_TitleManager.GetIsConnectedController();
        m_IsAxis = true;

        // 白状態
        m_FadeColor = new Color(255, 255, 255, 0);
  
        m_IsFade = false;
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
            /* 画像のフェードイン完了後、シーン遷移 */
            SceneManager.LoadScene("GamePlay");
        }
    }

    public void GameStart()
    {
        m_CameraZoomIn.ZoomInStart();
    }

    /// <summary>
    ///  フェードアウト開始
    /// </summary>
    public void FadeOutMenu()
    {
        m_IsFade = true;
        m_Fade.SetDefaultAlpha(0);
        m_Fade.ResetAlpha();
        m_Fade.IsFadeChange(false);
        m_Fade.ChangeSpeed(0.0004f);
        m_Fade.FadeInStart();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
