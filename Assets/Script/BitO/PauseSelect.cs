using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseSelect : MonoBehaviour
{
    public Button button1; // Button1���A�^�b�`
    public Button button2; // Button2���A�^�b�`
    private Canvas m_canvas;

    private Button currentButton;

    void Start()
    {
        // �ŏ��̃{�^���Ƀt�H�[�J�X�𓖂Ă�
        currentButton = button1;
        button1.Select();

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
        if(m_canvas != null)
        {
            m_canvas.gameObject.SetActive(false);
        }
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
