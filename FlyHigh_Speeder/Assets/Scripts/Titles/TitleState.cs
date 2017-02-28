using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  タイトル状態の処理
/// </summary>
public class TitleState : MonoBehaviour {

    [SerializeField]
    private float m_FadeSpeed;
    [SerializeField]
    private Image m_GameStartSprite;

    // 参照
    private TitleManager m_TitleManager;
    private Fade m_Fade;
    bool m_IsController;

    void Awake()
    {
        // 参照取得
        m_TitleManager = this.gameObject.GetComponent<TitleManager>();
        m_Fade = this.gameObject.GetComponent<Fade>();
    }

    void Start()
    {
        // コントローラー接続状態を取得
       　m_IsController = m_TitleManager.GetIsConnectedController();
        m_Fade.ChangeSpeed(m_FadeSpeed);
        m_Fade.FadeOutStart();
    }
	
	void Update ()
    {
        TitieControll();
        m_GameStartSprite.color = new Color(255, 255, 255, m_Fade.GetAlpha());
	}

    /// <summary>
    ///  タイトル状態のときの遷移処理
    /// </summary>
    private void TitieControll()
    {
        // スペースキーでメニュー状態に移行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Fade.StopAndReset();
            m_TitleManager.StateChange(SceneNum.MENU_SCENE);
        }

        // コントローラー接続？
        if (!m_TitleManager.GetIsConnectedController()) return;

        // 接続されてればコントローラーのボタンも検知
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Submit"))
        {
            m_Fade.StopAndReset();
            m_TitleManager.StateChange(SceneNum.MENU_SCENE);
        }
    }
}
