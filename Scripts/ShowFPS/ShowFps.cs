using UnityEngine;
using System.Collections;

public class ShowFps : MonoBehaviour
{

    //private int FramesPerSec;
    //private float frequency = 1.0f;
    //private string fps;
    //private float _fps;
    //private bool show;

    //float StartDelay = 1f;
    //float Delay = 1f;

    //public Font font;

    //void Start()
    //{
    //    this.Delay = this.StartDelay;
    //}

    //private void Update()
    //{
    //    this.Delay -= Time.deltaTime;
    //    if (this.Delay > 0) return;

    //    _fps = 1.0f / Time.deltaTime;

    //    this.RefreshDelay();
    //}

    //void RefreshDelay()
    //{
    //    this.Delay = this.StartDelay;
    //}

    //void FixedUpdate()
    //{

    //}

    private int screenLongSide;
    private Rect boxRect;
    private GUIStyle style = new GUIStyle();
    public Font font;

    // for fps calculation.
    private int frameCount;
    private float elapsedTime;
    private double frameRate;

    /// <summary>
    /// Initialization
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        UpdateUISize();
    }

    /// <summary>
    /// Monitor changes in resolution and calcurate FPS
    /// </summary>
    private void Update()
    {
        // FPS calculation
        frameCount++;
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.5f)
        {
            frameRate = System.Math.Round(frameCount / elapsedTime, 1, System.MidpointRounding.AwayFromZero);
            frameCount = 0;
            elapsedTime = 0;

            // Update the UI size if the resolution has changed
            if (screenLongSide != Mathf.Max(Screen.width, Screen.height))
            {
                UpdateUISize();
            }
        }
    }

    /// <summary>
    /// Resize the UI according to the screen resolution
    /// </summary>
    private void UpdateUISize()
    {
        screenLongSide = Mathf.Max(Screen.width, Screen.height);
        var rectLongSide = screenLongSide / 10;
        boxRect = new Rect(1, 1, rectLongSide, rectLongSide / 3);
        style.fontSize = (int)(screenLongSide / 36.8);
        style.normal.textColor = Color.white;
    }

    void OnGUI()
    {
        GUI.skin.font = font;
        GUI.Label(new Rect(Screen.width - 230, Screen.height - 400, 230, 450), string.Format("FPS: {0}", frameRate.ToString("f2")));
    }
}