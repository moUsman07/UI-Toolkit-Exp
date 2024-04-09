using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] UIDocument doc;
    [SerializeField] StyleSheet mystyle;




    public static event Action<float> scale;
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }
    private void Update()
    {
        
    }
    private void OnValidate()
    {
        if (Application.isPlaying) return;
        Generate();
    }
    public VisualElement root;

    void Generate()
    {
       root = doc.rootVisualElement;

        root.Clear();


        root.styleSheets.Add(mystyle);

        var container = Create("container");



        var viewBox = Create("viewBox", "border-box");
        container.Add(viewBox);

        var controlBox = Create("controlBox", "border-box");
        container.Add(controlBox);

        var spinButton = Create<Button>();
        controlBox.Add(spinButton);

        var scaleSlider = Create<Slider>();
        scaleSlider.lowValue = 0.5f;
        scaleSlider.highValue = 2f;
        scaleSlider.value = 1f;
        scaleSlider.RegisterValueChangedCallback(v => scale?.Invoke(v.newValue));
        controlBox.Add(scaleSlider);



        root.Add(container);

    }
    VisualElement Create(params string[] classNames)
    {
        return Create<VisualElement>(classNames);
    }

    T Create<T>(params string[] classNames) where T:VisualElement, new()
    {
        var ele = new T();

        foreach(var className in classNames)
        {
             ele.AddToClassList(className);
        }

        return ele;
    }
}
