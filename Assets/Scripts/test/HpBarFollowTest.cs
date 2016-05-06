using UnityEngine;
using System.Collections;

public class HpBarFollowTest : MonoBehaviour
{
    public ProgressBar hpBar;
    public GameObject role;
    private UIFollow uiFollow;
    // Use this for initialization
    void Start()
    {
        hpBar.setValue(1);
        this.uiFollow = this.gameObject.GetComponent<UIFollow>();
        if (this.uiFollow == null)
            this.uiFollow = this.gameObject.AddComponent<UIFollow>();
        this.uiFollow.targetTransform = this.role.transform;
        this.uiFollow.uiTransform = this.hpBar.transform;
        this.uiFollow.offset = new Vector2(-this.hpBar.GetComponent<RectTransform>().sizeDelta.x / 2, 40);
    }

    // Update is called once per frame
    void Update()
    {
        //测试代码 移动角色
        if (Input.GetKey(KeyCode.W))
            role.transform.Translate(Vector3.forward);
        if (Input.GetKey(KeyCode.S))
            role.transform.Translate(Vector3.back);
        if (Input.GetKeyDown(KeyCode.A))
            role.transform.Translate(Vector3.left);
        if (Input.GetKeyDown(KeyCode.D))
            role.transform.Translate(Vector3.right);
    }
}
