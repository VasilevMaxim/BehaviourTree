using System.Linq;
using CodeBase;
using UnityEditor;
using UnityEngine;

/*
 *            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Label"), false, null);
            menu.ShowAsContext();
 */


public class BehTestWindows : EditorWindow
{
    public Vector2 panOffset { get { return _panOffset; } set { _panOffset = value; Repaint(); } }
    private Vector2 _panOffset;
    
    public float zoom { get { return _zoom; } set { _zoom = Mathf.Clamp(value, 0, 100); Repaint(); } }
    private float _zoom = 1;
    private Vector2 dragBoxStart;

    public Vector2 WindowToGridPosition(Vector2 windowPosition) {
        return (windowPosition - (position.size * 0.5f) - (panOffset / zoom)) * zoom;
    }

    [MenuItem("Window/Tree2")]
    public static void ShowMyEditor()
    {
        EditorWindow wnd = GetWindow<BehTestWindows>();
        wnd.titleContent = new GUIContent("Tree2");
    }
    
    public Vector2 GridToWindowPosition(Vector2 gridPosition) {
        return (position.size * 0.5f) + (panOffset / zoom) + (gridPosition / zoom);
    }
    
    public Vector2 GridToWindowPositionNoClipped(Vector2 gridPosition) {
        Vector2 center = position.size * 0.5f;
        // UI Sharpness complete fix - Round final offset not panOffset
        float xOffset = Mathf.Round(center.x * zoom + (panOffset.x + gridPosition.x));
        float yOffset = Mathf.Round(center.y * zoom + (panOffset.y + gridPosition.y));
        return new Vector2(xOffset, yOffset);
    }

    private bool _add;
    private bool adding;

    private void CreateGUI()
    {
      //  _window = new MainArea();
      //  ControlHelper.Repaint = Repaint;
    }

    private void OnGUI()
    {
       // scrollPos = GUI.BeginScrollView(new Rect(0, 0, 800, 700), scrollPos, new Rect(0, 0, 800, 1500));
        
     //   ControlHelper.Controls();
       // _window.Update();

      //  GUI.EndScrollView();
      
      
        
        //Controls();

        /*GUILayout.BeginHorizontal();
        _add = GUILayout.Button("Add");
        GUILayout.Button("Remove");
        GUILayout.EndHorizontal();
        
        if (_isDown)
        {
            SelectBox();
        }

        if (_add)
        {
            adding = true;
        }

        if (adding)
        {
            
            Box();
        }

        //GUI.Toolbar(0, "Instructor");
        
        
        
        Window();
        //GUI.DrawTexture( new Rect(new Vector2(Screen.width - scale - 26, Screen.height / 2), new Vector2(25, 25)), EditorGUIUtility.IconContent("UnityEditor.InspectorWindow").image);
        
        GUI.Label(new Rect(new Vector2(Screen.width - 100, 0), new Vector2(100, 20)), "Inspector");
        //   GUI.Box(new Rect(curPos, new Vector2(100,200)), "hello");
        */
       
        if (_isDown)
        {
            SelectBox();
        }

    }

    public void Controls()
    {
        Event e = Event.current;
        switch (e.type)
        {
            case EventType.MouseDown:
                dragBoxStart = WindowToGridPosition(e.mousePosition);
                _isDown = true;
                Repaint();
                break;
            case EventType.MouseDrag:
                Repaint();
                break;
            
            case EventType.MouseUp:
                _isDown = false;
                break;
        }
    }
    
    private void Window2()
    {
        var scale = 100;
        GUI.Box(new Rect(new Vector2(Screen.width - scale, 0), new Vector2(scale, Screen.height - 10)), "");
        Handles.DrawLine(new Vector2(Screen.width - scale, 0), new Vector2(Screen.width - scale, Screen.height));
        
        Texture t = Resources.Load<Texture>("arrowLeft");
        GUI.DrawTexture( new Rect(new Vector2(Screen.width - scale - 26, Screen.height / 2), new Vector2(25, 25)), t);
        
        Texture t2 = Resources.Load<Texture>("arrowRight");
        GUI.DrawTexture( new Rect(new Vector2(Screen.width - scale + 1, Screen.height / 2), new Vector2(25, 25)), t2);
        
        EditorGUIUtility.AddCursorRect(new Rect(new Vector2(Screen.width - 100 + 1, Screen.height / 2), new Vector2(55, 25)), MouseCursor.SlideArrow);

        
    }
    
    private void RightPanel()
    {

   }
    
    
    private void Box()
    {
        Vector2 mousePos = Vector2.zero;
        Vector2 boxStartPos = GridToWindowPositionNoClipped(dragBoxStart);
        Vector2 boxSize = new Vector2(100, 150);
        Rect selectionBox = new Rect(mousePos, boxSize);
        
        Rect selectionUpperBox = new Rect(mousePos, new Vector2(100, 40));
        
        Handles.DrawSolidRectangleWithOutline(selectionBox, new Color(0, 0, 0, 0.1f), new Color(1, 1, 1, 0.6f));
        Handles.DrawSolidRectangleWithOutline(selectionUpperBox, new Color(0, 0, 0, 0.1f), new Color(1, 1, 1, 0.6f));
    }
    
    private void SelectBox()
    {
        Vector2 curPos = WindowToGridPosition(Event.current.mousePosition);
        Vector2 size = curPos - dragBoxStart;
        Rect r = new Rect(dragBoxStart, size);
        r.position = GridToWindowPosition(r.position);
        r.size /= zoom;
        Handles.DrawSolidRectangleWithOutline(r, new Color(0, 0, 0, 0.1f), new Color(1, 1, 1, 0.6f));
    }

    private bool _isDown;
   // private MainArea _window;
    private Vector2 scrollPos;
}
