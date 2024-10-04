using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ButtonNavigation : MonoBehaviour
{
    public Button button1;
    public Button button2;

    private Button currentButton;
    private FadeController m_fade;

    void Start()
    {
        m_fade = GetComponent<FadeController>();

        // �ŏ��̃{�^���Ƀt�H�[�J�X�𓖂Ă�
        currentButton = button1;
        button1.Select();

        // �{�^���ɃN���b�N�C�x���g��ǉ�
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
    }

    void Update()
    {
        // ���E�̖��L�[�̓��͂��`�F�b�N
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentButton == button1)
            {
                currentButton = button2;
                button2.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentButton == button2)
            {
                currentButton = button1;
                button1.Select();
            }
        }
    }

    void OnButton1Click()
    {
        // �t�F�[�h�A�E�g���Ă���V�[���J��
        StartCoroutine(FadeAndLoadScene());
    }

    IEnumerator FadeAndLoadScene()
    {
        // �t�F�[�h�A�E�g��҂�
        yield return StartCoroutine(m_fade.FadeOut());

        // "Game"�V�[���ɑJ��
        SceneManager.LoadScene("Game");
    }

    // button2���N���b�N�����Ƃ��̏��� (�Q�[���I��)
    void OnButton2Click()
    {
        // �Q�[�����I��
        Application.Quit();

        // Unity�G�f�B�^��Ŏ��s���Ă���ꍇ�͒�~������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
