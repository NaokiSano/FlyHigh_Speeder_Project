using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  ボタン操作システム
/// </summary>
public class ButtonSystem : MonoBehaviour {

    [SerializeField, Header("ボタンのゲームオブジェクト")]
    GameObject[] m_ButtonObjects;
    Image[] m_Sprites;
    Button[] m_Buttons;

    // 選択状態にあるボタンの数字
    int m_SelectNum;

    // コントローラーの状態
    bool m_IsController, m_IsAxis;

    void Awake()
    {
        // ボタンの数に合わせて作る
        m_Sprites = new Image[m_ButtonObjects.Length];
        m_Buttons = new Button[m_ButtonObjects.Length];

        // ボタンとその画像を参照取得
        for (int i = 0; i < m_ButtonObjects.Length; i++)
        {
            m_Buttons[i] = m_ButtonObjects[i].GetComponent<Button>();
            m_Sprites[i] = m_ButtonObjects[i].GetComponent<Image>();
        }
    }

	void Start ()
    {
        m_SelectNum = 0;
	}
	
    /// <summary>
    ///  ボタンアップデート処理
    ///  これを使用先で呼び出す
    /// </summary>
	public void ButtonUpdate ()
    {
        SelectButtons();
        ButtonHighLight();
        Debug.Log(m_SelectNum);
	}

    /// <summary>
    ///  ボタン番号取得
    /// </summary>
    /// <returns>ボタン番号</returns>
    public int GetNowSelectButton()
    {
        return m_SelectNum;
    }

    /// <summary>
    ///  コントローラーの接続状態をセット
    /// </summary>
    public void SetIsConnectedController(bool _flag)
    {
        m_IsController = _flag;
    }

    /// <summary>
    ///  ボタン選択
    /// </summary>
    void SelectButtons()
    {
        /* 対応キーでボタン選択移動 */
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_SelectNum++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_SelectNum--;
        }

        /* スティックの傾いた方に選択移動 */
        if (!m_IsController)
        {
            // スティックの傾き
            float joy = Input.GetAxis("Vertical2");

            if (joy < 0 && m_IsAxis)
            {
                m_SelectNum++;
                m_IsAxis = false;
            }
            else if (joy > 0 && m_IsAxis)
            {
                m_SelectNum--;
                m_IsAxis = false;
            }

            // スティックを戻したら再度入力受付
            // 連続でボタン選択が移動してしまうのを防ぐため
            if (joy == 0) m_IsAxis = true;
        }

        /* ボタンの数に選択番号を制限する */
        if (m_SelectNum >= m_ButtonObjects.Length)
        {
            m_SelectNum = m_ButtonObjects.Length - 1;
        }
        else if (m_SelectNum <= 0) m_SelectNum = 0;
    }

    /// <summary>
    ///  ボタンのハイライト
    /// </summary>
    void ButtonHighLight()
    {
        m_Buttons[m_SelectNum].Select();
    }

    /// <summary>
    ///  ボタン番号を0に初期化
    /// </summary>
    public void SetButtonNumZero()
    {
        m_SelectNum = 0;
    }
}
