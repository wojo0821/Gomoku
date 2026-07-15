using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    public void CheckWinMethod(Vector2Int index, bool isWhiteTurn, List<Vector2Int> stoneList)
    {
        int[] dx = { 1, 0, 1, 1 };
        int[] dy = { 0, 1, 1, -1 };
        if (isWhiteTurn)
        {
            for (int i = 0; i < 4; i++)
            {
                int count = GetLineCount(index, dx[i], dy[i], stoneList);
                if (count >= 5) Debug.Log("White Wins");
            }
        }
        else if (!isWhiteTurn)
        {
            for (int i = 0; i < 4; i++)
            {
                int count = GetLineCount(index, dx[i], dy[i], stoneList);
                if (count == 5) Debug.Log("Black Wins");
            }
        }
    }
    int GetLineCount(Vector2Int index, int dx, int dy, List<Vector2Int> stoneList)
    {
        int count = 0;
        int maxCount = 0;
        for (int i = -5; i <= 5; i++)
        {
            if (stoneList.Contains(new Vector2Int(index.x + i * dx, index.y + i * dy)))
            {
                count++;
                if (maxCount < count) maxCount = count;
            }
            else // 빈칸이 있거나 하얀돌에 막혀있을때
            {
                count = 0;
            }
        }
        return maxCount;
    }
}
