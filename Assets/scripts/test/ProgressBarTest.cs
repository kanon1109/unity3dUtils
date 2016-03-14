using UnityEngine;
using UnityEngine.UI;

public class ProgressBarTest : MonoBehaviour
{
    public ProgressBar bar;
    public Button btn;
    public Text levelTxt;
    private int level = 0;
    private int exp = 0;
    private int totalExp = 0;
    private Timer timer;
    private bool isDown = false;
    public void Start()
    {
        this.timer = this.gameObject.AddComponent<Timer>();
        this.timer.createTimer(.3f, -1, timerComplete);

        this.levelTxt.text = level.ToString();
        this.totalExp = 100;
        EventTriggerListener.Get(btn.gameObject).onDown = onDonwHandler;
        EventTriggerListener.Get(btn.gameObject).onUp = onUpHandler;

        //btn.onClick.AddListener(btnClickHandler);
        //bar.setValue(.8f);
        //bar.moveToValue(.3f, 2);
    }

    private void timerComplete()
    {
        if (this.isDown)
        {
            this.btnClickHandler();
        }
    }

    private void onUpHandler(GameObject go)
    {
        this.isDown = false;
        this.timer.stop();
    }

    private void onDonwHandler(GameObject go)
    {
        this.isDown = true;
        this.timer.reset();
        this.timer.start();
        this.btnClickHandler();
    }

    private void btnClickHandler()
    {
        //print("--------------------------");
        //print("prev exp " + exp);
        //print("prev totalExp " + totalExp);
        exp += 300;
        int loop = 0;
        while (exp > totalExp) 
        {
            level++;
            loop++;
            exp -= totalExp;
            totalExp += 50 * level;
            //print("升级");
        }
        //print("exp " + exp);
        //print("totalExp " + totalExp);
        //print("loop " + loop);
        this.levelTxt.text = level.ToString();
        float p = (float)exp / (float)totalExp;
        bar.moveToValue(p, loop);
    }

}
