using Unity.Pipeline.Commands;
using UnityEditor;
using UnityEngine;
using System.IO;

public static class WebGLBuildCommand
{
    [CliCommand("WebGLBuildCommand", "Builds the project for WebGL automatically")]
    public static int Build()
    {
        Debug.Log("🚀 WebGLの自動ビルドを開始するであります！");

        string buildPath = "Builds/WebGL";
        
        // 出力ディレクトリの作成
        if (!Directory.Exists(buildPath))
        {
            Directory.CreateDirectory(buildPath);
        }

        // シーンリストの取得（Build Settingsに登録されているシーン）
        string[] scenes = EditorBuildSettings.scenes != null && EditorBuildSettings.scenes.Length > 0
            ? System.Array.ConvertAll(EditorBuildSettings.scenes, s => s.path)
            : new string[] { "Assets/Scenes/SampleScene.unity" }; // フォールバック

        // ビルドオプションの設定
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = scenes;
        buildPlayerOptions.locationPathName = buildPath;
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.None;

        // ビルド実行
        var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        var summary = report.summary;

        if (summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded)
        {
            Debug.Log($"🎉 ビルド大成功！ 出力サイズ: {summary.totalSize} bytes");
            return 0; // 成功終了コード
        }
        else
        {
            Debug.LogError($"💥 ビルド失敗であります… エラー数: {summary.totalErrors}");
            return 1; // エラー終了コード
        }
    }
}
