using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class WebGLFileUpdater : Editor
{
    [MenuItem("Build/Update Index.html with correct file names")]
    static void UpdateIndexHtml()
    {
        string buildPath = "Build"; // Đường dẫn tới thư mục build
        string indexPath = Path.Combine(buildPath, "index.html");

        if (File.Exists(indexPath))
        {
            string htmlContent = File.ReadAllText(indexPath);

            // Tìm các tệp cần thay đổi tên
            string dataFileName = Directory.GetFiles(buildPath, "*.data.unityweb")[0];
            string frameworkFileName = Directory.GetFiles(buildPath, "*.framework.js.unityweb")[0];
            string wasmFileName = Directory.GetFiles(buildPath, "*.wasm.unityweb")[0];

            // Cập nhật đường dẫn trong index.html
            htmlContent = htmlContent.Replace("FruitSlashGame.data.unityweb", Path.GetFileName(dataFileName))
                                     .Replace("FruitSlashGame.framework.js.unityweb", Path.GetFileName(frameworkFileName))
                                     .Replace("FruitSlashGame.wasm.unityweb", Path.GetFileName(wasmFileName));

            // Ghi lại file đã chỉnh sửa
            File.WriteAllText(indexPath, htmlContent);
            Debug.Log("index.html đã được cập nhật!");
        }
        else
        {
            Debug.LogError("index.html không tồn tại trong thư mục build!");
        }
    }
}
