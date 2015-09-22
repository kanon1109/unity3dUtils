using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomTest : MonoBehaviour 
{
    public Button btn;
    void Start()
    {
        btn.onClick.AddListener(btnClickHandler);
    }

    private void btnClickHandler()
    {
        print("call random() " + RandomUtil.random());
        print("call randnum() " + RandomUtil.randnum(4.0f, 7.0f));
        print("call randint() " + RandomUtil.randint(1, 20));
        print("call randrange() " + RandomUtil.randrange(1, 20, 3));
        print("call boolean() " + RandomUtil.boolean(.8f));
        List<int> list = new List<int>(new int[] { 2, 10, 54, 11, 12, 32, 91 });
        print("call choice() " + RandomUtil.choice(list));
        
        print("---------------call sample()-------------");
        list = RandomUtil.sample(list, 4);
        int count = list.Count;
        for (int i = 0; i < count; ++i)
        {
            print(list[i]);
        }
        print("---------------end sample()-------------");

        print("---------------call shuffle()-------------");
        RandomUtil.shuffle(ref list);
        for (int i = 0; i < count; ++i)
        {
            print(list[i]);
        }
        print("---------------end shuffle()-------------");
    }
}
