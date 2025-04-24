using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildPostProcessor : IPostprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }

    public void OnPostprocessBuild(BuildReport report)
    {
        // Kiểm tra xem có phải build WebGL không
        if (report.summary.platform == BuildTarget.WebGL)
        {
            string buildPath = report.summary.outputPath;

            // Danh sách các file cần sao chép
            string[] filesToCopy = new string[]
            {
                "Assets/Editor/style.css",    // file css
                "Assets/Editor/scripts.js"    // file js
            };

            foreach (string file in filesToCopy)
            {
                // Kiểm tra nếu file tồn tại trong thư mục Assets/Editor
                if (File.Exists(file))
                {
                    string destinationPath = Path.Combine(buildPath, Path.GetFileName(file));

                    // Sao chép file vào thư mục build WebGL
                    File.Copy(file, destinationPath, true);
                    Debug.Log($"{Path.GetFileName(file)} đã được sao chép vào thư mục build.");
                }
                else
                {
                    Debug.LogError($"Không tìm thấy file: {file}");
                }
            }
        }
    }
}
