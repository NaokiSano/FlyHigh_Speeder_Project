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
    IsConnectedController m_IsConnectedController;

    // 今の画面状態
    int m_NowState;

    // コントローラーが接続されているか
    bool m_IsConnected;


    void Awake()
    {
        /* スクリプト参照を得る */
        m_PlayerPos = m_PlayerPos.transform;
        m_TitleState = this.gameObject.GetComponent<TitleState>();
        m_MenuState = this.gameObject.GetComponent<MenuState>();
        m_IsConnectedController = this.GetComponent<IsConnectedController>();
  
    }

    void Start ()
    {
        // コントローラー接続？
        m_IsConnected = m_IsConnectedController.GetIsConnectedController();
        // 最初はタイトルから
        StateChange(SceneNum.TITLE_SCENE);
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
    ///  今の画面状態を取得
    /// </summary>
    /// <returns></returns>
    public int GetNowSceneState()
    {
        return m_NowState;
    }

    /// <summary>
    ///  コントローラー接続がされているかを渡す
    /// </summary>
    /// <returns></returns>
    public bool GetIsConnectedController()
    {
        return m_IsConnected;
    }
}
