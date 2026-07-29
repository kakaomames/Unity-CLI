using UnityEngine;

public class GameMain : MonoBehaviour
{
    private GameObject playerCube;

    void Start()
    {
        Debug.Log("🎮 ブラウザ版ゲームが正常に起動したであります！");

        // 画面の真ん中にプレイヤー代わりのキューブを召喚！
        playerCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        playerCube.transform.position = Vector3.zero;
        
        // 色を鮮やかな青にする
        var renderer = playerCube.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = new Color(0.2f, 0.6f, 1.0f);
        }

        Debug.Log("✨ キューブを座標 [0, 0, 0] に設置完了！");
    }

    void Update()
    {
        // くるくる回すだけのシンプルなアニメーション
        if (playerCube != null)
        {
            playerCube.transform.Rotate(Vector3.up, 50f * Time.deltaTime);
        }
    }

    // 画面上に簡単なログやステータスを表示するUI
    void OnGUI()
    {
        GUI.color = Color.white;
        GUILayout.BeginArea(new Rect(20, 20, 400, 200));
        GUILayout.Label("<size=20><b>🚀 Gemini Programming 隊 - WebGL Demo</b></size>");
        GUILayout.Label("GitHub Actions & Unity CLI Automated Pipeline");
        GUILayout.Label("Status: Running smoothly on GitHub Pages!");
        GUILayout.EndArea();
    }
}
