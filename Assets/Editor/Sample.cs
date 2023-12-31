using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class Sample : EditorWindow
{
    [MenuItem("Window/UI Toolkit/Sample")]
    public static void ShowExample()
    {
        Sample wnd = GetWindow<Sample>();
        wnd.titleContent = new GUIContent("Sample");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Sample.uxml");
        VisualElement labelFromUxml = visualTree.Instantiate();
        root.Add(labelFromUxml);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/Sample.uss");
        VisualElement labelWithStyle = new Label("Hello World! With Style");
        labelWithStyle.styleSheets.Add(styleSheet);
        root.Add(labelWithStyle);

        // Add listener to button1
        var button1 = root.Q<Button>("button1");
        button1.RegisterCallback<MouseUpEvent>(e => Debug.Log("Button 1 pressed!"));
    }
}
