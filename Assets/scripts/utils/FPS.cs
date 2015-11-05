using UnityEngine;
using System.Collections;
using UnityEngine.UI;
  
public class FPS : MonoBehaviour
{
    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames = 0;
    private float fps;

	private Text tf;
    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
		tf = gameObject.GetComponent<Text>();
		tf.transform.localPosition = new Vector2(-Layer.Instance.getRootRect().x / 2, -Layer.Instance.getRootRect().y / 2);
    }
    void Update()
    {
		if(tf == null)
		{
			return;
		}
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
			tf.text = "FPS:" + (int)fps;
        }
    }
}