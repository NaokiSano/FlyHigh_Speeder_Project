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
    TitleManager m_TitleManager;
    Fade m_Fade;

    void Awake()
    {
        // 参照取得
        m_TitleManager = this.gameObject.GetComponent<TitleManager>();
        m_Fade = this.gameObject.GetComponent<Fade>();
    }

    void Start()
    {
        m_Fade.ChangeSpeed(m_FadeSpeed);
        m_Fade.FadeOutStart();
    }
	
	void Update () {
        TitieControll();
        m_GameStartSprite.color = new Color(255, 255, 255, m_Fade.GetAlpha());
	}

    /// <summary>
    ///  タイトル状態のときの遷移処理
    /// </summary>
    private void TitieControll()
    {
        // 今の状態がタイトル状態以外なら処理しない
        if (m_TitleManager.GetNowSceneState() != (int)SceneNum.TITLE_SCENE) return;

        // スペースキーでメニュー状態に移行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_TitleManager.StateChange(SceneNum.MENU_SCENE);
        }

        // コントローラー接続？
        if (m_TitleManager.GetIsConnectedController()) return;

        // 接続されてればコントローラーのボタンも検知
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Submit"))
        {
            m_TitleManager.StateChange(SceneNum.MENU_SCENE);
        }
    }

    private void FadeSprite()
    {

    }

}
