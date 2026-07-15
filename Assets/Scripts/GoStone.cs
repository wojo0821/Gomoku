using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//주석 한국어로 달 것
public class GoStone : MonoBehaviour, IPointerClickHandler
{
    public bool isPlaced = false;
    public Vector2Int stoneIndex;
    [SerializeField] private Sprite whiteStone = null;
    [SerializeField] private Sprite blackStone = null;
    private Image stoneImage;
    private void Awake()
    {
        stoneImage = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPlaced)
            return;

        if (GameManager.instance.isWhiteTurn)
        {
            stoneImage.sprite = whiteStone;
            stoneImage.color = Color.white;
        }
        else
        {
            if (GameManager.instance.CheckFoul(stoneIndex))
                return;
            stoneImage.sprite = blackStone;
            stoneImage.color = Color.white;
        }
        isPlaced = true;
        GameManager.instance.AddStone(stoneIndex);
    }
}
