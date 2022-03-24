using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translate3 : MonoBehaviour
{
    public AudioClip audio9_12;
    public AudioClip audio13_15;
    public AudioClip audio17_18;
    public AudioClip audio50_59;
    public AudioClip audio70_71;
    public AudioClip audio73_75;
    public AudioClip audio75_78;
    public AudioClip audio79_81;
    public AudioClip audio109_110;
    public AudioClip audio113_115;
    public AudioClip audio116_117;
    public AudioClip audio118_120;
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
        yield return new WaitForSeconds(9f);
        canvas.SetActive(true);
        PlaySound("9~12");
        transl.text = "다들 우리 태양계에 작별 인사할 준비 됐어?";
        yield return new WaitForSeconds(3f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(1f);
        PlaySound("13~15");
        canvas.SetActive(true);
        transl.text = "우리 은하계에";
        yield return new WaitForSeconds(2f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(2f);
        canvas.SetActive(true);
        PlaySound("17~18");
        transl.text = "자, 들어간다.";
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(32f);
        canvas.SetActive(true);
        PlaySound("50~59");
        transl.text = "소용없어, 웜홀 속의 공간은";
        yield return new WaitForSeconds(4f);
        transl.text = "우리 세상처럼 3차원이 아니야 \n 그저 기록하고 보기나 해";
        yield return new WaitForSeconds(5f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(11f);
        canvas.SetActive(true);
        PlaySound("70~71");
        transl.text = "저게 뭐죠?";
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(2f);
        canvas.SetActive(true);
        PlaySound("73~75");
        transl.text = "그들인 것 같아요";
        yield return new WaitForSeconds(2f);
        PlaySound("75~78");
        transl.text = "시공간이 뒤틀려요";
        yield return new WaitForSeconds(3f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(1f);
        canvas.SetActive(true);
        PlaySound("79~81");
        transl.text = "그러지 마요!";
        yield return new WaitForSeconds(2f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(28f);
        canvas.SetActive(true);
        PlaySound("109~110");
        transl.text = "아깐 뭐였죠?";
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(3f);
        canvas.SetActive(true);
        PlaySound("113~115");
        transl.text = "외계인과의 첫 접촉이요";
        yield return new WaitForSeconds(2f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(1f);
        canvas.SetActive(true);
        PlaySound("116~117");
        transl.text = "우리가";
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
        yield return new WaitForSeconds(1f);
        PlaySound("118~120");
        canvas.SetActive(true);
        transl.text = "우리가 해냈어!";
        yield return new WaitForSeconds(2f);
        transl.text = " The End, go White Circle!!";
        yield return new WaitForSeconds(10f);
        canvas.SetActive(false);
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "9~12":
            audioSource.clip = audio9_12;
            break;
            case "13~15":
            audioSource.clip = audio13_15;
            break;
            case "17~18":
            audioSource.clip = audio17_18;
            break;
            case "50~59":
            audioSource.clip = audio50_59;
            break;
            case "70~71":
            audioSource.clip = audio70_71;
            break;
            case "73~75":
            audioSource.clip = audio73_75;
            break;
            case "75~78":
            audioSource.clip = audio75_78;
            break;
            case "79~81":
            audioSource.clip = audio79_81;
            break;
            case "109~110":
            audioSource.clip = audio109_110;
            break;
            case "113~115":
            audioSource.clip = audio113_115;
            break;
            case "116~117":
            audioSource.clip = audio116_117;
            break;
            case "118~120":
            audioSource.clip = audio118_120;
            break;
        }
        audioSource.Play();
    }
}
