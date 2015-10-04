using UnityEngine;
using UnityEngine.UI;
public class ShakeTest : MonoBehaviour
{
    private GameObject camera;
    private Shake shake;
    public Button button;

    void Start()
    {
        camera = GameObject.Find("Main Camera");
        shake = this.GetComponent<Shake>();
        button.onClick.AddListener(clickHandler);
    }

    private void clickHandler()
    {
        shake.shake(this.gameObject);
    }

}
