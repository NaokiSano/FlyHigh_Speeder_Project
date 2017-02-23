using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  タイトルメニュー処理
/// </summary>
public class TitleManager : MonoBehaviour {

    // タイトルのプッシュスタート
    [SerializeField]
    private Image m_TitileSprites;

    // メニュー移行後のスプライト群
    [SerializeField]
    private Button[] m_MenuSprites;

    // メニューのまとまりオブジェクト
    [SerializeField]
    private GameObject m_MenuObjects;

    // 今の画面状態
    private int m_NowState;

    // コントローラーが接続されているか
    private bool m_IsConnectedController;

    // Use this for initialization
    void Start () {
        // コントローラー接続？
        IsConnectController();

        // 最初はタイトルから
        StateChange(SceneNum.TITLE_SCENE);
    }
	
	// Update is called once per frame
	void Update () {
        TitieControll();
	}

    private void TitieControll()
    {
        // 今の状態がタイトル状態以外なら処理しない
        if (m_NowState != (int)SceneNum.TITLE_SCENE) return;

        // スペースキーでメニュー状態に移行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StateChange(SceneNum.MENU_SCENE);

        }

        if (!m_IsConnectedController) return;

        // コントローラーが接続されてればコントローラーのボタンも検知
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Submit"))
        {
            StateChange(SceneNum.MENU_SCENE);
        }

    }

    /// <summary>
    ///  今の画面状態をセットしてスプライトを切替
    /// </summary>
    /// <param name="_state">ステート</param>
    private void StateChange(SceneNum _state)
    {
        switch (_state)
        {
            case SceneNum.TITLE_SCENE:
                m_TitileSprites.enabled = true;
                m_MenuObjects.SetActive(false);
                m_NowState = (int)_state;
                break;

            case SceneNum.MENU_SCENE:
                m_TitileSprites.enabled = false;
                m_MenuObjects.SetActive(true);
                m_NowState = (int)_state;
                break;
        }
    }

    /// <summary>
    ///  コントローラーが接続されているか
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
}
