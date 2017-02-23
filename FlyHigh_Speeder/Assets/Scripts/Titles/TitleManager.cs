﻿using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  タイトルメニュー処理
/// </summary>
public class TitleManager : MonoBehaviour {

    // タイトルのプッシュスタート
    [SerializeField]
    private Image m_TitileSprites;

    // メニューのまとまりオブジェクト
    [SerializeField]
    private GameObject m_MenuObjects;

    /* それぞれの参照 */
    private TitleState m_TitleState;
    private MenuState m_MenuState;

    // 今の画面状態
    private int m_NowState;

    // コントローラーが接続されているか
    private bool m_IsConnectedController;


    void Awake()
    {    
        /* スクリプト参照を得る */
        m_TitleState = this.gameObject.GetComponent<TitleState>();
        m_MenuState = this.gameObject.GetComponent<MenuState>();
    }

    void Start ()
    {
        // コントローラー接続？
        IsConnectController();

        // 最初はタイトルから
        StateChange(SceneNum.TITLE_SCENE);
    }

	void Update () {
        
	}

    /// <summary>
    ///  今の画面状態をセットして
    ///  スプライトやスクリプトを切替
    /// </summary>
    /// <param name="_state">ステート</param>
    public void StateChange(SceneNum _state)
    {
        switch (_state)
        {
            case SceneNum.TITLE_SCENE:
                m_TitileSprites.enabled = true;
                m_MenuObjects.SetActive(false);
                m_NowState = (int)_state;

                m_TitleState.enabled = true;
                m_MenuState.enabled = false;
                break;

            case SceneNum.MENU_SCENE:
                m_TitileSprites.enabled = false;
                m_MenuObjects.SetActive(true);
                m_NowState = (int)_state;

                m_TitleState.enabled = false;
                m_MenuState.enabled = true;
                break;
        }
    }

    /// <summary>
    ///  コントローラーが接続されているかを設定
    /// </summary>
    private void IsConnectController()
    {
        // 接続されているコントローラを取得して、
        string[] controller = Input.GetJoystickNames();

        // 一台もコントローラが接続されていなければfalse
        if (controller[0] == "")
        {
            m_IsConnectedController = false;
            return;
        }

        // 接続されていればtrue
        m_IsConnectedController = true;
    }

    /// <summary>
    ///  今の画面状態を取得
    /// </summary>
    /// <returns></returns>
    public int GetNowSceneState()
    {
        return m_NowState;
    }

    /// <summary>
    ///  コントローラー接続がされているかを取得
    /// </summary>
    /// <returns></returns>
    public bool GetIsConnectedController()
    {
        return m_IsConnectedController;
    }
}
