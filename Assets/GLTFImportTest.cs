using System;
using System.IO;
using GLTFast;
using UnityEngine;

public class GLTFImportTest : MonoBehaviour
{
    public void ImportGLTF()
    {
        LoadGltfBinaryFromMemory();
    }

    async void LoadGltfBinaryFromMemory() {
        var filePath = Path.Combine(Application.dataPath, "Model/scene.gltf");

        Debug.Log(filePath);

        byte[] data = File.ReadAllBytes(filePath);

        Debug.Log("Data: "+data?.Length);

        var gltf = new GltfImport();

        bool success = false;

        try
        {
            success = await gltf.LoadGltfBinary(data, new Uri(filePath));
        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
        }


        if (success) {
            success = gltf.InstantiateMainScene(transform);
        }
        else
        {
            Debug.LogError("gltf import failed");
        }
    }
}
