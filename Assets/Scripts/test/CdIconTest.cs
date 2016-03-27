using UnityEngine;
using UnityEngine.UI;

public class CdIconTest : MonoBehaviour
{
    public CdIcon cdIcon;
    public Button btn;

    void Start()
    {
        btn.onClick.AddListener(btnClickHandler);
    }

    private void btnClickHandler()
    {
        cdIcon.start(60f);
    }
}
