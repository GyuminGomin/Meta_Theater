using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translate2 : MonoBehaviour
{
    public AudioClip audio5_6;
    public AudioClip audio24_28;
    public AudioClip audio33_36;
    public AudioClip audio40_43;
    public AudioClip audio43_455;
    public AudioClip audio455_495;
    public AudioClip audio60_62;
    public AudioClip audio66_69;
    public AudioClip audio72_725;
    public AudioClip audio725_73;
    public AudioClip audio82_85;
    public AudioClip audio86_89;
    public AudioClip audio89_92;
    public AudioClip audio99_111;
    AudioSource audioSource;
    [SerializeField]
    TMP_Text transl;
    [SerializeField]
    GameObject canvas;

    void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        canvas.SetActive(false);
    }
    void Start()
    {
        StartCoroutine(playaud());
    }

    IEnumerator playaud()
    {
        yield return new WaitForSeconds(5f);
        canvas.SetActive(true);
        PlaySound("5~6");
        transl.text = "헉!";
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(18f);
        PlaySound("24~28");
        yield return new WaitForSeconds(1.5f);
        canvas.SetActive(true);
        transl.text = "쫓아가봐야 소용없어요. \n 회전 속도 분석해";
        yield return new WaitForSeconds(3f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(5f);
        PlaySound("33~36");
        yield return new WaitForSeconds(1f);
        canvas.SetActive(true);
        transl.text = "쿠퍼, 어쩌려고요? \n 도킹할 거예요.";
        yield return new WaitForSeconds(2f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(5f);
        canvas.SetActive(true);
        PlaySound("40~43");
        transl.text = "인듀어런스 회전수 \n 분당 67,68";
        yield return new WaitForSeconds(3f);
        PlaySound("43~45.5");
        transl.text = "역추진으로! \n 우리도 똑같이 맞춰";
        yield return new WaitForSeconds(2.5f);
        PlaySound("45.5~49.5");
        transl.text = "불가능 해요. \n 아니";
        yield return new WaitForSeconds(2f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(1f);
        canvas.SetActive(true);
        transl.text = "반드시 해야해";
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(11f);
        canvas.SetActive(true);
        PlaySound("60~62");
        transl.text = "인듀어런스호가 성층권에 진입해요";
        yield return new WaitForSeconds(2f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(4f);
        PlaySound("66~69");
        yield return new WaitForSeconds(1f);
        canvas.SetActive(true);
        transl.text = "방열막도 없는데";
        yield return new WaitForSeconds(2f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(3f);
        canvas.SetActive(true);
        PlaySound("72~72.5");
        transl.text = "케이스,준비됐어?";
        yield return new WaitForSeconds(0.5f);
        PlaySound("72.5~73");
        transl.text = "네";
        yield return new WaitForSeconds(0.5f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(9f);
        canvas.SetActive(true);
        PlaySound("82~85");
        transl.text = "쿠퍼, 조심할 때가 아녜요.";
        yield return new WaitForSeconds(3f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(1f);
        canvas.SetActive(true);
        PlaySound("86~89");
        transl.text = "케이스, 내가 기절하면 \n 조종 맡아";
        yield return new WaitForSeconds(3f);
        PlaySound("89~92");
        transl.text = "타스, 도킹 준비해";
        yield return new WaitForSeconds(3f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(7f);
        canvas.SetActive(true);
        PlaySound("99~111");
        transl.text = "인듀어런스호가 뜨거워져요!";
        yield return new WaitForSeconds(1f);
        transl.text = "6m";
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(1f);
        canvas.SetActive(true);
        transl.text = "우현으로 3도";
        yield return new WaitForSeconds(2f);
        transl.text = "3m";
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(2f);
        canvas.SetActive(true);
        transl.text = "쿠퍼, 정렬 됐어요!";
        yield return new WaitForSeconds(2f);
        transl.text = "회전해!";
        yield return new WaitForSeconds(2f);
        transl.text = " The End, Doking Now!";
        yield return new WaitForSeconds(10f);
        canvas.SetActive(false);
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "5~6":
            audioSource.clip = audio5_6;
            break;
            case "24~28":
            audioSource.clip = audio24_28;
            break;
            case "33~36":
            audioSource.clip = audio33_36;
            break;
            case "40~43":
            audioSource.clip = audio40_43;
            break;
            case "43~45.5":
            audioSource.clip = audio43_455;
            break;
            case "45.5~49.5":
            audioSource.clip = audio455_495;
            break;
            case "60~62":
            audioSource.clip = audio60_62;
            break;
            case "66~69":
            audioSource.clip = audio66_69;
            break;
            case "72~72.5":
            audioSource.clip = audio72_725;
            break;
            case "72.5~73":
            audioSource.clip = audio725_73;
            break;
            case "82~85":
            audioSource.clip = audio82_85;
            break;
            case "86~89":
            audioSource.clip = audio86_89;
            break;
            case "89~92":
            audioSource.clip = audio89_92;
            break;
            case "99~111":
            audioSource.clip = audio99_111;
            break;
        }
        audioSource.Play();
    }
}
