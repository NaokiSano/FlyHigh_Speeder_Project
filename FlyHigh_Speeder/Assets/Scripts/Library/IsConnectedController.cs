using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  シーン開始時、コントローラーの接続状態を取得
/// </summary>
public class IsConnectedController : MonoBehaviour {

    // コントローラーフラグ
    bool m_IsConnectedController;

    void Start()
    {
        IsConnectController();
    }

    /// <summary>
    ///  コントローラーが接続されているか？
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
    ///  コントローラーの接続状態を取得
    /// </summary>
    public bool GetIsConnectedController()
    {
        return m_IsConnectedController;
    }
}
