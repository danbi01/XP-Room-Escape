using UnityEngine;
using UnityEngine.UI;

public class ComputerStartButton : MonoBehaviour
{
     public Button startButton;
    public GameObject listPanel;
    public GameObject buttonPanel;
  public GameObject homeOverlay;


   public void OnStartButtonClick()
  {
    // listPanel, buttonPanel이 켜져 있는지 확인
    if (listPanel.activeSelf && buttonPanel.activeSelf)
    {
      // 켜져 있다면 끈다
      listPanel.SetActive(false);
      buttonPanel.SetActive(false);
    }
    else
    {
      // 꺼져 있다면 켠다
      listPanel.SetActive(true);
      buttonPanel.SetActive(true);
    }
  }
}
