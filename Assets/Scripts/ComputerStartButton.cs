using UnityEngine;
using UnityEngine.UI;

public class ComputerStartButton : MonoBehaviour
{
    public Button startButton;
    public GameObject listPanel;
    public GameObject buttonPanel;

    public Button fileExplorerButton;
    public GameObject folder;
    public GameObject binFolder;

    public GameObject secureLabShortcut;
    public GameObject secureLab;

    public GameObject stickyNotes;


    public void OnStartButtonClick()
    {
        // listPanel, buttonPanel이 켜져 있는지 확인, folder가 활성화되어있다면 켜지 못하게
        if ((listPanel.activeSelf && buttonPanel.activeSelf) || (folder.activeSelf || binFolder.activeSelf || secureLab.activeSelf))
        {
          // 켜져 있다면 끈다
            listPanel.SetActive(false);
            buttonPanel.SetActive(false);
        }else{
          // 꺼져 있다면 켠다
            listPanel.SetActive(true);
            buttonPanel.SetActive(true);
        }  
    }

    public void OnFileExplorerButtonClick()
    {
        folder.SetActive(true);
        binFolder.SetActive(false);
        listPanel.SetActive(false);
        buttonPanel.SetActive(false);
        stickyNotes.SetActive(false);
        secureLabShortcut.SetActive(false);
        Debug.Log("파일탐색기버튼클릭됨");
    }
    public void OnTrashButtonClick()
    {
        binFolder.SetActive(true);
        folder.SetActive(false);
        listPanel.SetActive(false);
        buttonPanel.SetActive(false);
        stickyNotes.SetActive(false);
        secureLabShortcut.SetActive(false);
        Debug.Log("휴지통버튼클릭됨");
    }
    public void OnSecureLabShortcutClick()
    {
        secureLab.SetActive(true);
        // binFolder.SetActive(true);
        // folder.SetActive(false);
        listPanel.SetActive(false);
        buttonPanel.SetActive(false);
        stickyNotes.SetActive(false);
        secureLabShortcut.SetActive(false);
        Debug.Log("secureLabShortcut클릭됨");
    }

    public void OnFolderExitButtonClick()
    {
        folder.SetActive(false);
        binFolder.SetActive(false);
        secureLab.SetActive(false);
        stickyNotes.SetActive(true);
        secureLabShortcut.SetActive(true);
        Debug.Log("FolderExitButton버튼클릭됨");
    }
}
