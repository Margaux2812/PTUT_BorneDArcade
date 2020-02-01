using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect1 : MonoBehaviour{
    //public
    public float speed = 3.0f;
    public float alpha = 0.7f;

    //private
    private Text text;
    private Image image;
    private float time;

    private void Start() {
        if (this.gameObject.GetComponent<Text>()) {
            text = this.gameObject.GetComponent<Text>();
        } else {
            image = this.gameObject.GetComponent<Image>();
        }
    }

    void Update() {
        if (this.gameObject.GetComponent<Text>()) {
            text.color = GetAlphaColor(text.color);
        }
        if (this.gameObject.GetComponent<Image>()) {
            image.color = GetAlphaColor(image.color);
        }
    }

    Color GetAlphaColor(Color color) {
        time += Time.deltaTime * speed;
        color.a = Mathf.Sin(time) * 0.5f + alpha;

        return color;
    }

    public void ResetColor() {
        if (this.gameObject.GetComponent<Text>()) {
            text.color += new Color(0,0,0,1);
        }
        if (this.gameObject.GetComponent<Image>() && image != null) {
            image.color += new Color(0, 0, 0, 1);
        }
    }

    public void goToMenuSnake()
    {
        Loader.Load(Loader.Scene.MenuSceneSnake);
    }

    public void playSnake()
    {
        Loader.Load(Loader.Scene.GameSceneSnake);
    }

    public void playSpace()
    {
        Loader.Load(Loader.Scene.GameScene_SpaceInvaders);
    }

    public void goToMenuSpaceInvader()
    {
        Loader.Load(Loader.Scene.MenuScene_SpaceInvaders);
    }

    public void goToMain()
    {
        Loader.Load(Loader.Scene.MenuGeneral);
    }
}
