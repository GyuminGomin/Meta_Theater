using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translate : MonoBehaviour
{
    public TMP_Text translate;
    [SerializeField]
    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        StartCoroutine(Trl());
    }

    IEnumerator Trl()
    {
        canvas.SetActive(true);
        translate.text = "레인저 2호, 분리준비 \n 뭐라고요?";
        yield return new WaitForSeconds(1.8f);
        translate.text = "안돼요! \n 쿠퍼 무슨 짓 이에요?";
        yield return new WaitForSeconds(1.8f);
        translate.text = "뉴턴의 제 3법칙 \n 남겨놔야 가는 법이죠";
        yield return new WaitForSeconds(4.8f);
        translate.text = "우리 둘다 갈 수 \n 있댔잖아요.";
        yield return new WaitForSeconds(2.8f);
        translate.text = "잊었어요? 어밀리아 \n 90%만 솔직하기";
        yield return new WaitForSeconds(3.6f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        canvas.SetActive(true);
        translate.text = "그러지 말아요";
        yield return new WaitForSeconds(0.8f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(3.8f);
        canvas.SetActive(true);
        translate.text = "분리";
        yield return new WaitForSeconds(0.8f);
        canvas.SetActive(false);
    }
}
