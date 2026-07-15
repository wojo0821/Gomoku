using System.Collections.Generic;
using UnityEngine;
public class StoneManager : MonoBehaviour
{
    [SerializeField] private CheckWin checkWin = null;
    [SerializeField] private CheckFoul checkFoul = null;
    [SerializeField] private GoStone[] allStones = null;
    int num = 0;
    protected List<Vector2Int> blackStones = new List<Vector2Int>();
    protected List<Vector2Int> whiteStones = new List<Vector2Int>();

    private void Awake()
    {
        for (int i = 1; i < 16; i++)
        {
            for (int j = 1; j < 16; j++)
            {
                allStones[num].stoneIndex = new Vector2Int(j, i);
                num++;
            }
        }
    }
    public void AddStone(Vector2Int index, bool isWhiteTurn)
    {
        if (isWhiteTurn)
        {
            whiteStones.Add(index);
            checkWin.CheckWinMethod(index, isWhiteTurn, whiteStones);
        }
        else
        {
            blackStones.Add(index);
            checkWin.CheckWinMethod(index, isWhiteTurn, blackStones);
        }
    }
    public bool CheckFoulMethode(Vector2Int index)
    {
        return checkFoul.CheckFoulMethod(index, blackStones, whiteStones);
    }
}
