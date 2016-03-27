using UnityEngine;
using UnityEngine.UI;
public class TextEffectTest:MonoBehaviour
{
    //文本
    public Text text;
    public Button btn;
    private TextEffect te;
    void Start()
    {
        btn.onClick.AddListener(clickHandler);
        this.te = this.gameObject.AddComponent<TextEffect>();
        this.te.progressShow(text, "啊啊是是对的共骨骼王企鹅温柔绿卡失落的空间和iasdhjhkja破阿娇上的里卡多阿斯顿就 阿斯发达。", .05f, showCompleteHandler);
    }

    private void showCompleteHandler()
    {
        print("showCompleteHandler");
    }

    void clickHandler()
    {
        this.te.showComplete();
    }
}
