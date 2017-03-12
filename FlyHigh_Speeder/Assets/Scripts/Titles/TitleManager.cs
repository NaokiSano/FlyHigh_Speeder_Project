using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  タイトルメニュー処理
/// </summary>
public class TitleManager : MonoBehaviour {

    [SerializeField, Header("自機")]
    Transform m_PlayerPos;

    // タイトルのプッシュスタート
    [SerializeField, Header("Push Startのスプライト")]
    Image m_TitileSprites;

    // メニューのまとまりオブジェクト
    [SerializeField, Header("メニュー項目の親オブジェクト")]
    GameObject m_MenuObjects;

    /* それぞれの参照 */
    TitleState m_TitleState;
    MenuState m_MenuState;

    // 今の画面状態
    int m_NowState;

    // コントローラーが接続されているか
    bool m_IsConnectedController;


    void Awake()
    {
        /* スクリプト参照を得る */
        m_PlayerPos = m_PlayerPos.transform;
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
        //m_PlayerPos.position += new Vector3(0, 0, 0.5f);
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
    void IsConnectController()
    {
        // 接続されているコントローラを取得して、
        string[] controller = Input.GetJoystickNames();

        // 一台もコントローラが接続されていなければfalse
        if (controller == null)
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
