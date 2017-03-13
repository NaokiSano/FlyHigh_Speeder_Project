using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ゲームプレイ全体を管理
/// </summary>
public class GamePlayManager : MonoBehaviour
{
    // コントローラーの接続状態
    bool m_IsConnect;

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
}
