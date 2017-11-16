using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    public Texture2D Texture;

    private Rect position;

    // Use this for initialization
    void Start () {
        float textureWidth = Texture.width;
        float textureHeight = Texture.height;

        position = new Rect((Screen.width - textureWidth) * .5f, (Screen.height - textureHeight) *.5f, textureWidth, textureHeight);
    }

    void OnGUI()
    {
        GUI.DrawTexture(position, Texture);
    }
}
