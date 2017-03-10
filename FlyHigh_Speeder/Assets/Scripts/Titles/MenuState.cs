using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  メニュー状態の処理
/// </summary>
public class MenuState : MonoBehaviour {

    /* メニュー移行後の画像とボタン群 */
    [SerializeField]
    private GameObject[] m_MenuItems;
    private Image[] m_MenuSprites;
    private Button[] m_MenuButtons;

    private CameraZoomIn m_CameraZoomIn;
    private TitleManager m_TitleManager;
    private int m_SelectNum;
    private bool m_IsController, m_IsAxis;

    void Awake()
    {
        // 参照
        m_TitleManager = this.GetComponent<TitleManager>();
        m_CameraZoomIn = this.GetComponent<CameraZoomIn>();

        // メニューの項目数に合わせて作る
        m_MenuSprites = new Image[m_MenuItems.Length];
        m_MenuButtons = new Button[m_MenuItems.Length];

        // ボタンとその画像を参照取得
        for(int i=0; i<m_MenuItems.Length; i++)
        { 
            m_MenuButtons[i] = m_MenuItems[i].GetComponent<Button>();
            m_MenuSprites[i] = m_MenuItems[i].GetComponent<Image>();
        }
    }

    void Start ()
    {
        // コントローラー接続状態を取得
        m_IsController = m_TitleManager.GetIsConnectedController();

        m_SelectNum = 0;
        m_IsAxis = true;
	}

	void Update ()
    {
        SelectItems();
        ButtonHighLight();
    }

    // 項目のセレクト
    void SelectItems()
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
        if(m_IsController)
        {
            float joy = Input.GetAxis("Vertical2");

            if (joy < 0 && m_IsAxis)
            {
                m_SelectNum++;
                m_IsAxis = false;
            }
            else if(joy > 0 && m_IsAxis)
            {
                m_SelectNum--;
                m_IsAxis = false;
            }

            // スティックを戻したら再度入力受付
            // 連続でボタン選択が移動してしまうのを防ぐため
            if (joy == 0) m_IsAxis = true;
        }

        if (m_SelectNum >= 2) m_SelectNum = 2;
        else if (m_SelectNum <= 0) m_SelectNum = 0;
    }

    /// <summary>
    ///  今選択状態にあるボタンをハイライト
    /// </summary>
    void ButtonHighLight()
    {
        m_MenuButtons[m_SelectNum].Select();
    }

    public void PushButton()
    {
        m_CameraZoomIn.ZoomInStart();
    }

}
