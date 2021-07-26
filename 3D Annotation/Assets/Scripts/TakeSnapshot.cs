using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeSnapshot : MonoBehaviour
{
    

    // This method captures a single snapshot in a .png format with the given resolution
    public void CaptureSnapshot(Camera snapshotCamera, int snapshotIndex, int resWidth, int resHeight)
    {
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        snapshotCamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        snapshotCamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        snapshotCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = "C:/Users/humanscanner/Desktop/Pictures/" + snapshotIndex + ".png";
        System.IO.File.WriteAllBytes(filename, bytes);
    }
}