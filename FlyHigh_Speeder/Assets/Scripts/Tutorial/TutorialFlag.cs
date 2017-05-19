using UnityEngine;

/// <summary>
///  チュートリアルを受けるかどうか
/// </summary>
public class TutorialFlag : MonoBehaviour {

    [SerializeField, Header("ゲームプレイマネージャー")]
    GamePlayManager m_GamePlayManager;
    ButtonSystem m_ButtonSystem;

    void Awake()
    {
        m_ButtonSystem = m_GamePlayManager.gameObject.GetComponent<ButtonSystem>();
    }

    void Start()
    {

    }

    void Update()
    {
        m_ButtonSystem.ButtonUpdate();
    }

    // ボタン内処理
    public void Push()
    {
        if(m_ButtonSystem.GetNowSelectButton() == 1)
        {
            AnswerYes();
        }
        else
        {
            AnswerNo();
        }
    }

    /// <summary>
    ///  受ける
    /// </summary>
    void AnswerYes()
    {
        m_GamePlayManager.SetIsTutorial(true);
        this.gameObject.SetActive(false);
    }

    /// <summary>
    ///  受けない
    /// </summary>
    void AnswerNo()
    {
        m_GamePlayManager.SetIsTutorial(false);
        this.gameObject.SetActive(false);
    }
}
