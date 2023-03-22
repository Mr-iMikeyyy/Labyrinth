using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MazeParams {
    private static int Size;
    
    public static void setSize(int x) {
        Size = x;
    }

    public static Vector2Int getSize() {
        Vector2Int myVector = new Vector2Int(Size,Size);
        return myVector;
    }
}
