using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  メニューからゲームプレイに遷移するときのズームイン演出
/// </summary>
public class CameraZoomIn : MonoBehaviour {

    // カメラ
    [SerializeField]
    private Transform m_CameraPos;

    // ズームインのスピード
    [SerializeField]
    private float m_ZoomInSpeed;

    // ズームインをスタートするか
    private bool m_IsStart;

    void Awake()
    {
        // 参照
        m_CameraPos = m_CameraPos.GetComponent<Transform>();
    }

	void Start ()
    {
        m_IsStart = false;
	}
	
	void Update ()
    {
        if (!m_IsStart) return;

        ZoomIn();
	}

    /// <summary>
    ///  ズームイン演出
    /// </summary>
    void ZoomIn()
    {
        m_CameraPos.position += new Vector3(0, 0, m_ZoomInSpeed);
    }

    /// <summary>
    ///  ズームインをスタート
    /// </summary>
    public void ZoomInStart()
    {
        m_IsStart = true;
    }
}
