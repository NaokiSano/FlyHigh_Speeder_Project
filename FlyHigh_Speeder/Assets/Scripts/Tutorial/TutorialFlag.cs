using UnityEngine;

/// <summary>
///  チュートリアルを受けるかどうか
/// </summary>
public class TutorialFlag : MonoBehaviour {

    [SerializeField, Header("ゲームプレイマネージャー")]
    GamePlayManager m_GamePlayManager;

    /// <summary>
    ///  受ける
    /// </summary>
    public void AnswerYes()
    {
        m_GamePlayManager.SetIsTutorial(true);
        this.gameObject.SetActive(false);
    }

    /// <summary>
    ///  受けない
    /// </summary>
    public void AnswerNo()
    {

    }
}
