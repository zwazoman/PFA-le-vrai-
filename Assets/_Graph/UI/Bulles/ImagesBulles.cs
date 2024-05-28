using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bubbleImageList", menuName = "Bubble/ImageList", order = 1)]

public class ImagesBulles : ScriptableObject
{
    public List<Sprite> textures = new List<Sprite>();
}
