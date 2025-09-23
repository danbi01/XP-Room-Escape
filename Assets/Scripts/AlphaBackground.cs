using UnityEngine;
using UnityEngine.UI;

public class AlphaBackground : MonoBehaviour
{
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
    }
}
