using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class CanvasGroupController : MonoBehaviour
{
    //index0은 MainCanvas
    public List<CanvasGroup> Canvases = new List<CanvasGroup>();
    public GameObject exit, left, right; 
    public Button exitButton;
    public static CanvasGroupController Instance = null;
    
    void Awake()
    {
        if(Instance){
            DestroyImmediate(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //씬이 전환될 때마다 실행
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //캔버스 그룹 초기화 
        Canvases.Clear();
        //캔버스 그룹 찾아서 Canvases에 넣기
        CanvasGroup[] found = GameObject.FindObjectsByType<CanvasGroup>(FindObjectsSortMode.None);
        //캔버스 그룹 정렬
        System.Array.Sort(found, (a, b) => a.name.CompareTo(b.name));
        //정렬된 그룹을 리스트에 추가
        Canvases.AddRange(found);
        //버튼 클릭 연결
        exitButton.onClick.AddListener(() => ShowCanvas(0));
        if(exit != null)
        {
            exit.SetActive(false);
        }
        if(Canvases != null)
        {
            ShowCanvas(0);
        }

        //메인캔버스에 있는 버튼 클릭 연결
        GameObject mainCanvas = GameObject.Find("0_MainCanvas");
        if(mainCanvas)
        {
            Button[] buttons = mainCanvas.GetComponentsInChildren<Button>();
            foreach(var btn in buttons)
            {
                //이전의 버튼 이벤트 다 지움
                btn.onClick.RemoveAllListeners();
                //버튼 이름을 _을 기준으로 구분함
                string[] split = btn.name.Split('_');
                //split[0]을 정수로 변환하여 targetIndex에 넣음
                if(split.Length>0 && int.TryParse(split[0], out int targetIndex))
                {
                    btn.onClick.AddListener(() =>
                    {
                        ShowCanvas(targetIndex);
                    });
                }
                else
                {
                    Debug.Log("변환 실패. 이름이 올바른지 확인.");
                }
            }
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {   
        
    }

    //캔버스 보여주는 함수
    public void ShowCanvas(int indexToShow)
    {
        for(int i=0; i<Canvases.Count; i++)
        {
            SetCanvasActive(Canvases[i], i == indexToShow);
        }

        //Exit버튼 활성화 여부
        if(indexToShow != 0)
        {   
            ExitButtonActive(true);
        }
        else
        {   
            ExitButtonActive(false);
        }
    }
    
    void SetCanvasActive(CanvasGroup cg, bool active)
    {
        cg.alpha = active ? 1f : 0f;
        cg.interactable = active;
        cg.blocksRaycasts = active;
    }

    //Exit버튼 활성화하는 함수
    void ExitButtonActive(bool active)
    {
        GameObject.Find("ButtonCanvas").transform.GetChild(2).gameObject.SetActive(active); //exit
        GameObject.Find("ButtonCanvas").transform.GetChild(0).gameObject.SetActive(!active); //left
        GameObject.Find("ButtonCanvas").transform.GetChild(1).gameObject.SetActive(!active); //right
    }
    

}
