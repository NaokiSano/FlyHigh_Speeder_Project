using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  自機の操作
/// </summary>
public class PlayerModelController : MonoBehaviour
{

    // ゲームプレイマネージャー
    [SerializeField]
    GamePlayManager m_GamePlayManager;

    bool m_ControllStatus;

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        // コントロール不能なら処理しない
        if (!m_ControllStatus) return;
    }

    bool IsEnableControll()
    {
        m_ControllStatus = m_GamePlayManager.IsEnableControll();
        return m_ControllStatus;
    }
}
