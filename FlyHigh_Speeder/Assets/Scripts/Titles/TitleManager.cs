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
    private Image[] m_MenuSprites;

    [SerializeField]
    private GameObject m_MenuObjects;


    // Use this for initialization
    void Start () {
        // 最初はタイトルから
        StateChange((int)SceneNum.TITLE_SCENE);
    }
	
	// Update is called once per frame
	void Update () {
		
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
                m_MenuObjects.SetActive(false);
                break;
        }
    }

    /// <summary>
    ///  コントローラーが接続されているか
    /// </summary>
    private bool IsConnectController()
    {
        // 接続されているコントローラを取得して、
        string[] controller = Input.GetJoystickNames();

        // 一台もコントローラが接続されていなければfalse
        if (controller[0] == "") return false;

        // 接続されていればtrue
        return true;
    }
}
