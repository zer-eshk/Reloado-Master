using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursurManagerSC : MonoBehaviour
{
    [SerializeField] Texture2D cursorTexture;
    private Vector2 cursorHotSpot;

    // Start is called before the first frame update
    void Start()
    {
        cursorHotSpot=new Vector2(cursorTexture.width/2, cursorTexture.height/2);
        Cursor.SetCursor(cursorTexture,cursorHotSpot,CursorMode.Auto);
    }

    
}
