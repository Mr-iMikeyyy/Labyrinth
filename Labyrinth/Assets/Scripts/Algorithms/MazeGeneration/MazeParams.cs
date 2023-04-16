using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MazeParams {
    private static int size = 13;
    
    public static void setSize() {
        size = (PlayerStats.getCurrentLevel() *2) + size;
    }

    public static Vector2Int getSize() {
        Vector2Int myVector = new Vector2Int(size,size);
        return myVector;
    }
}
