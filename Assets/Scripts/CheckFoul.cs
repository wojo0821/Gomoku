using System.Collections.Generic;
using UnityEngine;

public class CheckFoul : MonoBehaviour
{
    public bool CheckFoulMethod(Vector2Int index, List<Vector2Int> blackStones, List<Vector2Int> whiteStones)
    {
        int[] dx = { 1, 0, 1, 1 };
        int[] dy = { 0, 1, 1, -1 };

        int threeCount = 0;
        int fourCount = 0;

        for (int i = 0; i < 4; i++)
        {
            int count = GetLineCount(index, dx[i], dy[i], blackStones, whiteStones);
            if (count == 2) threeCount++;
            else if (count == 3) fourCount++;
        }

        // 3-3 체크
        if (threeCount >= 2)
        {
            Debug.Log("Black is 33");
            return true;
        }

        // 4-4 체크
        if (fourCount >= 2)
        {
            Debug.Log("Black is 44");
            return true;
        }

        return false;
    }

    // 특정 방향(dx, dy)의 돌 개수를 체크하는 함수
    private int GetLineCount(Vector2Int index, int dx, int dy, List<Vector2Int> blackStones, List<Vector2Int> whiteStones)
    {
        int count = 0;
        for (int i = -3; i <= 3; i++)
        {
            if (blackStones.Contains(new Vector2Int(index.x + i * dx, index.y + i * dy))) //검은색돌 체크
            {
                count++;
            }
        }
        Debug.Log("방향: " + dx + "," + dy + " 돌 개수: " + count);
        for (int i = -3; i <= 3; i++)
        {
            if (blackStones.Contains(new Vector2Int(index.x + i * dx, index.y + i * dy))) //검은색돌 체크
            {
                if (whiteStones.Contains(new Vector2Int(index.x + (i - 1) * dx, index.y + (i - 1) * dy)) && count < 3 ||
                    whiteStones.Contains(new Vector2Int(index.x + (i + 1) * dx, index.y + (i + 1) * dy)) && count < 3)
                {
                    Debug.Log("양옆에 흰돌 방향: " + dx + "," + dy);
                    return -1; // 검은색돌 양옆에 흰색돌 체크 (막힘)
                }
            }
        }
        if (blackStones.Contains(new Vector2Int(index.x - 4 * dx, index.y - 4 * dy)) && count == 3)
        {
            Debug.Log("5돌 체크");
            return -1;
        }
        if (blackStones.Contains(new Vector2Int(index.x + 4 * dx, index.y + 4 * dy)) && count == 3)
        {
            Debug.Log("5돌 체크");
            return -1;
        }
        return count;
    }
}
