using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField, Label("�t�F�[�h�p��Image")]
    public Image fadeImage;

    [SerializeField, Label("�t�F�[�h�ɂ����鎞��")]
    public float fadeDuration = 1.0f;

    private void Start()
    {
        // �Q�[���J�n���Ƀt�F�[�h�C�������s
        StartCoroutine(FadeIn());
    }

    // �t�F�[�h�C������
    public IEnumerator FadeIn()
    {
        float timer = 0;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, timer / fadeDuration); // Alpha�l��1����0�֏��X�ɕύX
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0;
        fadeImage.color = color; // ���S�ɓ�����
    }

    // �t�F�[�h�A�E�g����
    public IEnumerator FadeOut()
    {
        float timer = 0;
        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, timer / fadeDuration); // Alpha�l��0����1�֏��X�ɕύX
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1;
        fadeImage.color = color; // ���S�ɕs������
    }
}
