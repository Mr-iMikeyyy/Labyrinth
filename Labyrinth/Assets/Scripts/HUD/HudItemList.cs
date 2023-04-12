using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudItemList : MonoBehaviour
{
    //public GameObject currentItem, nextItem, previousItem;
    // Start is called before the first frame update
    public Sprite[] ImgArr;
    public GameObject currIMG, nextIMG, prevIMG;

   // private TextMeshProUGUI currentText, nextText, previousText;
    private Image currSprite, nextSprite, prevSprite;
    void Start()
    {
        PlayerInventory.initPowerups();
        //currentText = currentItem.GetComponent<TextMeshProUGUI>();
        //nextText = nextItem.GetComponent<TextMeshProUGUI>();
        //previousText = previousItem.GetComponent<TextMeshProUGUI>();
        currSprite = currIMG.GetComponent<Image>();
        nextSprite = nextIMG.GetComponent<Image>();
        prevSprite = prevIMG.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //currentText.text = PlayerInventory.checkCurrentPower();
        //nextText.text = PlayerInventory.checkNext();
        //previousText.text = PlayerInventory.checkPrevious();
        currSprite.sprite = ImgArr[PlayerInventory.getCurrentID()];
        nextSprite.sprite = ImgArr[PlayerInventory.getNextID()];
        prevSprite.sprite = ImgArr[PlayerInventory.getPrevID()];
    }
}
