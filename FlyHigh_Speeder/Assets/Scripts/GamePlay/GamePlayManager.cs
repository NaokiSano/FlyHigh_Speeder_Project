using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ゲームプレイ全体を管理
/// </summary>
public class GamePlayManager : MonoBehaviour
{
    // フェード中か
    bool m_FadeStatus;

    // ゲーム中断か、操作可能か
    bool m_IsEnableGame, m_IsEnableControll;

    // コントローラーの接続状態
    bool m_IsConnect;

    // チュートリアルをするか
    bool m_IsTutorial;

    /* 参照 */
    IsConnectedController m_IsConnectedController;
    GameSceneFade m_GameSceneFade;

    void Awake()
    {
        m_IsConnectedController = this.GetComponent<IsConnectedController>();
        m_GameSceneFade = this.GetComponent<GameSceneFade>();
    }

    void Start()
    {
        m_IsConnect = false;
        SetIsConnectedController();

        // シーンはフェードインから始まるのでtrue
        m_FadeStatus = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    ///  コントローラーの接続状態をセット
    /// </summary>
    void SetIsConnectedController()
    {
        m_IsConnect = false;

        // コントローラー接続？
        if (!m_IsConnectedController.GetIsConnectedController()) return;

        // 接続されているならtrue
        m_IsConnect = true;
    }

    /// <summary>
    ///  フェード処理中？
    /// </summary>
    /// <param name="_flag"></param>
    public void SetFadeStatus(bool _flag)
    {
        m_IsEnableControll = m_FadeStatus = _flag;
    }

    /// <summary>
    ///  ゲームの状態を取得
    /// </summary>
    /// <returns>中断ならfalse</returns>
    public bool GameStatus()
    {
        return m_IsEnableGame;
    }

    /// <summary>
    ///  操作可能かを取得
    /// </summary>
    /// <returns>可能ならtrue</returns>
    public bool IsEnableControll()
    {
        return m_IsEnableControll;
    }

}
