using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFile : MonoBehaviour
{
    public void CreateTextFile(Rect boundingBox, int index, int imageWidth, int imageHeight)
    {
        string filePath = "C:/Users/humanscanner/Desktop/Pictures/" + index + ".txt";
        System.IO.File.WriteAllText(filePath, DarknetLabelFormat(boundingBox, imageWidth, imageHeight));
    }

    // This method creates a darknet label format using the bounding box data
    string DarknetLabelFormat(Rect boundingBox, int imageWidth, int imageHeight)
    {
        float xMin = boundingBox.xMin;
        float yMin = boundingBox.yMin;
        float w = boundingBox.width;
        float h = boundingBox.height;
        float w_img = imageWidth;
        float h_img = imageHeight;

        float xCenter = (xMin + w / 2) / w_img;
        float yCenter = (yMin + h / 2) / h_img;
        w = w / w_img;
        h = h / h_img;

        string spaceing = ", ";

        return 0 + spaceing + xCenter + spaceing + yCenter + spaceing + w + spaceing + h;
    }
}
