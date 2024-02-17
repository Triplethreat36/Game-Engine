using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHighLight : MonoBehaviour
{
    public Image[] imagesToHighlight;
    private int currentIndex = 0;

    public void HighlightImages()
    {
        // Reset color of all images
        ResetImageColors();

        // Highlight the current image
        imagesToHighlight[currentIndex].color = Color.yellow;
    }

    public void MoveHighlightLeft()
    {
        // Move to the previous image
        currentIndex = (currentIndex - 1 + imagesToHighlight.Length) % imagesToHighlight.Length;
        HighlightImages();
    }

    public void MoveHighlightRight()
    {
        // Move to the next image
        currentIndex = (currentIndex + 1) % imagesToHighlight.Length;
        HighlightImages();
    }

    // Reset the color of all images
    private void ResetImageColors()
    {
        foreach (Image image in imagesToHighlight)
        {
            image.color = Color.white; // Set back to default color
        }
    }
}
