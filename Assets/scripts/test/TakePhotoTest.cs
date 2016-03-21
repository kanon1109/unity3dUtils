using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class TakePhotoTest : MonoBehaviour
{
    public Button btn;
    public void Start()
    {
        btn.onClick.AddListener(btnClickHandler);
    }

    private void btnClickHandler()
    {
        StartCoroutine(TakePhoto.takeAndSave("test.png"));
    }
}