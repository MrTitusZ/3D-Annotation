using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeSnapshot : MonoBehaviour
{
    [SerializeField] public int resWidth = 1920;
    [SerializeField] public int resHeight = 1080;

    Camera snapshotCamera;
    int snapshotIndex = 0;

    void Start()
    {
        snapshotCamera = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            CaptureSnapshot();
        }
    }

    private void CaptureSnapshot()
    {
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        snapshotCamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        snapshotCamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        snapshotCamera.targetTexture = null;
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = "C:/Users/humanscanner/Desktop/Pictures/" + snapshotIndex + ".png";
        System.IO.File.WriteAllBytes(filename, bytes);
        snapshotIndex++;
    }
}