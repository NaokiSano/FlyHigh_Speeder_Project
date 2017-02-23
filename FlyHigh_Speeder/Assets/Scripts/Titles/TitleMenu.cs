using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///  タイトルメニュー処理
/// </summary>
public class TitleMenu : MonoBehaviour {

    // タイトル画面でのスプライト群
    [SerializeField]
    private Image[] m_TitileSprites;

    // メニュー移行後のスプライト群
    [SerializeField]
    private Image[] m_MenuSprites;

    // 今の画面状態を設定
    private enum m_ScreenState { m_TITLE_SCENE = 0,
                               m_MENU_SCENE = 1 };

    private int m_NowState;

	// Use this for initialization
	void Start () {
        // 最初はタイトルから
        m_NowState = 0; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    ///  コントローラーが接続されているか
    /// </summary>
    bool IsConnectController()
    {
        // 接続されているコントローラを取得して、
        string[] controller = Input.GetJoystickNames();

        // 一台もコントローラが接続されていなければfalse
        if (controller[0] == "") return false;

        // 接続されていればtrue
        return true;
    }
}
