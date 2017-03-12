using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScroll : MonoBehaviour {

    [SerializeField, Header("スクロールスピード")]
    float m_Speed;

    // ここまでスクロールしたら初期化
    [SerializeField, Header("ここまでスクロールしたら初期化")]
    int m_LimitPosZ;

    // ワールド初期位置
    [SerializeField, Header("ワールドの初期位置")]
    Transform m_InitialPos;

    [SerializeField]
    Terrain[] m_World;

    // ワールドサイズ
    float m_Size = 1000;


    void Start ()
    {
        
	}

    void Update()
    {
        Scroll();

        IsEnable();

        Initialize();
    }

    /// <summary>
    ///  有効ならスクロール
    /// </summary>
    void Scroll()
    {
        if (m_World[0].gameObject.activeSelf)
        {
            m_World[0].transform.Translate(0, 0, m_Speed);
        }
        if (m_World[1].gameObject.activeSelf)
        {
            m_World[1].transform.Translate(0, 0, m_Speed);
        }
    }

    /// <summary>
    ///  どちらかが一定距離移動すると次を有効化
    /// </summary>
    void IsEnable()
    {
        if (m_World[0].transform.position.z + m_Size < 0)
        {
            m_World[1].gameObject.SetActive(true);
        }
        else if (m_World[1].transform.position.z + m_Size < 0)
        {
            m_World[0].gameObject.SetActive(true);
        }
    }

    /// <summary>
    ///  一定距離で無効化し初期位置に戻る
    /// </summary>
    void Initialize()
    {
        // ワールド全部
        for (int i = 0; i < m_World.Length; i++)
        {
            // リミットまでリターン
            if (m_World[i].transform.position.z >= m_LimitPosZ) return;

            // ポジションを初期化して無効化
            m_World[i].transform.position = m_InitialPos.position;
            m_World[i].gameObject.SetActive(false);
        }
    }
}
