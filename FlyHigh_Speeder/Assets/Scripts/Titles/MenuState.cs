using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
///  メニュー状態の処理
/// </summary>
public class MenuState : MonoBehaviour {

    [SerializeField, Header("メニュー移行後の画像とボタン群")]
    GameObject[] m_MenuItems;
    Image[] m_MenuSprites;
    Button[] m_MenuButtons;

    [SerializeField, Header("フェードアウトの白画像")]
    Image m_WhiteSprite;
    Color m_FadeColor;

    // 参照
    CameraZoomIn m_CameraZoomIn;
    TitleManager m_TitleManager;
    Fade m_Fade;

    // 選択状態にあるボタン数字
    int m_SelectNum;
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

        // メニューの項目数に合わせて作る
        m_MenuSprites = new Image[m_MenuItems.Length];
        m_MenuButtons = new Button[m_MenuItems.Length];

        // ボタンとその画像を参照取得
        for(int i=0; i<m_MenuItems.Length; i++)
        { 
            m_MenuButtons[i] = m_MenuItems[i].GetComponent<Button>();
            m_MenuSprites[i] = m_MenuItems[i].GetComponent<Image>();
        }
    }

    void Start ()
    {
        // コントローラー接続状態を取得
        m_IsController = m_TitleManager.GetIsConnectedController();
        m_SelectNum = 0;
        m_IsAxis = true;

        // 白状態
        m_FadeColor = new Color(255, 255, 255, 0);
  
        m_IsFade = false;
	}

	void Update ()
    {
        SelectItems();
        ButtonHighLight();
        FadeIn();
    }

    // 項目のセレクト
    void SelectItems()
    {
        /* 対応キーでボタン選択移動 */
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_SelectNum++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_SelectNum--;
        }

        /* スティックの傾いた方に選択移動 */
        if(m_IsController)
        {
            float joy = Input.GetAxis("Vertical2");

            if (joy < 0 && m_IsAxis)
            {
                m_SelectNum++;
                m_IsAxis = false;
            }
            else if(joy > 0 && m_IsAxis)
            {
                m_SelectNum--;
                m_IsAxis = false;
            }

            // スティックを戻したら再度入力受付
            // 連続でボタン選択が移動してしまうのを防ぐため
            if (joy == 0) m_IsAxis = true;
        }

        if (m_SelectNum >= 2) m_SelectNum = 2;
        else if (m_SelectNum <= 0) m_SelectNum = 0;
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

    /// <summary>
    ///  今選択状態にあるボタンをハイライト
    /// </summary>
    void ButtonHighLight()
    {
        m_MenuButtons[m_SelectNum].Select();
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
